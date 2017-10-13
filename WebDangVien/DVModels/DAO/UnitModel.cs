using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVModels.EF;
using System.Data.SqlClient;

namespace DVModels.DAO
{
    public class UnitModel
    {
        DangVienDBContext db = null;
        public UnitModel()
        {
            db = new DangVienDBContext();
        }
        public List<Unit> getUnitbyUnitId(int unitId)
        {
            var prm = new SqlParameter("@parameter1", unitId);
            var list = db.Database.SqlQuery<Unit>("uspUnitSelectByID @parameter1", prm).ToList();
            return list;
        }
    }
}
