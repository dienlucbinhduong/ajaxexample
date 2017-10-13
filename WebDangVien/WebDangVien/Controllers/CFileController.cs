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

namespace WebDangVien.Controllers
{    
    public class CFileController : Controller
    {
        DangVienDBContext db = new DangVienDBContext();
        // GET: CFile        
        public ActionResult Index(string searchString, int? page)
        {
            int pageNumber = (page ?? 1); // Nếu số dòng < pageSize thì mặc định là 1
            int pageSize = 1; //Số dòng trên 1 trang

            ViewBag.SearchString = searchString; //Truyền giá trị searchString vào View để hiển thị trên text tìm kiếm sau khi tìm kiếm
           
            var iplCFile= new CFileModel();
            //var lst= iplCFile.getAll(searchString).Where()
            var model = iplCFile.getAll(searchString).OrderBy(m=>m.mahoso).ToPagedList(pageNumber, pageSize);                      
            //Cout CFile
            //ViewBag.CountCFile = iplCFile.getAll().Count;
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
            if (CPicture!=null)
            {
                strBase64 = Convert.ToBase64String(CPicture);                
            }

            return strBase64;
        }      

        [ChildActionOnly]
        public PartialViewResult _LeftMenu()
        {
            var iplDivision=new DivisionModel();
            var model = iplDivision.getAll();
            return PartialView(model);

            //var iplCFile = new CFileModel();           
            ////Cout CFile
            //ViewBag.CountCFile = iplCFile.getAll().Count;
        }      

        public string countCFilebyDivision(int devisionid)
        {
            var cfile=new CFileModel();
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