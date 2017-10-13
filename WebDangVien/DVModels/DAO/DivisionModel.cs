using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVModels.EF;

namespace DVModels.DAO
{
    public class DivisionModel
    {
        private DangVienDBContext context = null;
        public DivisionModel()
        {
            context = new DangVienDBContext();
        }
        public List<Division> getAll()
        {
            return context.Database.SqlQuery<Division>("uspDivisionSelectAll").ToList();
        }

    }
}
