using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinUP2018.Models;

namespace XamarinUP2018.Services
{
    public interface IUnsplashService
    {
        Task<List<UnsplashPicture>> GetPictures();
    }

    public sealed class UnsplashService : IUnsplashService
    {
        private string clientId = "ed9ebc8ec5174015e866f9916f71adc3fb949a08ea9b015a03826078383d6e27";
        private string GetApiUrl(int picCount = 10)
            => $"https://api.unsplash.com/photos/random/?count={picCount}&client_id={clientId}";

        public async Task<List<UnsplashPicture>> GetPictures()
        {
            var response = await new HttpClient().GetStringAsync(GetApiUrl());
            return UnsplashPicture.FromJson(response);
        }
    }
}
