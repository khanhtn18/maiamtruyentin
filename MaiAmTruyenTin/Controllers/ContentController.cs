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

//namespace MaiAmTruyenTin.Controllers
//{
//    public class ContentController : Controller
//    {
//        MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
//        // GET: Content
//        public ActionResult Index()
//        {
//            var dao = new ContentDao();
//            var model = dao.GetContent(9);
//            return View(model);
//        }
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Content content = db.Contents.Find(id);
//            if (content == null)
//            {
//                return HttpNotFound();
//            }
//            return View(content);
//        }
//    }
//}