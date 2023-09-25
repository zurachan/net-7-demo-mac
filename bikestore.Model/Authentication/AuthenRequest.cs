using System.ComponentModel.DataAnnotations;

namespace bikestore.Model.Authentication
{
    public class AuthenRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username không được để trống")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password không được để trống")]
        public string Password { get; set; }
    }
}
