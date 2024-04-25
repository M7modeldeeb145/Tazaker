using System.ComponentModel.DataAnnotations;

namespace Tazaker.ViewModels
{
    public class ApplicationUserVM
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
  //      [DataType(DataType.ImageUrl)]
		//public string? ProfilePicture { get; set; }
		[Required]
		public string PhoneNumer { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
