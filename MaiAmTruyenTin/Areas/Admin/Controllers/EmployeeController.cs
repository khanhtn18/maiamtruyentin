//Khai báo DAO và EF trong Model
using Model.DAO;
using Model.EF;
//using Model.EF;
//Khai báo Common
using MaiAmTruyenTin.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Model;
using System.Data;
//using System.Data.Entity;
using System.Net;
using PagedList;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.WebPages;

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    public class EmployeeController : BaseController
    {
        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
        // GET: Admin/Employee
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var model = new EmployeeDao().ListAllCategory(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            SetViewBag1();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Employee employee)
        {
            var dao = new EmployeeDao();
            int id = dao.Insert(employee);
            if (id > 0)
            {
                SetAlert("Thêm trẻ thành công", "success");
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("", "Thêm trẻ không thành công");
            }
            SetViewBag(employee.Education);
            SetViewBag1(employee.CreatedBy);
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = new EmployeeDao().ViewDetail(id);    
            SetViewBag();
            SetViewBag1();
            return View(employee);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Employee employee, string Status)
        {
            if (Status == "on")
                employee.Status = true;
            else
                employee.Status = false;
            var dao = new EmployeeDao();
            var result = dao.Update(employee);
            if (result)
            {
                SetAlert("Sửa nhân viên thành công", "success");
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật nhân viên không thành công");
            }
            SetViewBag(employee.Education);
            SetViewBag1(employee.ModifiedBy);
            return View();
        }
        [HttpPost]
        public void Delete(int id)
        {
            try
            {
                new EmployeeDao().Delete(id);
            }
            catch
            {

            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetViewBag();
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        public void SetViewBag(int? selectedID = null)
        {
            var dao = new EducationDao();
            ViewBag.Education = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
        public void SetViewBag1(string selectedID = null)
        {
            var dao = new UserDao();
            ViewBag.UserID = new SelectList(dao.ListAll(), "Name", "Name", selectedID);
        }
        //public JsonResult ChangeStatus(long id)
        //{
        //    var result = new EmployeeDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}