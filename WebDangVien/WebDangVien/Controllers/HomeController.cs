using DVModels.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Drawing;
using System.IO;
using DVModels.EF;
using DVModels.DATAVIEW;
using System.Text;

namespace WebDangVien.Controllers
{
    public class HomeController : BaseController
    {
        DangVienDBContext db = new DangVienDBContext();
        // GET: CFile        
        public ActionResult Index(string searchString, int? page)
        {
            int pageNumber = (page ?? 1); // Nếu số dòng < pageSize thì mặc định là 1
            int pageSize = 6; //Số dòng trên 1 trang

            ViewBag.SearchString = searchString; //Truyền giá trị searchString vào View để hiển thị trên text tìm kiếm sau khi tìm kiếm

            var sess = (Code.UserSession)Session[Common.CommonConstants.USER_SESSION];
            ViewBag.UserName = sess.UserName;
            ViewBag.PassWord = sess.Password;

            var iplCFile = new CFileModel();
            var model = iplCFile.getAll(searchString).OrderBy(m => m.mahoso).ToPagedList(pageNumber, pageSize);

            //Lấy danh sách Chi bộ           
            var iplDivision = new DivisionModel();
            List<Division> lstCB = new List<Division>();
            lstCB = iplDivision.getAll();
            ViewBag.lstChiBo = lstCB;

            SetAlert("Đăng nhập thành công", "success");
            return View(model);
            
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Chart()
        {
            var iplCFile = new CFileModel();
            var model = iplCFile.getAll();

            //Lấy danh sách Chi bộ           
            var iplDivision = new DivisionModel();
            List<Division> lstCB = new List<Division>();
            lstCB = iplDivision.getAll();
            ViewBag.lstChiBo = lstCB;


            StringBuilder sJSON = new StringBuilder();
            string[] color = { "\"#f56954\"", "\"#00a65a\"", "\"#f39c12\"", "\"#00c0ef\"", "\"#3c8dbc\"", "\"#d2d6de\"", "\"#f56954\"", "\"#00a65a\"", "\"#f39c12\"", "\"#00c0ef\"", "\"#3c8dbc\"", "\"#d2d6de\"", "\"#f56954\"", "\"#00a65a\"", "\"#f39c12\"", "\"#00c0ef\"", "\"#3c8dbc\"", "\"#d2d6de\"" };
           // Random ran = new Random();
            sJSON.Append("[");
            int i = 0;
            foreach (var item in lstCB)
	        {                
                sJSON.Append("{" +
                  "value: "+countCFilebyDivision(item.DivisionID)+"," +
                  "color: "+color[i]+"," +
                  "highlight: "+color[i]+"," +
                  "label: \""+item.DivisionName+"\"},"); //Sử dụng dấu \" để hiển thị dấu " trong chuỗi
                i = i + 1;
	        }
              sJSON.Append("];");
            //{value: 500,color: "'#00a65a'",highlight: "'#00a65a'",label: "'IE'"}];");
                ViewBag.PieChart= sJSON;
            return View(model);
        }

        //public ActionResult CreateBase64Image(byte[] id)
        //{
        //    byte[] ndHinh = null;
        //    Image Hinh = null;
        //    //Tạo vùng nhớ để lưu hình
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    //Gán hình vào vùng nhớ ms
        //    Hinh.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //    //Gán hình vào tham số
        //    ndHinh = ms.ToArray();
        //    string strBase64 = Convert.ToBase64String(ndHinh);
        //    ViewBag.strPicture = strBase64;
        //    return View(); 
        //}

        public string CreateBase64Image(byte[] CPicture)
        {
            string strBase64 = "";
            if (CPicture != null)
            {
                strBase64 = Convert.ToBase64String(CPicture);
            }

            return strBase64;
        }
        //public string formatNgay(DateTime? ngay)
        //{            
        //    return ngay.HasValue?ngay.Value.ToString("dd/MM/yyyy"):null;
        //}

        [ChildActionOnly]
        public PartialViewResult _LeftMenu()
        {
            var iplDivision = new DivisionModel();
            var model = iplDivision.getAll();
            return PartialView(model);

            //var iplCFile = new CFileModel();           
            ////Cout CFile
            //ViewBag.CountCFile = iplCFile.getAll().Count;
        }

        public string countCFilebyDivision(int devisionid)
        {
            var cfile = new CFileModel();
            var model = from a in db.CFiles
                        join b in db.Units
                        on a.UnitID equals b.UnitID
                        join c in db.Divisions
                        on b.DivisionID equals c.DivisionID
                        where c.DivisionID == devisionid
                        select a;

            return model.Count().ToString();
        }
    }
}