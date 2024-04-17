using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class Artists
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Artist' обов'язкове для заповнення")]
        [StringLength(100, ErrorMessage = "Назва артисту повинна містити від 1 до 100 символів", MinimumLength = 1)]
        public string Artist { get; set; }

        public List<Song> Songs { get; set; }
    }
}
