//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResultInformation.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Semester
    {
        public Semester()
        {
            this.Registrations = new HashSet<Registration>();
            this.Courses = new HashSet<Course>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ProgramId { get; set; }
    
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual Program Program { get; set; }
    }
}
