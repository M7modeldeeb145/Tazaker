using System.ComponentModel.DataAnnotations;

namespace Tazaker.ViewModels
{
    public class UserLoginVM
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
