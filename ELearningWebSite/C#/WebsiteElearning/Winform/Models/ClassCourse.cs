using System.Collections.Generic;

namespace Winform.Model
{
    public class ClassCourse
    {
        public int id { get; set; }
        public string CodeClass { get; set; }
        public string NameClass { get; set; }
        public int State { get; set; }
        public int idCourse { get; set; }
        // public List<Account_Student> LstStudent { get; set; }
        public ListAccountStudent LstStudent { get; set; }
        public ListAccountTeacher LstTeacher { get; set; }
        //public List<Lecture> LstLecture { get; set; }
        public ListLecture LstLecture { get; set; }
    }
}
