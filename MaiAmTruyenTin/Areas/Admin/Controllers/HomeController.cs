using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Model;
//using Model.DAO;
//using Model.EF;
using System.Data;
//using System.Data.Entity;
using System.Net;
using PagedList;
using System.IO;
using System.Web.UI.HtmlControls;
//using Model.ViewModel;
using System.Web.Mvc.Ajax;

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();

        //private List<Content> GetNewContent(int count)
        //{
        //    //Sap xep giam dan theo Ngaycapnhat, lay count dong dau;
        //    return db.Contents.Where(a => a.Status == true).OrderByDescending(a => a.ID).Take(count).ToList();
        //}
        // GET: Admin/Home
        public ActionResult Index()
        {
            //var content = GetNewContent(6);
            return View(/*content*/);
        }
    }
}