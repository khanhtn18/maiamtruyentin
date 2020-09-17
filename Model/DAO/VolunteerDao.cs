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
    public class VolunteerDao
    {
        MaiAmTruyenTinDbContext db = null;
        public VolunteerDao()
        {
            db = new MaiAmTruyenTinDbContext();
        }
        public Volunteer GetByID(long id)
        {
            return db.Volunteers.Find(id);
        }
        public int Insert(Volunteer entity)
        {
            //Tạo mới tham số đối tượng: entity 
            db.Volunteers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Volunteer ViewDetail(int id)
        {
            return db.Volunteers.Find(id);
        }
        public bool Update(Volunteer entity)
        {
            try
            {
                var volunteer = db.Volunteers.Find(entity.ID);
                volunteer.Code = entity.Code;
                volunteer.IdentityCard = entity.IdentityCard;
                volunteer.Name = entity.Name;
                volunteer.Age = entity.Age;
                volunteer.Gender = entity.Gender;
                volunteer.Image = entity.Image;
                volunteer.Phone = entity.Phone;
                volunteer.Email = entity.Email;
                volunteer.Nationality = entity.Nationality;
                volunteer.Address = entity.Address;
                volunteer.OtherFoodExpenses = entity.OtherFoodExpenses;
                volunteer.WorkingHour = entity.WorkingHour;
                volunteer.OffHour = entity.OffHour;
                volunteer.ModifiedDate = DateTime.Now;
                volunteer.ModifiedBy = entity.ModifiedBy;
                volunteer.Status = entity.Status;
                db.Entry(volunteer).State = System.Data.Entity.EntityState.Modified;
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
                var volunteer = db.Volunteers.Find(id);
                db.Volunteers.Remove(volunteer);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public IEnumerable<Volunteer> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Volunteer> model = db.Volunteers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Phone.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Volunteer> GetEmployee(int count)
        {
            return db.Volunteers.OrderByDescending(a => a.Age).Take(count).ToList();
        }
    }
}
