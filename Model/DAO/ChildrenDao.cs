    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using Model.ViewModel;

namespace Model.DAO
{
    public class ChildrenDao
    {
        MaiAmTruyenTinDbContext db = null;
        public ChildrenDao()
        {
            db = new MaiAmTruyenTinDbContext();
        }
        public Children GetByID(long id)
        {
            return db.Children.Find(id);    
        }
        public int Insert(Children entity)
        {
            //Tạo mới tham số đối tượng: entity 
            db.Children.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Children ViewDetail(int id)
        {
            return db.Children.Find(id);
        }
        public bool Update(Children entity)
        {
            try
            {
                var children = db.Children.Find(entity.ID);
                children.SocialInsurance = entity.SocialInsurance;
                children.BoughtDate = entity.BoughtDate;
                children.EndDate = entity.EndDate;
                children.FullName = entity.FullName;
                children.Age = entity.Age;
                children.DateOfBirth = entity.DateOfBirth;
                children.Gender = entity.Gender;
                children.Image = entity.Image;
                children.BirthCertificate = entity.BirthCertificate;
                children.Hk01 = entity.Hk01;
                children.Hk02 = entity.Hk02;
                children.FoodExpenses = entity.FoodExpenses;
                children.EducationExpenses = entity.EducationExpenses;
                children.Confirmation = entity.Confirmation;
                children.EnrollReason = entity.EnrollReason;
                children.CategoryID = entity.CategoryID;
                children.CounselingID = entity.CounselingID;
                children.SchoolReportID = entity.SchoolReportID;
                children.XFamilyBookID = entity.XFamilyBookID;
                children.EducationID = entity.EducationID;
                //children.CreatedDate = entity.CreatedDate;
                //children.CreatedBy = entity.CreatedBy;
                children.ModifiedDate = DateTime.Now;
                children.ModifiedBy = entity.ModifiedBy;
                children.Status = entity.Status;
                db.Entry(children).State = System.Data.Entity.EntityState.Modified;
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
                var children = db.Children.Find(id);
                db.Children.Remove(children);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public IEnumerable<ChildrenViewModel> ListAllCategory(string searchString, int page, int pageSize)
        {
            //IQueryable<ContentViewModel> model = db.Contents;
            var model = from a in db.Children
                        join b in db.ChildrenCategories
                        on a.CategoryID equals b.ID
                        select new ChildrenViewModel()
                        {
                            ID = a.ID,
                            Image = a.Image,
                            CateName = b.Name,
                            CreatedDate = a.CreatedDate,
                            Status = a.Status,
                            ModifiedDate = a.ModifiedDate,
                            FullName = a.FullName
                        };
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.FullName.Contains(searchString) || x.CateName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        //public IEnumerable<Children> ListAllPaging(string searchString, int page, int pageSize)
        //{
        //    IQueryable<Children> model = db.Children;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.Name.Contains(searchString) || x.Metatitle.Contains(searchString));
        //    }
        //    return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        //}
        //public string ChangeStatus(long id)
        //{
        //    var children = db.Children.Find(id);
        //    children.Status = !children.Status;
        //    db.SaveChanges();
        //    return children.Status;
        //}
        public List<Children> GetChildren(int count)
        {
            return db.Children.OrderByDescending(a => a.Age).Take(count).ToList();
        }
    }
}
