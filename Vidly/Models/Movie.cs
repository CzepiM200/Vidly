using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        // POCO - bechaviour
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte  GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 30)]
        public byte NumberInStock { get; set; }
    }
}