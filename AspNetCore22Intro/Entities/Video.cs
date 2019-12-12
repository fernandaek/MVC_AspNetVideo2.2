using AspNetCore22Intro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore22Intro.Entities
{
    public class Video
    {
        public int Id { get; set; }
        [Required, MaxLength(80)] //Forces the user to enter a value in the control, for the model object to be valid.
        public string Title { get; set; }
        public int GenreId { get; set; }
        [Display(Name ="Film Genre")]
        public Genres Genre { get; set; }


    }
}
