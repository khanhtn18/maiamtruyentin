//Khai báo DAO và EF trong Model
using Model.DAO;
using Model.EF;
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
using System.Data.Entity;
using System.Net;
using PagedList;
using System.IO;
using System.Web.UI.HtmlControls;


namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    public class ChildrenController : BaseController
    {
        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
        // GET: Admin/Children
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var model = new ChildrenDao().ListAllCategory(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            SetViewBagEducation();
            SetViewBagCreatedBy();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Children children)
        {
            var dao = new ChildrenDao();
            int id = dao.Insert(children);
            if (id > 0)
            {
                //SetAlert("Thêm đối tượng thành công", "success");
                return RedirectToAction("Index", "Children");
            }
            else
            {
                ModelState.AddModelError("", "Thêm đối tượng không thành công");
            }
            SetViewBagEducation(children.EducationID);
            SetViewBag(children.CategoryID);
            SetViewBagCreatedBy(children.CreatedBy);
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var children = new ChildrenDao().ViewDetail(id);
            SetViewBag();
            SetViewBagEducation();
            SetViewBagCreatedBy();
            return View(children);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Children children, string Status)
        {
            if (Status == "on")
                children.Status = true;
            else
                children.Status = false;
            var dao = new ChildrenDao();
            var result = dao.Update(children);
            if (result)
            {
                SetAlert("Sửa đối tượng thành công", "success");
                return RedirectToAction("Index", "Children");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thông tin trẻ không thành công");
            }
            SetViewBagEducation(children.EducationID);
            SetViewBag(children.CategoryID);
            SetViewBagCreatedBy(children.ModifiedBy);
            return View();
        }
        [HttpPost]
        public void Delete(int id)
        {
            try
            {
                new ChildrenDao().Delete(id);
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
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }
        public void SetViewBag(int? selectedID = null)
        {
            var dao = new ChildrenCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
        public void SetViewBagEducation(string selectedID = null)
        {
            var dao = new EducationDao();
            ViewBag.EducationName = new SelectList(dao.ListAll(), "Name", "Name", selectedID);
        }
        public void SetViewBagCreatedBy(string selectedID = null)
        {
            var dao = new UserDao();
            ViewBag.UserID = new SelectList(dao.ListAll(), "Name", "Name", selectedID);
        }


        //public JsonResult ChangeStatus(long id)
        //{
        //    var result = new ChildrenDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}