using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "TitleRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "TitleLength", MinimumLength = 1)]
        public string Title { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int ArtistsId { get; set; }
        public Artists Artists { get; set; }

        public int AlbumsId { get; set; }
        public Albums Albums { get; set; }

        public int CountryId { get; set; }
        public Countries Countries { get; set; }

        public string? MusicFile { get; set; }
    }
}
