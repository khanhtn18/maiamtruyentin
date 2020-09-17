using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaiAmTruyenTin.Common;
using MaiAmTruyenTin.Areas.Admin.Models;
using Model;
using Model.DAO;
using Model.EF;
using System.Configuration;
using System.Xml.Linq;
using System.Net;
namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    public class ChildrenCategoryController : BaseController
    {
        // GET: Admin/ChildrenCategory
        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ChildrenCategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ChildrenCategory model)
        {
            //var dao = new ChildrenCategoryDao();
            //string id = dao.Insert(model);
            var id = new ChildrenCategoryDao().Insert(model);
            if (id > 0)
            {
                SetAlert("Thêm loại hoàn cảnh trẻ thành công", "success");
                return RedirectToAction("Index", "ChildrenCategory");
            }
            else
            {
                ModelState.AddModelError("", "Thêm loại hoàn cảnh trẻ không thành công");
            }
            SetViewBag(model.CreatedBy);
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var childrencategory = new ChildrenCategoryDao().ViewDetail(id);
            SetViewBag();
            return View(childrencategory);
        }
        [HttpPost]
        public ActionResult Edit(ChildrenCategory childrencategory)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChildrenCategoryDao();
                var result = dao.Update(childrencategory);
                if (result)
                {
                    SetAlert("Sửa thể loại trẻ thành công", "success");
                    return RedirectToAction("Index", "ChildrenCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thể loại trẻ không thành công");
                }
            }
            SetViewBag(childrencategory.ModifiedBy);
            return View();
        }
        [HttpPost]
        public void Delete(int id)
        {
            try
            {
                new ChildrenCategoryDao().Delete(id);
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
            //SetViewBag();
            ChildrenCategory childrencategory = db.ChildrenCategories.Find(id);
            if (childrencategory == null)
            {
                return HttpNotFound();
            }
            return View(childrencategory);
        }
        //public JsonResult ChangeStatus(long id)
        //{
        //    var result = new ChildrenCategoryDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
        public void SetViewBag(string selectedID = null)
        {
            var dao = new UserDao();
            ViewBag.UserID = new SelectList(dao.ListAll(), "Name", "Name", selectedID);
        }
    }
}