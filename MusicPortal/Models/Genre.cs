using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Name' обов'язкове для заповнення")]
        [StringLength(100, ErrorMessage = "Назва жанру повинна містити від 1 до 100 символів", MinimumLength = 1)]
        public string Name { get; set; }

        public List<Song> Songs { get; set; }
    }
}
