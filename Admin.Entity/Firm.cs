using System.ComponentModel.DataAnnotations;

namespace Admin.Entity
{
    public class Firm
    {
        [Required(ErrorMessage = "Firma adını giriniz")]
        [Display(Name = "Firma Adı")]
        public string Name { get; set; }

        [Display(Name = "Firma Uzun Adı")]
        public string FullName { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Phone(ErrorMessage = "Yanlış formatta telefon girdiniz")]
        [Display(Name = "Telefon 1")]
        public string Telephone1 { get; set; }

        [Phone(ErrorMessage = "Yanlış formatta telefon girdiniz")]
        [Display(Name = "Telefon 2")]
        public string Telephone2 { get; set; }

        [Phone(ErrorMessage = "Yanlış formatta telefon girdiniz")]
        [Display(Name = "Cep Telefonu")]
        public string MobilePhone { get; set; }

        [Phone(ErrorMessage = "Yanlış formatta telefon girdiniz")]
        [Display(Name = "FAx")]
        public string Fax { get; set; }

        [EmailAddress(ErrorMessage = "Yanlış formatta email adresi girdiniz")]
        [Display(Name = "İletişim Mail Adresi")]
        public string InformationMailAddress { get; set; }

        [EmailAddress(ErrorMessage = "Yanlış formatta email adresi girdiniz")]
        [Display(Name = "Destek Mail Adresi")]
        public string SupportMailAddress { get; set; }

        [EmailAddress(ErrorMessage = "Yanlış formatta email adresi girdiniz")]
        [Display(Name = "SAtış Mail Adresi")]
        public string SaleMailAddress { get; set; }
    }
}
