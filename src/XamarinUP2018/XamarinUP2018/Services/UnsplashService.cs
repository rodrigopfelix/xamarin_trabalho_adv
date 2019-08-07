using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        #region Constants
        private const string clientId = "ed9ebc8ec5174015e866f9916f71adc3fb949a08ea9b015a03826078383d6e27";
        private const int httpTimeout = 3000;
        private const int defaultPictureCount = 30;
        #endregion

        private string GetApiUrl(int picCount = defaultPictureCount)
            => $"https://api.unsplash.com/photos/random/?count={picCount}&client_id={clientId}";

        public async Task<List<UnsplashPicture>> GetPictures()
        {
            var response = "[]"; // Empty json array
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(httpTimeout);
            try
            {
                response = await httpClient.GetStringAsync(GetApiUrl());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return UnsplashPicture.FromJson(response);
        }
    }
}
