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
    
    public partial class Combination
    {
        public Combination()
        {
            this.AcademicHistories = new HashSet<AcademicHistory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<AcademicHistory> AcademicHistories { get; set; }
    }
}
