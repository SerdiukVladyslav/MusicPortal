using System.ComponentModel.DataAnnotations;

namespace MusicPortal.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "FirstNameRequired")]
        public string? FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "LastNameRequired")]
        public string? LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "LoginRequired")]
        public string? Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "PasswordConfirmRequired")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "PasswordCompare")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}
