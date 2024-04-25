using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Albums
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "AlbumRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "AlbumLength", MinimumLength = 1)]
        public string Album { get; set; }

        public string? AlbumCover { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "YearRequired")]
        [Range(1900, 2024, ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "YearLength")]
        public int Year { get; set; }

        public List<Song> Songs { get; set; }
    }
}
