using AspNetCore22Intro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore22Intro.Services
{
    public class MockVideoData : IVideoData
    {

        //private readonly IEnumerable<Video> _videos;
        private readonly List<Video> _videos; //Changed to be able toadd a new video collection since with IEnumerable you cant add values


        public MockVideoData()
        {
            _videos = new List<Video> {
               new Video { Id = 2, Genre = Models.Genres.Comedy, Title = "Despicable Me" },
               new Video { Id = 1, Genre = Models.Genres.Horror, Title = "Shrek" },
               new Video { Id = 3, Genre = Models.Genres.Animated, Title = "Megamind" },
            };
        }


        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }
        public Video Get(int id)
        {
            return _videos.FirstOrDefault(video => video.Id.Equals(id));
        }

        public void Add(Video newVideo)
        {
            newVideo.Id = _videos.Max(v => v.Id) + 1;
            _videos.Add(newVideo);
        }

        public int Commit()
        {
            return 0;
        }
    }
}
