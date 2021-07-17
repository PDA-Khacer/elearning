using System.Collections.Generic;

namespace Winform.Model
{
    public class Course
    {
        public int id { get; set; }
        public string CodeCourse { get; set; }
        public string NameCourse { get; set; }
        public int State { get; set; }
        //public List<ClassCourse> LstClass { get; set; }
        public ListClassCourse LstClass { get; set; }
    }
}
