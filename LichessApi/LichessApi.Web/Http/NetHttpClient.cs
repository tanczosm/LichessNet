using System.Net;
using System.Text;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LichessApi.Web.Http
{
    public class NetHttpClient : IHTTPClient
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        private readonly HttpMessageHandler? _httpMessageHandler;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        private readonly HttpClient _httpClient;

        public NetHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public NetHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public NetHttpClient(IProxyConfig proxyConfig)
        {
            Ensure.ArgumentNotNull(proxyConfig, nameof(proxyConfig));

            _httpMessageHandler = CreateMessageHandler(proxyConfig);
            _httpClient = new HttpClient(_httpMessageHandler);
        }

        public async Task<IResponse> DoRequest(IRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            using HttpRequestMessage requestMsg = BuildRequestMessage(request);
            var responseMsg = await _httpClient
                    .SendAsync(requestMsg, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);

            return await BuildResponse(responseMsg, request.CancellationToken).ConfigureAwait(false);
        }

        private static async Task<IResponse> BuildResponse(HttpResponseMessage responseMsg, CancellationToken token = default)
        {
            Ensure.ArgumentNotNull(responseMsg, nameof(responseMsg));

            // using var content? Watch for leaks
            var content = responseMsg.Content;
            var headers = responseMsg.Headers.ToDictionary(header => header.Key, header => header.Value.First());

            var contentType = content.Headers?.ContentType?.MediaType;

            var isStream = contentType != null && contentType.Equals("application/x-ndjson", StringComparison.OrdinalIgnoreCase);

            var response = new Response(headers)
            {
                ContentType = contentType,
                StatusCode = responseMsg.StatusCode,
                Body = isStream ?
                    await content.ReadAsStreamAsync(token) :
                    await content.ReadAsStringAsync(token).ConfigureAwait(false)
            };

            return response;
        }

        private static HttpRequestMessage BuildRequestMessage(IRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            var fullUri = new Uri(request.BaseAddress, request.Endpoint).ApplyParameters(request.Parameters);
            var requestMsg = new HttpRequestMessage(request.Method, fullUri);
            foreach (var header in request.Headers)
            {
                requestMsg.Headers.Add(header.Key, header.Value);
            }

            switch (request.Body)
            {
                case HttpContent body:
                    requestMsg.Content = body;
                    break;
                case string body:
                    requestMsg.Content = new StringContent(body, Encoding.UTF8, "application/json");
                    break;
                case Stream body:
                    requestMsg.Content = new StreamContent(body);
                    break;
            }

            return requestMsg;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
                _httpMessageHandler?.Dispose();
            }
        }

        public void SetRequestTimeout(TimeSpan timeout)
        {
            _httpClient.Timeout = timeout;
        }

        private static HttpMessageHandler CreateMessageHandler(IProxyConfig proxyConfig)
        {
            var proxy = new WebProxy
            {
                Address = new UriBuilder(proxyConfig.Host) { Port = proxyConfig.Port }.Uri,
                UseDefaultCredentials = true,
                BypassProxyOnLocal = proxyConfig.BypassProxyOnLocal
            };

            if (!string.IsNullOrEmpty(proxyConfig.User) || !string.IsNullOrEmpty(proxyConfig.Password))
            {
                proxy.UseDefaultCredentials = false;
                proxy.Credentials = new NetworkCredential(proxyConfig.User, proxyConfig.Password);
            }

            var httpClientHandler = new HttpClientHandler
            {
                PreAuthenticate = proxy.UseDefaultCredentials,
                UseDefaultCredentials = proxy.UseDefaultCredentials,
                UseProxy = true,
                Proxy = proxy,
            };
            if (proxyConfig.SkipSSLCheck)
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            }

            return httpClientHandler;
        }
    }
}
