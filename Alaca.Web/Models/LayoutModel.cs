using Admin.DataLayer;

namespace Alaca.Web.Models
{
    public class LayoutModel
    {
        public FirmaBilgileri Firm { get; set; }

        public LayoutModel(FirmaBilgileri firm)
        {
            Firm = firm;
        }
    }

    public class LayoutModel<T> : LayoutModel
    {
        public LayoutModel(T pageModel, FirmaBilgileri firm) : base(firm)
        {
            PageModel = pageModel;
        }

        public T PageModel { get; }
    }
}