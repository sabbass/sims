using Microsoft.AspNet.Identity.EntityFramework;

namespace ResultInformation.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    { 
        public ApplicationDbContext()  
            : base("DefaultConnection")
        {  

        }

        public System.Data.Entity.DbSet<ResultInformation.Areas.Admin.Models.StudentModel> StudentModels { get; set; }

        public System.Data.Entity.DbSet<ResultInformation.Areas.Admin.Models.InstituteModel> InstituteModels { get; set; }

        public System.Data.Entity.DbSet<ResultInformation.Areas.Admin.Models.AwardingBodyModel> ShiftModels { get; set; }

        public System.Data.Entity.DbSet<ResultInformation.Areas.Admin.Models.CourseModel> SemesterModels { get; set; }

        public System.Data.Entity.DbSet<ResultInformation.Areas.Admin.Models.AcademicLevelModel> LevelModels { get; set; }

        public System.Data.Entity.DbSet<ResultInformation.Areas.Admin.Models.AcademicSessionModel> AcademicSessionModels { get; set; }

        public System.Data.Entity.DbSet<ResultInformation.Areas.Admin.Models.CombinationModel> CombinationModels { get; set; }

        public System.Data.Entity.DbSet<ResultInformation.Areas.Admin.Models.AcademicHistoryModel> AcademicHistoryModels { get; set; }
    }
}