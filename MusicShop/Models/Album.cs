using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicShop.Models
{
    public class Album
    {
        public long AlbumId { get; set; }
        public long GenreId { get; set; }
        [Display(Name = "Tytuł")]
        [Required]
        public string AlbumTitle { get; set; }
        [Display(Name = "Artusta")]
        [Required]
        public string ArtistName { get; set; }
        public DateTime DateAdded { get; set; }
        public string CoverFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsHidden { get; set; }
        public virtual Genre Genre { get; set; }
    }
}