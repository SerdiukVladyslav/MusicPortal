using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [Required(ErrorMessage = "Поле 'Title' обов'язкове для заповнення")]
        [StringLength(100, ErrorMessage = "Назва пісні повинна містити від 1 до 100 символів", MinimumLength = 1)]
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
