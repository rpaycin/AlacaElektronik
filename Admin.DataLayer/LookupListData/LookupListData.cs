using System;
using System.Collections.Generic;
using System.Linq;
using Admin.DataLayer.Helper;
using Admin.Entity;

namespace Admin.DataLayer.LookupListData
{
    public class LookupListData : ILookupListData
    {
        public Response GetFirmList()
        {
            try
            {
                using (CreativeSolutionsAdminEntities entities = new CreativeSolutionsAdminEntities())
                {
                    List<OptionList> listOption = new List<OptionList>();
                    entities.Firm.ToList().ForEach(f => listOption.Add(Converter.Convert<Firm, OptionList>(f)));
                    return MakeResponse.CreateSuccessResponse(new object[] { listOption });
                }
            }
            catch (Exception ex)
            {
                return MakeResponse.CreateErrorResponse(ex);
            }
        }
    }
}
