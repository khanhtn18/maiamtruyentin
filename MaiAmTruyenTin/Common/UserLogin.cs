using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaiAmTruyenTin.Common
{
    [Serializable] //Tuần tự hóa lưu trữ - tái tạo đối tượng
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
    }
}