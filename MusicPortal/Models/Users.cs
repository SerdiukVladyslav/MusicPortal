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

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "AccessLevelRequired")]
        [Range(0, 2, ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "AccessLevelLength")]
        public int AccessLevel { get; set; }
    }
}
