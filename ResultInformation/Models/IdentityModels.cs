using Microsoft.AspNet.Identity.EntityFramework;

namespace ResultInformation.Areas.Admin.Models
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
    }
}