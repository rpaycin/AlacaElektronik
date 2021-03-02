using System;
using System.Linq;
using Admin.Entity;
using Admin.DataLayer.LookupListData;

namespace Admin.BusinessLayer.LookupList
{
    public class LookupListBusiness : ILookupListBusiness
    {
        private readonly ILookupListData _lookupListData;

        public LookupListBusiness()
        {
            _lookupListData=new LookupListData();
        }

        public Response GetFirmList()
        {
            return _lookupListData.GetFirmList();
        }
    }
}
