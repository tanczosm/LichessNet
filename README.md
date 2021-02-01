<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/tanczosm/LichessApi">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Lichess .Net Api Client</h3>

  <p align="center">
    project_description
    <br />
    <a href="https://github.com/tanczosm/LichessApi"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/tanczosm/LichessApi">View Demo</a>
    ·
    <a href="https://github.com/tanczosm/LichessApi/issues">Report Bug</a>
    ·
    <a href="https://github.com/tanczosm/LichessApi/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://example.com)


### Built With

* []()
* []()
* []()



<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
  ```sh
  npm install npm@latest -g
  ```

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/tanczosm/LichessApi.git
   ```
2. Install NPM packages
   ```sh
   npm install
   ```



<!-- USAGE EXAMPLES -->
## Usage

```csharp
using System;
using LichessApi.Web;

class Program
{
    static async Task Main()
    {
      var client = new LichessApiClient("YourAccessToken");

      var email = await client.Account.GetEmailAddress();
	  
      Console.WriteLine(email);
    }
}
```

More examples can be found in the `LichessApi.Web.Examples` directory.



<!-- ROADMAP -->
## Roadmap

The following Api areas have been completed so far:

- [x] Authentication
- [x] Account
- [ ] Users
- [ ] Relations
- [x] Games
- [ ] Puzzles
- [ ] Teams
- [ ] Board
- [ ] Bot
- [x] Challenges
- [ ] Arena Tournaments
- [ ] Swiss Tournaments
- [ ] Simuls
- [ ] Studies
- [ ] Messaging
- [ ] Broadcasts
- [ ] Analysis
- [ ] Opening Explorer


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Michael Tanczos

Project Link: [https://github.com/tanczosm/LichessApi](https://github.com/tanczosm/LichessApi)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* [https://github.com/JohnnyCrazy/SpotifyAPI-NET](SpotifyAPI-NET)




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/tanczosm/LichessApi.svg?style=for-the-badge
[contributors-url]: https://github.com/tanczosm/LichessApi/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/tanczosm/LichessApi.svg?style=for-the-badge
[forks-url]: https://github.com/tanczosm/LichessApi/network/members
[stars-shield]: https://img.shields.io/github/stars/tanczosm/LichessApi.svg?style=for-the-badge
[stars-url]: https://github.com/tanczosm/LichessApi/stargazers
[issues-shield]: https://img.shields.io/github/issues/tanczosm/LichessApi.svg?style=for-the-badge
[issues-url]: https://github.com/tanczosm/LichessApi/issues
[license-shield]: https://img.shields.io/github/license/tanczosm/LichessApi.svg?style=for-the-badge
[license-url]: https://github.com/tanczosm/LichessApi/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/tanczosm
