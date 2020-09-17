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

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    public class VolunteerController : BaseController
    {
        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
        // GET: Admin/Volunteer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var model = new VolunteerDao().ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Volunteer volunteer)
        {
            var dao = new VolunteerDao();
            long id = dao.Insert(volunteer);
            if (id > 0)
            {
                SetAlert("Thêm tình nguyện viên thành công", "success");
                return RedirectToAction("Index", "Volunteer");
            }
            else
            {
                ModelState.AddModelError("", "Thêm tình nguyện viên không thành công");
            }
            SetViewBag(volunteer.CreatedBy);
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var volunteer = new VolunteerDao().ViewDetail(id);
            SetViewBag();
            return View(volunteer);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Volunteer volunteer, string Status)
        {
            //if (Status == "on")
            //    volunteer.Status = true;
            //else
            //    volunteer.Status = false;
            var dao = new VolunteerDao();
            var result = dao.Update(volunteer);
            if (result)
            {
                SetAlert("Sửa tình nguyện viên thành công", "success");
                return RedirectToAction("Index", "Volunteer");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật tình nguyện viên không thành công");
            }
            SetViewBag(volunteer.ModifiedBy);
            return View();
        }
        [HttpPost]
        public void Delete(int id)
        {
            try
            {
                new VolunteerDao().Delete(id);
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
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }
        public void SetViewBag(string selectedID = null)
        {
            var dao = new UserDao();
            ViewBag.UserID = new SelectList(dao.ListAll(), "Name", "Name", selectedID);
        }
        //public JsonResult ChangeStatus(long id)
        //{
        //    var result = new VolunteerDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}