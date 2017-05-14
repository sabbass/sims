using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResultInformation.Areas.Student.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get;set;}
    }
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramId { get; set; }
    }
    public class Registration
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        
    }
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
