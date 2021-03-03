using Admin.Entity;

namespace Admin.DataLayer.LoginData
{
    public interface ILoginData
    {
        Response LoginControl(Entity.User user);
    }
}
