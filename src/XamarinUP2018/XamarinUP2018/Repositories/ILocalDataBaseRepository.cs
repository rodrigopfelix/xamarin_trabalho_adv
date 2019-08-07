﻿using System.Collections.Generic;
using XamarinUP2018.Models;

namespace XamarinUP2018.Repositories
{
    public interface ILocalDataBaseRepository
    {
        void Add(UnsplashPicture picture);
        void Edit(UnsplashPicture picture);
        void Delete(UnsplashPicture picture);

        List<UnsplashPicture> GetAll();
        UnsplashPicture GetById(string id);
        bool Exists(UnsplashPicture picture);
    }
}
