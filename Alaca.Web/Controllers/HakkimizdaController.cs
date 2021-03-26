using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Web.Mvc;

namespace Alaca.Web.Controllers
{
    public class HakkimizdaController : Controller
    {
        private readonly IFirmsData _firmsData;

        public HakkimizdaController()
        {
            _firmsData = new FirmsData();
        }

        public ActionResult Index()
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var layoutModel = new LayoutModel(firm);

            return View(layoutModel);
        }
    }
}