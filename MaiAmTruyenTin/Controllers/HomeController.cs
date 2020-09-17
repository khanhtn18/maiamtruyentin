using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaiAmTruyenTin.Common;
using Model;
using Model.DAO;
using Model.EF;
using System.Data;
//using System.Data.Entity;
using System.Net;
using PagedList;
using System.IO;
using System.Web.UI.HtmlControls;

namespace MaiAmTruyenTin.Controllers
{
    public class HomeController : Controller
    {
        MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
        public ActionResult Index()
        {
            var dao = new ChildrenDao();
            var model = dao.GetChildren(6);
            return View(model);
        }

        public ActionResult History()
        {
            return View();
        }

        public ActionResult Regulation()
        {
            return View();
        }
    }
}