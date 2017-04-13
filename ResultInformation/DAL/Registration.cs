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
    
    public partial class Registration
    {
        public int Id { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> SessionId { get; set; }
        public Nullable<int> ShiftId { get; set; }
        public Nullable<int> SemesterId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public byte[] CreateDate { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
    
        public virtual AcademicSession AcademicSession { get; set; }
        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
