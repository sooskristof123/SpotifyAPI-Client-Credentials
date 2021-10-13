using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAccountService spotifyAccountService;
        private readonly IConfiguration configuration;

        public HomeController(ISpotifyAccountService spotifyAccountService, IConfiguration configuration)
        {
            this.spotifyAccountService = spotifyAccountService;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var token = await spotifyAccountService.GetToken(configuration["Spotify:clientId"], configuration["Spotify:clientSecret"]);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
