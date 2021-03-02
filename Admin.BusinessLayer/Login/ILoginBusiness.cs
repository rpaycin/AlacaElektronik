using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Entity;

namespace Admin.BusinessLayer.Login
{
    public interface ILoginBusiness
    {
        Response LoginControl(User user);
        Response GetUserInfoByEmail(string emailAddress);
    }
}
