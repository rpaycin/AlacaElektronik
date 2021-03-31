using Admin.Entity;
using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface IProductGroupData
    {
        List<UrunGrup> GetProductGroups();

        void UpdateProductGroup(UrunGrup urunGrup);

        void SaveProductGroup(UrunGrup urunGrup);

        void DeleteProductGroup(int ProductGroupId);

        List<UrunGrup> GetProductMainGroups();

        List<UrunGrup> GetProductSubGroups(int mainGroupId);
    }
}
