using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Countries
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Country' обов'язкове для заповнення")]
        [StringLength(100, ErrorMessage = "Назва країни повинна містити від 1 до 100 символів", MinimumLength = 1)]
        public string Country { get; set; }

        public List<Song> Songs { get; set; }
    }
}
