using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVModels.DATAVIEW
{
    public class DangVien
    {
        public int mahoso { set; get; }
        public string hoten { set; get; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaysinh { get; set; }
        public bool? gioitinh { get; set; }       
        public string chucvuchuyenmon { get; set; }       
        public string chucvudang { get; set; }
        public string trinhdochuyenmon { get; set; }
        public int? malyluan { get; set; }
        public string trinhdolyluan { set; get; }
        public string quequan { get; set; }      
        public DateTime? ngaydubi { get; set; }        
        public DateTime? ngaychinhthuc { get; set; }        
        public string sothedang { get; set; }       
        public string solylich { get; set; }        
        public string yeutonuocngoai { get; set; }        
        public string thongtinchinhtrinoibo { get; set; }
        public int? madonvi { get; set; }
        public string tendonvi { set; get; }
        public int? machibo { set; get; }
        public string tenchibo { set; get; }
        public DateTime? ngaycapnhat { get; set; }
        public int? matrangthai { get; set; }
        public string tentrangthai { set; get; }       
        public string ghichu { get; set; }
        public bool? khoa { get; set; }       
        public byte[] hinh { get; set; }
    }
}
