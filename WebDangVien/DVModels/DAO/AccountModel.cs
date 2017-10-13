using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVModels.EF;
using System.Data.SqlClient;
using WebDangVien.Code;

namespace DVModels.DAO
{  
    public class AccountModel
    {
        private DangVienDBContext db = null;
        public AccountModel(){
            db = new DangVienDBContext();
        }
        public List<MyUser> getAll()
        {
            var list = db.Database.SqlQuery<MyUser>("uspMyUserSelectAll").ToList();
            return list;
        }
        public bool Login (string userName, string passWord)
        {          
            var user = db.Database.SqlQuery<MyUser>("uspMyUserSelectAll").ToList().Where(p => p.LogIn.ToLower() == userName.ToLower() && Decrypt.DecryptPassword(p.Pass, "22121980") == passWord).SingleOrDefault();
            if (user != null)           
                return true;            
            else
                return false;
            
        }
    }
}
