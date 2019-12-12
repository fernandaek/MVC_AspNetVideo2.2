using AspNetCore22Intro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore22Intro.ViewModels
{
    public class VideoCreateEditViewModel
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(80)]
        public string Title { get; set; }
        public Genres Genre { get; set; }
    }
}
