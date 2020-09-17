using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Configuration;
//using Common;

namespace Model.DAO
{
    public class SuppliesEquipmentDao
    {
        MaiAmTruyenTinDbContext db = null;
        public SuppliesEquipmentDao()
        {
            db = new MaiAmTruyenTinDbContext();
        }
        public int Insert(SuppliesEquipment entity)
        {
            //Tạo mới tham số người dùng: entity 
            db.SuppliesEquipments.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(SuppliesEquipment entity)
        {
            try
            {
                var suppliesequipment = db.SuppliesEquipments.Find(entity.ID);
                suppliesequipment.Name = entity.Name;
                suppliesequipment.Number = entity.Number;
                suppliesequipment.BrokenNumber = entity.BrokenNumber;
                suppliesequipment.Manager = entity.Manager;
                suppliesequipment.UsageHistory = entity.UsageHistory;
                suppliesequipment.Description = entity.Description;
                suppliesequipment.CreatedDate = entity.CreatedDate;
                suppliesequipment.CreatedBy = entity.CreatedBy;
                suppliesequipment.ModifiedDate = entity.ModifiedDate;
                suppliesequipment.ModifiedBy = entity.ModifiedBy;
                suppliesequipment.Status = entity.Status;
                db.Entry(suppliesequipment).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }
        public IEnumerable<SECategory> ListAll()
        {
            return db.SECategories.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<SuppliesEquipment> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<SuppliesEquipment> model = db.SuppliesEquipments;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public SuppliesEquipment GetByID(string suppliesequipment)
        {
            return db.SuppliesEquipments.SingleOrDefault(x => x.Name == suppliesequipment);
        }
        public SuppliesEquipment ViewDetail(int id)
        {
            var suppliesequipment = db.SuppliesEquipments.Find(id);
            return db.SuppliesEquipments.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var suppliesequipment = db.SuppliesEquipments.Find(id);
            suppliesequipment.Status = !suppliesequipment.Status;
            db.SaveChanges();
            return suppliesequipment.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var suppliesequipment = db.SuppliesEquipments.Find(id);
                db.SuppliesEquipments.Remove(suppliesequipment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        //public bool CheckUserName(string suppliesequipment)
        //{
        //    return db.SuppliesEquipments.Count(x => x.UserName == suppliesequipment) > 0;
        //}
        //public bool CheckEmail(string email)
        //{
        //    return db.SuppliesEquipments.Count(x => x.Email == email) > 0;
        //}
    }
}
