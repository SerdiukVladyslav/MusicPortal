using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Artists
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "ArtistRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "ArtistLength", MinimumLength = 1)]
        public string Artist { get; set; }

        public List<Song> Songs { get; set; }
    }
}
