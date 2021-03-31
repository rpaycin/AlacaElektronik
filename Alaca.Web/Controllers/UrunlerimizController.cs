using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;

namespace Alaca.Web.Controllers
{
    public class UrunlerimizController : Controller
    {
        private readonly IFirmsData _firmsData;
        private readonly IProductGroupData _productGroupData;
        private readonly IProductData _productData;

        public UrunlerimizController()
        {
            _firmsData = new FirmsData();
            _productGroupData = new ProductGroupData();
            _productData = new ProductData();
        }

        public ActionResult Index(string seletedTab)
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var productModel = new ProductModel
            {
                SelectedTab = seletedTab
            };

            var layoutModel = new LayoutModel<ProductModel>(productModel, firm);

            return View(layoutModel);
        }

        public ActionResult Secim()
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            List<UrunGrup> mainGroups = _productGroupData.GetProductMainGroups();

            var productChoiceModel = new ProductChoiceModel
            {
                MainGroups = mainGroups
            };

            var layoutModel = new LayoutModel<ProductChoiceModel>(productChoiceModel, firm);

            return View(layoutModel);
        }

        [HttpPost]
        public JsonResult GetMainSubGroups()
        {
            NameValueCollection form = HttpContext.Request.Form;

            int mainGroupId = Convert.ToInt32(form["MainGroupId"]);
            List<UrunGrup> mainSubGroups = _productGroupData.GetProductSubGroups(mainGroupId);

            return Json(mainSubGroups, JsonRequestBehavior.AllowGet);
        }
    }
}