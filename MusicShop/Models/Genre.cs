using System.Collections.Generic;

namespace MusicShop.Models
{
    public class Genre
    {
        public long GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconFilename { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}