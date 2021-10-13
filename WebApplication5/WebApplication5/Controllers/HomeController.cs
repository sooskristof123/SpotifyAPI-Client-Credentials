using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Services;

namespace WebApplication5
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAccountServices iSpotifyAccountServices;
        private readonly IConfiguration iConfiguration;
        public HomeController(ISpotifyAccountServices iSpotifyAccountServices, IConfiguration iConfiguration) {
            this.iSpotifyAccountServices = iSpotifyAccountServices;
            this.iConfiguration = iConfiguration;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var token = await iSpotifyAccountServices.GetToken(iConfiguration["Spotify:clientId"], iConfiguration["Spotify:clientSecret"]);
                
            }

            catch (Exception ex)
            {
                Debug.Write(ex);
            }
            return View();
        }
    }
}
