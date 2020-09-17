namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MaiAmTruyenTinDbContext : DbContext
    {
        public MaiAmTruyenTinDbContext()
            : base("name=MaiAmTruyenTinDbContext")
        {
        }

        public virtual DbSet<Children> Children { get; set; }
        public virtual DbSet<ChildrenCategory> ChildrenCategories { get; set; }
        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<CostCategory> CostCategories { get; set; }
        public virtual DbSet<Counseling> Counselings { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Regulation> Regulations { get; set; }
        public virtual DbSet<SchoolReport> SchoolReports { get; set; }
        public virtual DbSet<SECategory> SECategories { get; set; }
        public virtual DbSet<SuppliesEquipment> SuppliesEquipments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<XFamilyBook> XFamilyBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Children>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Children>()
                .Property(e => e.FoodExpenses)
                .HasPrecision(11, 0);

            modelBuilder.Entity<Children>()
                .Property(e => e.EducationExpenses)
                .HasPrecision(11, 0);

            modelBuilder.Entity<Children>()
                .Property(e => e.CounselingID)
                .IsUnicode(false);

            modelBuilder.Entity<Children>()
                .Property(e => e.SchoolReportID)
                .IsUnicode(false);

            modelBuilder.Entity<Children>()
                .Property(e => e.XFamilyBookID)
                .IsUnicode(false);

            modelBuilder.Entity<ChildrenCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Cost>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Cost>()
                .Property(e => e.CategoryID)
                .IsUnicode(false);

            modelBuilder.Entity<Cost>()
                .Property(e => e.UnitCost)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Cost>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 0);

            modelBuilder.Entity<CostCategory>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Counseling>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.IdentityCard)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.GiftSalary)
                .HasPrecision(11, 0);

            modelBuilder.Entity<Employee>()
                .Property(e => e.AllOtherFoodExpenses)
                .HasPrecision(11, 0);

            modelBuilder.Entity<Regulation>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolReport>()
                .Property(e => e.ChildrenID)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolReport>()
                .Property(e => e.Semester1)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolReport>()
                .Property(e => e.Semester2)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolReport>()
                .Property(e => e.FullYear)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.IdentityCard)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.IdentityCard)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.OtherFoodExpenses)
                .IsUnicode(false);

            modelBuilder.Entity<XFamilyBook>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<XFamilyBook>()
                .Property(e => e.ChildrenID)
                .IsUnicode(false);

            modelBuilder.Entity<XFamilyBook>()
                .Property(e => e.BaptismalName)
                .IsUnicode(false);
        }
    }
}
