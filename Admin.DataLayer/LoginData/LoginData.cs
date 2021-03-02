using System.Collections.Generic;
using Admin.DataLayer.Helper;
using System;
using System.Linq;
using Admin.Entity;

namespace Admin.DataLayer.LoginData
{
    public class LoginData : ILoginData
    {
        public Response LoginControl(Entity.User user)
        {
            try
            {
                using (CreativeSolutionsAdminEntities entities = new CreativeSolutionsAdminEntities())
                {
                    User cUser = entities.User.FirstOrDefault(l => l.EmailAddress == user.EmailAddress && l.Password == user.Password);
                    if (cUser == null)
                        return MakeResponse.CreateErrorResponse("Kullanıcı bulunamadı!");

                    user = Converter.Convert<User, Entity.User>(cUser);
                    return MakeResponse.CreateSuccessResponse(new object[] { user });
                }
            }
            catch (Exception ex)
            {
                return MakeResponse.CreateErrorResponse(ex);
            }
        }

        public Response GetUserInfoByEmail(string emailAddress)
        {
            try
            {
                using (CreativeSolutionsAdminEntities entities = new CreativeSolutionsAdminEntities())
                {
                    User cUser = entities.User.FirstOrDefault(l => l.EmailAddress == emailAddress);
                    if (cUser == null)
                        return MakeResponse.CreateErrorResponse("Kullanıcı bulunamadı!");

                    Entity.User user = Converter.Convert<User, Entity.User>(cUser);
                    return MakeResponse.CreateSuccessResponse(new object[] { user });
                }
            }
            catch (Exception ex)
            {
                return MakeResponse.CreateErrorResponse(ex);
            }
        }
    }
}
