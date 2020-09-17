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
//////using System.Data.Entity;
//using System.Net;
//using PagedList;
//using System.IO;
//using System.Web.UI.HtmlControls;

//namespace MaiAmTruyenTin.Areas.Admin.Controllers
//{
//    public class QuoteController : BaseController
//    {
//        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
//        // GET: Admin/Quote
//        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
//        {
//            var model = new QuoteDao().ListAllCategory(searchString, page, pageSize);
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
//        public ActionResult Create(Quote quote)
//        {
//            var dao = new QuoteDao();
//            long id = dao.Insert(quote);
//            if (id > 0)
//            {
//                SetAlert("Thêm quy định thành công", "success");
//                return RedirectToAction("Index", "Quote");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Thêm quy định không thành công");
//            }
//            SetViewBag(quote.CategoryID);
//            return View("Index");
//        }
//        [HttpGet]
//        public ActionResult Edit(int id)
//        {
//            var quote = new QuoteDao().ViewDetail(id);
//            SetViewBag();
//            return View(quote);
//        }
//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Edit(Quote quote, string Status)
//        {
//            if (Status == "on")
//                quote.Status = true;
//            else
//                quote.Status = false;
//            var dao = new QuoteDao();
//            var result = dao.Update(quote);
//            if (result)
//            {
//                SetAlert("Sửa quy định thành công", "success");
//                return RedirectToAction("Index", "Quote");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Cập nhật quy định không thành công");
//            }
//            SetViewBag(quote.CategoryID);
//            return View();
//        }
//        [HttpPost]
//        public void Delete(int id)
//        {
//            try
//            {
//                new QuoteDao().Delete(id);
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
//            Quote quote = db.Quotes.Find(id);
//            if (quote == null)
//            {
//                return HttpNotFound();
//            }
//            return View(quote);
//        }
//        public void SetViewBag(long? selectedID = null)
//        {
//            var dao = new QuoteCategoryDao();
//            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
//        }
//        public JsonResult ChangeStatus(long id)
//        {
//            var result = new QuoteDao().ChangeStatus(id);
//            return Json(new
//            {
//                status = result
//            });
//        }
//    }
//}