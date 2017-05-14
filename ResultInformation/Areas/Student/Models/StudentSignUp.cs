using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResultInformation.Areas.Student.Models
{
    public class StudentSignUp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
      
        public string ResistrationNo { get; set; }
        public string CNIC { get; set; }
     
        public string UserId { get; set; }
        public Nullable<int> ProgramId { get; set; }
    
    }

    public class StudentProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SystemId { get; set; }
        public string RollNo { get; set; }
        public string ResistrationNo { get; set; }
        public string CNIC { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName { get; set; }
        public string FatherLastName { get; set; }
        public string FatherCNIC { get; set; }
        public string UserId { get; set; }
        public Nullable<int> ProgramId { get; set; }
        public Nullable<int> SemesterId { get; set; }
        public List<int> Courses = new List<int>();
    }
}