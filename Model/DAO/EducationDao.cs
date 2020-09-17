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
    public class EducationDao
    {
        MaiAmTruyenTinDbContext db = null;
        public EducationDao()
        {
            db = new MaiAmTruyenTinDbContext();
        }
        public int Insert(Education education)
        {
            db.Educations.Add(education);
            db.SaveChanges();
            return education.ID;
        }
        public bool Update(Education entity)
        {
            try
            {
                var education = db.Educations.Find(entity.ID);
                education.ID = entity.ID;
                education.Code = entity.Code;
                education.Name = entity.Name;
                education.CreatedBy = entity.CreatedBy;
                education.CreatedDate = entity.CreatedDate;
                education.ModifiedBy = entity.ModifiedBy;
                education.ModifiedDate = DateTime.Now;
                education.Status = entity.Status;
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
                var education = db.Educations.Find(id);
                db.Educations.Remove(education);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;.
            }
        }
        public Education ViewDetail(int id)
        {
            return db.Educations.Find(id);
        }
        public IEnumerable<Education> ListAll()
        {
            return db.Educations.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<Education> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Education> model = db.Educations;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        //public string ChangeStatus(long id)
        //{
        //    var education = db.Educations.Find(id);
        //    education.Status = !education.Status;
        //    db.SaveChanges();
        //    return education.Status;
        //}
    }
}
