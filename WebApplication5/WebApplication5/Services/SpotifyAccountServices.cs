using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class SpotifyAccountServices : ISpotifyAccountServices
    { 
        private readonly HttpClient httpClient;
        public SpotifyAccountServices(HttpClient httpClient) {
            this.httpClient = httpClient;
        }
        public async Task<string> GetToken(string clientId, string clientSecret)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "token");
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"))
            );

            request.Content = new FormUrlEncodedContent( new Dictionary<string, string> {
                {"grant_type", "client_credentials"}
            });
            var respone = await httpClient.SendAsync(request);
            respone.EnsureSuccessStatusCode();

            using var responseStream = await respone.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<AuthToken>(responseStream);


            return authResult.access_token;
        }
    }
}
