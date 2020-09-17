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
//    public class RegulationController : BaseController
//    {
//        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
//        // GET: Admin/Regulation
//        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
//        {
//            var model = new RegulationDao().ListAllCategory(searchString, page, pageSize);
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
//        public ActionResult Create(Regulation regulation)
//        {
//            var dao = new RegulationDao();
//            long id = dao.Insert(regulation);
//            if (id > 0)
//            {
//                SetAlert("Thêm quy định thành công", "success");
//                return RedirectToAction("Index", "Regulation");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Thêm quy định không thành công");
//            }
//            SetViewBag(regulation.CategoryID);
//            return View("Index");
//        }
//        [HttpGet]
//        public ActionResult Edit(int id)
//        {
//            var regulation = new RegulationDao().ViewDetail(id);
//            SetViewBag();
//            return View(regulation);
//        }
//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Edit(Regulation regulation, string Status)
//        {
//            if (Status == "on")
//                regulation.Status = "1";
//            else
//                regulation.Status = "2";
//            var dao = new RegulationDao();
//            var result = dao.Update(regulation);
//            if (result)
//            {
//                SetAlert("Sửa quy định thành công", "success");
//                return RedirectToAction("Index", "Regulation");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Cập nhật quy định không thành công");
//            }
//            SetViewBag(regulation.CategoryID);
//            return View();
//        }
//        [HttpPost]
//        public void Delete(int id)
//        {
//            try
//            {
//                new RegulationDao().Delete(id);
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
//            Regulation regulation = db.Regulations.Find(id);
//            if (regulation == null)
//            {
//                return HttpNotFound();
//            }
//            return View(regulation);
//        }
//        public void SetViewBag(long? selectedID = null)
//        {
//            var dao = new RegulationDao();
//            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
//        }
//        public JsonResult ChangeStatus(long id)
//        {
//            var result = new RegulationDao().ChangeStatus(id);
//            return Json(new
//            {
//                status = result
//            });
//        }
//    }
//}