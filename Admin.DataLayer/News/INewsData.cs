using Admin.Entity;
using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface INewsData
    {
        List<DuyuruHaber> GetNews();

        void UpdateNews(DuyuruHaber news);

        void SaveNews(DuyuruHaber news);

        void DeleteNews(int newsId);
    }
}
