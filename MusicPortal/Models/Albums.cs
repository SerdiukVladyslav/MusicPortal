using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Albums
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Album' обов'язкове для заповнення")]
        [StringLength(100, ErrorMessage = "Назва альбому повинна містити від 1 до 100 символів", MinimumLength = 1)]
        public string Album { get; set; }

        public string? AlbumCover { get; set; }

        [Required(ErrorMessage = "Поле 'Year' обов'язкове для заповнення")]
        [Range(1900, 2024, ErrorMessage = "Рік випуску повинен бути між 1900 та 2024")]
        public int Year { get; set; }

        public List<Song> Songs { get; set; }
    }
}
