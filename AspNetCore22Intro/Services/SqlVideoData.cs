﻿using AspNetCore22Intro.Data;
using AspNetCore22Intro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore22Intro.Services
{
    public class SqlVideoData : IVideoData
    {
        private readonly VideoDbContext _db;

        public SqlVideoData(VideoDbContext db)
        {
            _db = db;
        }

        public void Add(Video newVideo)
        {
            _db.Add(newVideo);
        }

        public Video Get(int id)
        {
            return _db.Find<Video>(id);
        }

        public IEnumerable<Video> GetAll()
        {
            return _db.Videos;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

    }
}
