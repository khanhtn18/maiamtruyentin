using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MaiAmTruyenTin.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập User Name")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mời nhập Password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}