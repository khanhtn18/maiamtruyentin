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
    public class SuppliesEquipmentController : BaseController
    {
        // GET: Admin/SuppliesEquipment
        private MaiAmTruyenTinDbContext db = new MaiAmTruyenTinDbContext();
        // GET: Admin/SuppliesEquipment
        // Chức năng tìm kiếm và phân trang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SuppliesEquipmentDao();
            //Phân trang
            var model = dao.ListAllPaging(searchString, page, pageSize);
            //Tìm kiếm
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagCreatedBy();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SuppliesEquipment suppliesequipment)
        {
            // Xác thực dữ liệu
            if (ModelState.IsValid)
            {
                //Tạo mới đối tượng truy cập dữ liệu
                var dao = new SuppliesEquipmentDao();
                int id = dao.Insert(suppliesequipment);
                if (id > 0)
                {
                    SetAlert("Thêm thiết bị vật tư thành công", "success");
                    return RedirectToAction("Index", "SuppliesEquipment");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thiết bị vật tư không thành công");
                }
            }
            SetViewBagCreatedBy(suppliesequipment.CreatedBy);
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var suppliesequipment = new SuppliesEquipmentDao().ViewDetail(id);
            SetViewBagCreatedBy();
            return View(suppliesequipment);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SuppliesEquipment suppliesequipment, string Status)
        {
            if (Status == "on")
                suppliesequipment.Status = true;
            else
                suppliesequipment.Status = false;
            var dao = new SuppliesEquipmentDao();
            //if (!string.IsNullOrEmpty(suppliesequipment.Password))
            //{
            //    var encryptedMd5Pas = Encryptor.MD5Hash(suppliesequipment.Password);
            //    suppliesequipment.Password = encryptedMd5Pas;
            //}
            var result = dao.Update(suppliesequipment);
            if (result)
            {
                SetAlert("Sửa thiết bị vật tư thành công", "success");
                return RedirectToAction("Index", "SuppliesEquipment");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thiết bị vật tư không thành công");
            }
            SetViewBagCreatedBy(suppliesequipment.ModifiedBy);
            return View("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            new SuppliesEquipmentDao().Delete(id);
            return RedirectToAction("Index", "SupplieEquipment");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppliesEquipment suppliesequipment = db.SuppliesEquipments.Find(id);
            if (suppliesequipment == null)
            {
                return HttpNotFound();
            }
            return View(suppliesequipment);
        }
        public void SetViewBagCreatedBy(string selectedID = null)
        {
            var dao = new UserDao();
            ViewBag.UserID = new SelectList(dao.ListAll(), "Name", "Name", selectedID);
        }
        //[HttpPost]
        //public JsonResult ChangeStatus(long id)
        //{
        //    var result = new SuppliesEquipmentDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}

    }
}