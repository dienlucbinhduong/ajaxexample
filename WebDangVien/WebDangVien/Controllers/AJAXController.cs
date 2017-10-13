using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebDangVien.Controllers
{
    public class AJAXController : Controller
    {
        List<Models.EmployeeModel> listEmployee = new List<Models.EmployeeModel>(){
            new Models.EmployeeModel(){
                ID=1,
                Name="Nguyen Van A",
                Salary=2000000,
                Status=true
            },
            new Models.EmployeeModel(){
                ID=2,
                Name="Nguyen Van B",
                Salary=5000000,
                Status=true
            },  
            new Models.EmployeeModel(){
                ID=3,
                Name="Nguyen Van C",
                Salary=3000000,
                Status=true
            },
            new Models.EmployeeModel(){
                ID=4,
                Name="Nguyen Van I",
                Salary=2000000,
                Status=true
            },
            new Models.EmployeeModel(){
                ID=5,
                Name="Nguyen Van J",
                Salary=5000000,
                Status=true
            },  
            new Models.EmployeeModel(){
                ID=6,
                Name="Nguyen Van K",
                Salary=3000000,
                Status=true
            },
            new Models.EmployeeModel(){
                ID=7,
                Name="Nguyen Van E",
                Salary=2000000,
                Status=true
            },
            new Models.EmployeeModel(){
                ID=8,
                Name="Nguyen Van F",
                Salary=5000000,
                Status=true
            },  
            new Models.EmployeeModel(){
                ID=9,
                Name="Nguyen Van G",
                Salary=3000000,
                Status=true
            }
        };
        
        // GET: AJAX
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData(int page, int pageSize=3)
        {
            var model = listEmployee.Skip((page - 1) * pageSize).Take(pageSize); //Skip lấy từ dòng (record) thứ mấy, Take: lấy bao nhiêu record
            int totalRow = listEmployee.Count;
            return Json(new {
                data=model,
                total=totalRow,
                status=true
            }, JsonRequestBehavior.AllowGet);                
        }

        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Models.EmployeeModel employee = serializer.Deserialize<Models.EmployeeModel>(model);
            var entity = listEmployee.Single(x => x.ID == employee.ID);
            entity.Salary = employee.Salary;
            return Json(new
                {
                    status = true
                });
        }
    }
}