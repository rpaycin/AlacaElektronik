using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Alaca.Web.Controllers
{
    public class ReferansController : Controller
    {
        private readonly IFirmsData _firmsData;
        private readonly IReferenceData _referenceData;
        private readonly ICustomerWritingData _customerWritingData;

        public ReferansController()
        {
            _firmsData = new FirmsData();
            _referenceData = new ReferenceData();
            _customerWritingData = new CustomerWritingData();
        }

        public ActionResult Index()
        {
            // referans model
            List<Referans> references = _referenceData.GetTopReferences();

            List<MusteriYazi> customerWritings = _customerWritingData.GetCustomerWritings();

            var referanceModel = new ReferenceModel
            {
                References = references,
                CustomerWritings = customerWritings
            };

            //layout model
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var layoutModel = new LayoutModel<ReferenceModel>(referanceModel, firm);

            return View(layoutModel);
        }
    }
}