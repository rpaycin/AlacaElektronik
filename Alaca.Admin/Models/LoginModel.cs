using Admin.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AdminWebPanel.Models
{
    public class LoginModel : BaseModel
    {
        public bool IsValid { get; set; }
        public User User { get; set; }
    }
}