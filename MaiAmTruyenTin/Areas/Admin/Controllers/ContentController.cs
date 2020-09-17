//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using MaiAmTruyenTin.Common;
//using Model;
//using Model.DAO;
//using Model.EF;
//using System.Data;
////using System.Data.Entity;
//using System.Net;
//using PagedList;
//using System.IO;
//using System.Web.UI.HtmlControls;
//using Model.ViewModel;
//using System.Web.Mvc.Ajax;

//namespace MaiAmTruyenTin.Areas.Admin.Controllers
//{
//    public class ContentController : BaseController
//    {
//        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
//        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
//        {
//            var model = new ContentDao().ListAllCategory(searchString, page, pageSize);
//            ViewBag.SearchString = searchString;
//            return View(model);
//        }
//        [HttpGet]
//        public ActionResult Create()
//        {
//            SetViewBag();
//            return View();
//        }
//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Create(Content entity)
//        {
//            //Tạo mới dối tượng truy cập dữ liệu
//            var dao = new ContentDao();
//            long id = dao.Insert(entity);
//            if (id > 0)
//            {
//                SetAlert("Thêm tin tức thành công", "success");
//                return RedirectToAction("Index", "Content");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Thêm loại tin không thành công");
//            }
//            SetViewBag(entity.CategoryID);
//            return View("Index");
//        }
//        [HttpGet]
//        public ActionResult Edit(int id)
//        {
//            var content = new ContentDao().ViewDetail(id);
//            SetViewBag();
//            return View(content);
//        }
//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Edit(Content content, string Status)
//        {
//            if (Status == "on")
//                content.Status = true;
//            else
//                content.Status = false;
//            var dao = new ContentDao();
//            var result = dao.Update(content);
//            if (result)
//            {
//                SetAlert("Sửa tin tức thành công", "success");
//                return RedirectToAction("Index", "Content");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Cập nhật tin tức không thành công");
//            }
//            SetViewBag(content.CategoryID);
//            return View("Index");
//        }
//        [HttpPost]
//        public void Delete(int id)
//        {
//            try
//            {
//                new ContentDao().Delete(id);
//            }
//            catch
//            {

//            }
//        }
//        [HttpPost]
//        public JsonResult ChangeStatus(long id)
//        {
//            var result = new ContentDao().ChangeStatus(id);
//            return Json(new
//            {
//                status = result
//            });
//        }
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            SetViewBag();
//            Content content = db.Contents.Find(id);
//            if (content == null)
//            {
//                return HttpNotFound();
//            }
//            return View(content);
//        }
//        public void SetViewBag(long? selectedID = null)
//        {
//            var dao = new ContentDao();
//            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
//        }

//    }
//}