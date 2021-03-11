using Admin.DataLayer;
using Admin.DataLayer.Helper;
using Admin.DataLayer.LoginData;
using Admin.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Admin.Models.Helper;

namespace Alaca.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductGroupData _productGroupData;
        private readonly IProductData _productData;

        public ProductController()
        {
            _productGroupData = new ProductGroupData();
            _productData = new ProductData();
        }

        public ActionResult Index()
        {
            List<UrunGrup> dbProductGroups = _productGroupData.GetProductGroups();

            List<Urun> dbProducts = _productData.GetProducts();

            var products = new List<Product>();
            var productGroups = new List<ProductGroup>();

            foreach (var dbUrunGrup in dbProductGroups)
            {
                var productGroup = Converter.Convert<UrunGrup, ProductGroup>(dbUrunGrup);

                var productMainGroup = productGroups.FirstOrDefault(pg => pg.UrunGrupId == productGroup.AnaGrupId);

                if (productMainGroup != null)
                {
                    productGroup.AnaGrupAdi = productMainGroup.UrunGrupAdi;
                }

                productGroups.Add(productGroup);
            }

            foreach (var dbUrun in dbProducts)
            {
                var product = Converter.Convert<Urun, Product>(dbUrun);

                if (productGroups != null && productGroups.Count > 0)
                {
                    var productGroup = productGroups.FirstOrDefault(pg => pg.UrunGrupId == product.FKUrunGrupId);

                    if (productGroup != null)
                    {
                        product.UrunGrupText = productGroup.UrunGrupAdi;
                    }
                }

                products.Add(product);
            }

            var productControllerModel = new ProductControllerModel
            {
                Products = products,
                ProductGroups = productGroups
            };

            return View(productControllerModel);
        }

        [HttpPost]
        public JsonResult UpdateProduct(Urun urun)
        {
            _productData.UpdateProduct(urun);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveProduct(Urun urun)
        {
            if (Session[Constants.SessionInformation] != null)
            {
                var user = (User)Session[Constants.SessionInformation];
                urun.CreateUser = user.Id;
            }

            _productData.SaveProduct(urun);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteProduct(Urun urun)
        {
            _productData.DeleteProduct(urun.UrunId);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProductGroup(UrunGrup urunGrup)
        {
            _productGroupData.UpdateProductGroup(urunGrup);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveProductGroup(UrunGrup urunGrup)
        {
            if (Session[Constants.SessionInformation] != null)
            {
                var user = (User)Session[Constants.SessionInformation];
                urunGrup.CreateUser = user.Id;
            }

            _productGroupData.SaveProductGroup(urunGrup);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteProductGroup(UrunGrup urunGrup)
        {
            _productGroupData.DeleteProductGroup(urunGrup.UrunGrupId);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

    }
}