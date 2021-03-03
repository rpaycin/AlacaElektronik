using Admin.DataLayer.LoginData;
using Admin.Entity;

namespace Admin.BusinessLayer.Login
{
    public class LoginBusiness:ILoginBusiness
    {
        private readonly ILoginData _loginData;

        public LoginBusiness()
        {
            _loginData = new LoginData();
        }

        public Response LoginControl(User user)
        {
            return _loginData.LoginControl(user);
        }
    }
}
