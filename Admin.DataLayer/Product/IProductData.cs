using Admin.Entity;
using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface IProductData
    {
        List<Urun> GetProducts();

        void UpdateProduct(Urun Urun);

        void SaveProduct(Urun Urun);

        void DeleteProduct(int urunId);

        List<Urun> GetSubProducts(int mainGroupId);

        List<Urun> GetSubAdditionalProducts(int mainGroupId, int productId);
    }
}
