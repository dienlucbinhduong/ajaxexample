using DVModels.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVModels.DATAVIEW;
namespace DVModels.DAO
{    
    public class CFileModel
    {
        private DangVienDBContext db = null;
        public CFileModel()
        {
            db = new EF.DangVienDBContext();
        }
        public List<DangVien> getAll(string searchString)
        {
            //Lay danh sach dang vien
            //var list= db.Database.SqlQuery<CFile>("uspCFileSelectAll").ToList();           
            
            //Lay tat ca thong tin lien quan den dang vien
            var model = from a in db.CFiles
                        join b in db.Units
                        on a.UnitID equals b.UnitID
                        join c in db.Divisions
                        on b.DivisionID equals c.DivisionID
                        join d in db.CStatus
                        on a.CStatusID equals d.CStatusID
                        select new DangVien()
                        {
                            mahoso = a.CFileID,
                            hoten = a.FullName,
                            ngaysinh = a.Birthday,
                            gioitinh = a.Sex,
                            chucvuchuyenmon=a.JobTitle,
                            chucvudang=a.CRole,
                            trinhdochuyenmon=a.Qualification,
                            malyluan=0,
                            trinhdolyluan="",
                            quequan=a.Native,
                            ngaydubi=a.AdmittedDate,
                            ngaychinhthuc=a.OfficialDate,
                            sothedang=a.CardNumber,
                            solylich=a.BioNumber,
                            yeutonuocngoai=a.Foreigners,
                            thongtinchinhtrinoibo=a.InternalInfo,
                            madonvi=a.UnitID,
                            tendonvi=b.UnitName,
                            machibo=b.DivisionID,
                            tenchibo=c.DivisionName,
                            ngaycapnhat=a.ModifiedDate,
                            matrangthai=a.CStatusID,
                            tentrangthai=d.CStatusInfo,
                            ghichu=a.CFileDescription,
                            hinh=a.CPicture
                        };
            var lstDangvien = model.ToList();
            if(!string.IsNullOrEmpty(searchString))
            {                
                lstDangvien=lstDangvien.Where(p => p.hoten.ToUpper().Contains(searchString.ToUpper()) || p.hoten.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            return lstDangvien;
        }
        public List<CFile> getAll()
        {
            var list = db.Database.SqlQuery<CFile>("uspCFileSelectAll").ToList();           
            return list;
        }
        //public IEnumerable<CFile> listAll()
        //{
        //    return db.CFiles;
        //}
    }
}
