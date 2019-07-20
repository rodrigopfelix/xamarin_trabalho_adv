using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinUP2018.Models;

namespace XamarinUP2018.Services
{
    public interface IFeedService
    {
        Task<List<FeedItem>> GetFeedItems();
    }

    public sealed class FeedService : IFeedService
    {
        public async Task<List<FeedItem>> GetFeedItems()
        {
            await Task.Delay(2000);

            return new List<FeedItem>
            {
                new FeedItem
                {
                    Description = "Applauded use attempted strangers now are middleton concluded had. It is tried ﻿no added purse shall no on truth",
                    Picture = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/the-lion-king-mufasa-simba-1554901700.jpg",
                    UserName = "simba",
                    UserThumbnail = "https://pbs.twimg.com/profile_images/1088471062743007233/7BkiWNUj_400x400.jpg",
                },
                new FeedItem
                {
                    Description = "Applauded use attempted strangers now are middleton concluded had. It is tried ﻿no added purse shall no on truth",
                    Picture = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/the-lion-king-mufasa-simba-1554901700.jpg",
                    UserName = "simba",
                    UserThumbnail = "https://pbs.twimg.com/profile_images/1088471062743007233/7BkiWNUj_400x400.jpg",
                },
                new FeedItem
                {
                    Description = "Applauded use attempted strangers now are middleton concluded had. It is tried ﻿no added purse shall no on truth",
                    Picture = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/the-lion-king-mufasa-simba-1554901700.jpg",
                    UserName = "simba",
                    UserThumbnail = "https://pbs.twimg.com/profile_images/1088471062743007233/7BkiWNUj_400x400.jpg",
                },
            };
        }
    }
}
