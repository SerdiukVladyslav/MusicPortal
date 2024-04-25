using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Countries
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "CountryRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "CountryLength", MinimumLength = 1)]
        public string Country { get; set; }

        public List<Song> Songs { get; set; }
    }
}
