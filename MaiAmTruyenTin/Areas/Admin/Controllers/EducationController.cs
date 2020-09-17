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
namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    // Dựa trên BaseController
    public class EducationController : BaseController
    {
        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
        // GET: Admin/Education
        // Chức năng tìm kiếm và phân trang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new EducationDao();
            //Phân trang
            var model = dao.ListAllPaging(searchString, page, pageSize);
            //Tìm kiếm
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Education education)
        {
            // Xác thực dữ liệu
            if (ModelState.IsValid)
            {
                //Tạo mới đối tượng truy cập dữ liệu
                var dao = new EducationDao();
                //Mã hóa password
                //var encryptedMd5Pas = Encryptor.MD5Hash(education.Password);
                //education.Password = encryptedMd5Pas;

                int id = dao.Insert(education);
                if (id > 0)
                {
                    SetAlert("Thêm loại học vấn thành công", "success");
                    return RedirectToAction("Index", "Education");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm loại học vấn không thành công");
                }
            }
            SetViewBag(education.CreatedBy);
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            SetViewBag();
            var education = new EducationDao().ViewDetail(id);
            return View(education);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Education education, string Status)
        {
            if (Status == "on")
                education.Status = true;
            else
                education.Status = false;
            var dao = new EducationDao();
            //if (!string.IsNullOrEmpty(education.Password))
            //{
            //    var encryptedMd5Pas = Encryptor.MD5Hash(education.Password);
            //    education.Password = encryptedMd5Pas;
            //}
            var result = dao.Update(education);
            if (result)
            {
                SetAlert("Sửa loại học vấn thành công", "success");
                return RedirectToAction("Index", "Education");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật loại học vấn không thành công");
            }
            SetViewBag(education.ModifiedBy);
            return View("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            new EducationDao().Delete(id);
            return RedirectToAction("Index", "Education");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }
        public void SetViewBag(string selectedID = null)
        {
            var dao = new UserDao();
            ViewBag.UserID = new SelectList(dao.ListAll(), "Name", "Name", selectedID);
        }
        //[HttpPost]
        //public JsonResult ChangeStatus(long id)
        //{
        //    var result = new EducationDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}