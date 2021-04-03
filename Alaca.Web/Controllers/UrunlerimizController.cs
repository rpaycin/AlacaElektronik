using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;
using System.Linq;
using Alaca.Web.Helper;

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

        [HttpPost]
        public JsonResult GetProducts()
        {
            NameValueCollection form = HttpContext.Request.Form;

            int subMainGroupId = Convert.ToInt32(form["SubMainGroupId"]);
            List<Urun> products = _productData.GetSubProducts(subMainGroupId);

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAdditionalProducts()
        {
            NameValueCollection form = HttpContext.Request.Form;

            int subMainGroupId = Convert.ToInt32(form["SubMainGroupId"]);
            int productId = Convert.ToInt32(form["ProductId"]);

            List<Urun> products = _productData.GetSubProducts(subMainGroupId);
            Urun product = products.FirstOrDefault(p => p.UrunId == productId);

            List<Urun> productAdditionals = new List<Urun> { product };
            List<Urun> dbAdditionalProducts = _productData.GetSubAdditionalProducts(subMainGroupId, productId);
            productAdditionals.AddRange(dbAdditionalProducts);

            return Json(productAdditionals, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult SendEmail()
        {
            NameValueCollection form = HttpContext.Request.Form;

            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            string body = form["Body"];
            EmailSender.Send("Alaca Yazılım - Talep Formu", body, form["EPosta"]);

            string satisBody = string.Format("Ad Soyad:{0}, Firma Adı:{1}, Eposta:{2}, Telefon:{3} <br/> {4}", form["AdSoyad"], form["FirmaAdi"], form["EPosta"], form["Telefon"], body);
            EmailSender.Send("Alaca Yazılım - Talep Formu", satisBody, firm.SatisMail);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}