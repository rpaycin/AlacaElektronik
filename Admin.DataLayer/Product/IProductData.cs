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
    }
}
