using Admin.Entity;
using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface IDownloadLinkData
    {
        List<DownloadLink> GetDownloadLinks();

        void UpdateDownloadLink(DownloadLink downloadLink);

        void SaveDownloadLink(DownloadLink downloadLink);

        void DeleteDownloadLink(int downloadLinkId);
    }
}
