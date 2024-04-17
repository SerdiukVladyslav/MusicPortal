using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Salt { get; set; }

        [Required(ErrorMessage = "Поле 'AccessLevel' обов'язкове для заповнення")]
        [Range(0, 2, ErrorMessage = "Рівень доступу має бути 0, 1 або 2")]
        public int AccessLevel { get; set; }
    }
}
