using System.ComponentModel.DataAnnotations;

namespace Admin.Entity
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email adresinizi giriniz!")]
        [EmailAddress(ErrorMessage = "Yanlış formatta email adresi girdiniz!")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public string FullName { get; set; }
    }
}
