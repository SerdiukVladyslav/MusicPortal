using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "LoginRequired")]
        public string? Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
