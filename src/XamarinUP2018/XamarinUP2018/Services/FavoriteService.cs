using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinUP2018.Models;
using XamarinUP2018.Repositories;


namespace XamarinUP2018.Services
{ 
    public interface IFavoriteService
    {
        Task Add(UnsplashPicture picture);
        Task Edit(UnsplashPicture picture);
        Task Delete(UnsplashPicture picture);

        Task<List<UnsplashPicture>> GetAll();
        Task<UnsplashPicture> GetById(string id);
        Task<bool> Exists(UnsplashPicture picture);
    }

    public sealed class FavoriteService : IFavoriteService
    {
        private readonly ILocalDataBaseRepository localDataBaseRepository;

        public FavoriteService(ILocalDataBaseRepository localDataBaseRepository)
        {
            this.localDataBaseRepository = localDataBaseRepository;
        }

        public Task Add(UnsplashPicture picture)
            => Task.Run(() => localDataBaseRepository.Add(picture));

        public Task Edit(UnsplashPicture picture)
            => Task.Run(() => localDataBaseRepository.Edit(picture));

        public Task Delete(UnsplashPicture picture)
            => Task.Run(() => localDataBaseRepository.Delete(picture));

        public Task<List<UnsplashPicture>> GetAll()
            => Task.Run(() => localDataBaseRepository.GetAll());

        public Task<UnsplashPicture> GetById(string id)
            => Task.Run(() => localDataBaseRepository.GetById(id));

        public Task<bool> Exists(UnsplashPicture picture)
            => Task.Run(() => localDataBaseRepository.Exists(picture));
    }
}
