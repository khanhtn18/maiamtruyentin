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
using System.Net;
using System.Web.UI.WebControls;

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    // Dựa trên BaseController
    public class UserController : BaseController
    {
        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
        // GET: Admin/User
        // Chức năng tìm kiếm và phân trang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            //Phân trang
            var model = dao.ListAllPaging(searchString, page, pageSize);
            //Tìm kiếm
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            // Xác thực dữ liệu
            if (ModelState.IsValid)
            {
                //Tạo mới đối tượng truy cập dữ liệu
                var dao = new UserDao();
                //Mã hóa password
                //var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                //user.Password = encryptedMd5Pas;

                int id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(User user, string Status)
        {
            if (Status == "on")
                user.Status = true;
            else
                user.Status = false;
            var dao = new UserDao();
            //if (!string.IsNullOrEmpty(user.Password))
            //{
            //    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
            //    user.Password = encryptedMd5Pas;
            //}
            var result = dao.Update(user);
            if (result)
            {
                SetAlert("Sửa user thành công", "success");
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật user không thành công");
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index", "User");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        //[HttpPost]
        //public JsonResult ChangeStatus(long id)
        //{
        //    var result = new UserDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}