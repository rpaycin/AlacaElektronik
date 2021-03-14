using Admin.Entity;
using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface ICustomerWritingData
    {
        List<MusteriYazi> GetCustomerWritings();

        void UpdateCustomerWriting(MusteriYazi customerWriting);

        void SaveCustomerWriting(MusteriYazi customerWriting);

        void DeleteCustomerWriting(int customerWritingId);
    }
}
