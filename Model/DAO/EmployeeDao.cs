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
    public class EmployeeDao
    {
        MaiAmTruyenTinDbContext db = null;
        public EmployeeDao()
        {
            db = new MaiAmTruyenTinDbContext();
        }
        public Employee GetByID(long id)
        {
            return db.Employees.Find(id);
        }
        public int Insert(Employee entity)
        {
            //Tạo mới tham số đối tượng: entity 
            db.Employees.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Employee ViewDetail(int id)
        {
            return db.Employees.Find(id);
        }
        public bool Update(Employee entity)
        {
            try
            {
                var employee = db.Employees.Find(entity.ID);
                employee.Code = entity.Code;
                employee.IdentityCard = entity.IdentityCard;
                employee.Name = entity.Name;
                employee.Age = entity.Age;
                employee.Gender = entity.Gender;
                employee.Image = entity.Image;
                employee.DateOfBirth = entity.DateOfBirth;
                employee.Domicile = entity.Domicile;
                employee.PlaceOfBirth = entity.PlaceOfBirth;
                employee.Education = entity.Education;
                employee.StudiedAt = entity.StudiedAt;
                employee.Language = entity.Language;
                employee.InformationTechnology = entity.InformationTechnology;
                employee.Job = entity.Job;
                employee.JobName = entity.JobName;
                employee.Phone = entity.Phone;
                employee.Religion = entity.Religion;
                employee.StartingSalagy = entity.StartingSalagy;
                employee.GiftSalary = entity.GiftSalary;
                employee.AllOtherFoodExpenses = entity.AllOtherFoodExpenses;
                employee.ContractType = entity.ContractType;
                employee.WorkingContract = entity.WorkingContract;
                //employee.CreatedDate = entity.CreatedDate;
                //employee.CreatedBy = entity.CreatedBy;
                employee.ModifiedDate = DateTime.Now;
                employee.ModifiedBy = entity.ModifiedBy;
                employee.Status = entity.Status;
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
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
                var employee = db.Employees.Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public IEnumerable<EmployeeViewModel> ListAllCategory(string searchString, int page, int pageSize)
        {
            //IQueryable<ContentViewModel> model = db.Contents;
            var model = from a in db.Employees
                        join b in db.Educations
                        on a.Education equals b.ID
                        select new EmployeeViewModel()
                        {
                            ID = a.ID,
                            Image = a.Image,
                            EducationName = b.Name,
                            CreatedDate = a.CreatedDate,
                            Status = a.Status,
                            ModifiedDate = a.ModifiedDate,
                            Name = a.Name
                        };
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.EducationName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        //public IEnumerable<Employee> ListAllPaging(string searchString, int page, int pageSize)
        //{
        //    IQueryable<Employee> model = db.Employee;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.Name.Contains(searchString) || x.Metatitle.Contains(searchString));
        //    }
        //    return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        //}
        //public string ChangeStatus(int id)
        //{
        //    var employee = db.Employee.Find(id);
        //    employee.Status = !employee.Status;
        //    db.SaveChanges();
        //    return employee.Status;
        //}
        public List<Employee> GetEmployee(int count)
        {
            return db.Employees.OrderByDescending(a => a.Age).Take(count).ToList();
        }
    }
}
