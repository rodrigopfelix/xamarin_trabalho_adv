using LiteDB;
using System.Collections.Generic;
using System.Linq;
using XamarinUP2018.Models;
using XamarinUP2018.Services;

namespace XamarinUP2018.Repositories
{
    public sealed class LocalDataBaseRepository : ILocalDataBaseRepository
    {
        private const string COLLECTION_NAME = "pictures";

        private readonly LiteCollection<UnsplashPicture> liteCollection;
        private readonly IDataBaseAccessService dataBaseAccessService;

        public LocalDataBaseRepository(IDataBaseAccessService dataBaseAccessService)
        {
            this.dataBaseAccessService = dataBaseAccessService;
            liteCollection = GetCollection();
        }

        public void Add(UnsplashPicture picture)
            => liteCollection.Insert(picture);

        public void Delete(UnsplashPicture picture)
            => liteCollection.Delete(picture.Id);

        public void Edit(UnsplashPicture picture)
            => liteCollection.Update(picture);

        public List<UnsplashPicture> GetAll()
            => liteCollection.FindAll().ToList();

        public UnsplashPicture GetById(string id)
            => liteCollection.FindById(id);

        public bool Exists(UnsplashPicture picture)
            => liteCollection.FindById(picture.Id) != null;

        private LiteCollection<UnsplashPicture> GetCollection()
        {
            var db = GetOrCreateLiteDatabase();
            return db.GetCollection<UnsplashPicture>(COLLECTION_NAME);
        }

        private LiteDatabase GetOrCreateLiteDatabase()
        {
            var dbPath = dataBaseAccessService.GetDataBasePath();
            return new LiteDatabase($@"{dbPath}");
        }
    }
}
