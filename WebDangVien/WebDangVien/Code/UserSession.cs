using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDangVien.Code
{
    [Serializable]
    public class UserSession
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}