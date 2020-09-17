////Khai báo DAO và EF trong Model
//using Model.DAO;
//using Model.EF;
////using Model.EF;
////Khai báo Common
//using MaiAmTruyenTin.Common;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Xml.Linq;
//using Model;
//using System.Data;
////using System.Data.Entity;
//using System.Net;
//using PagedList;
//using System.IO;
//using System.Web.UI.HtmlControls;

//namespace MaiAmTruyenTin.Areas.Admin.Controllers
//{
//    public class DocumentController : BaseController
//    {
//        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
//        // GET: Admin/Document
//        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
//        {
//            var model = new DocumentDao().ListAllCategory(searchString, page, pageSize);
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
//        public ActionResult Create(Document document)
//        {
//            var dao = new DocumentDao();
//            long id = dao.Insert(document);
//            if (id > 0)
//            {
//                SetAlert("Thêm văn bản mẫu thành công", "success");
//                return RedirectToAction("Index", "Document");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Thêm văn bản mẫu không thành công");
//            }
//            SetViewBag(document.CategoryID);
//            return View("Index");
//        }
//        [HttpGet]
//        public ActionResult Edit(int id)
//        {
//            var document = new DocumentDao().ViewDetail(id);
//            SetViewBag();
//            return View(document);
//        }
//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Edit(Document document, string Status)
//        {
//            if (Status == "on")
//                document.Status = "1";
//            else
//                document.Status = "1";
//            var dao = new DocumentDao();
//            var result = dao.Update(document);
//            if (result)
//            {
//                SetAlert("Sửa văn bản mẫu thành công", "success");
//                return RedirectToAction("Index", "Document");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Cập nhật văn bản mẫu không thành công");
//            }
//            SetViewBag(document.CategoryID);
//            return View();
//        }
//        [HttpPost]
//        public void Delete(int id)
//        {
//            try
//            {
//                new DocumentDao().Delete(id);
//            }
//            catch
//            {

//            }
//        }
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            SetViewBag();
//            Document document = db.Documents.Find(id);
//            if (document == null)
//            {
//                return HttpNotFound();
//            }
//            return View(document);
//        }
//        public void SetViewBag(long? selectedID = null)
//        {
//            var dao = new DocumentDao();
//            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
//        }
//        public JsonResult ChangeStatus(long id)
//        {
//            var result = new DocumentDao().ChangeStatus(id);
//            return Json(new
//            {
//                status = result
//            });
//        }
//    }
//}