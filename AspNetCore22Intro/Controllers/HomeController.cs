using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore22Intro.Services;
using AspNetCore22Intro.ViewModels;
using AspNetCore22Intro.Models;
using AspNetCore22Intro.Entities;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCore22Intro.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IVideoData _videos;

        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _videos.GetAll().Select(video => new VideoViewModel
            {
                Id = video.Id,
                Title = video.Title,
                //Genre = Enum.GetName(typeof(Genres), video.GenreId)
                Genre = video.Genre.ToString()
            });
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _videos.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
            return View(new VideoViewModel
            {
                Id = model.Id,
                Title = model.Title,
                //Genre = Enum.GetName(typeof(Genres), model.GenreId)
                Genre = model.Genre.ToString()
            });
            }
        }

        [HttpGet] //Tells which method to call when the view is rendered
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Tells which method to call when the view is rendered
        public IActionResult Create(VideoCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {

                var video = new Video
                    {
                        Title = model.Title,
                        Genre = model.Genre
                    };
                _videos.Add(video); //Db Context
                _videos.Commit();

                return RedirectToAction("Details", new { id = video.Id }); // 'new' comes from an annonym object that takes id as property
                }

            return View();
            }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var video = _videos.Get(id);

            if(video == null)
            {
                return RedirectToAction("Index");
            }

            return View(video);
        }

        [HttpPost]
        public IActionResult Edit(int id, VideoCreateEditViewModel model)
        {
            var video = _videos.Get(id);
            
            if (video == null || !ModelState.IsValid)
            {
                return View(model);
            }

            video.Title = model.Title;
            video.Genre = model.Genre;

            _videos.Commit();

            return RedirectToAction("Details", new { id = video.Id });
            
        }
    }
}
