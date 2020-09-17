using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Configuration;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Messaging;
using Model.ViewModel;

namespace Model.DAO
{
    public class ChildrenCategoryDao
    {
        MaiAmTruyenTinDbContext db = null;
        public ChildrenCategoryDao()
        {
            db = new MaiAmTruyenTinDbContext();
        }
        public int Insert(ChildrenCategory category)
        {
            db.ChildrenCategories.Add(category);
            db.SaveChanges();
            return category.ID;
        }
        public bool Update(ChildrenCategory entity)
        {
            try
            {
                var childrencategory = db.ChildrenCategories.Find(entity.ID);
                childrencategory.ID = entity.ID;
                childrencategory.Name = entity.Name;
                childrencategory.MetaTitle = entity.MetaTitle;
                childrencategory.SeoTitle = entity.SeoTitle;
                childrencategory.MetaDescriptions = entity.MetaDescriptions;
                childrencategory.CreatedBy = entity.CreatedBy;
                childrencategory.CreatedDate = entity.CreatedDate;
                childrencategory.ModifiedBy = entity.ModifiedBy;
                childrencategory.ModifiedDate = DateTime.Now;
                childrencategory.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var childrencategory = db.ChildrenCategories.Find(id);
                db.ChildrenCategories.Remove(childrencategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;.
            }
        }
        public ChildrenCategory ViewDetail(int id)
        {
            return db.ChildrenCategories.Find(id);
        }
        public IEnumerable<ChildrenCategory> ListAll()
        {
            return db.ChildrenCategories.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<ChildrenCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ChildrenCategory> model = db.ChildrenCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        //public string ChangeStatus(long id)
        //{
        //    var childrencategory = db.ChildrenCategories.Find(id);
        //    childrencategory.Status = !childrencategory.Status;
        //    db.SaveChanges();
        //    return childrencategory.Status;
        //}
    }
}
