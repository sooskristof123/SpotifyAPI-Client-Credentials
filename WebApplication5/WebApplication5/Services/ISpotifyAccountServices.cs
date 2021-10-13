using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Services
{
    public interface ISpotifyAccountServices
    {
        public Task<string> GetToken(string clientId, string clientSecret);
    }
}
