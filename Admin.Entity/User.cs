using System.ComponentModel.DataAnnotations;

namespace Admin.Entity
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Email adresinizi giriniz!")]
        [EmailAddress(ErrorMessage = "Yanlış formatta email adresi girdiniz!")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public int IsSpecialUser { get; set; }

        public int ClientID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Şirket seçimini yapınız!")]
        public int FirmID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
