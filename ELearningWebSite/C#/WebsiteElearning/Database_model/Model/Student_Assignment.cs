using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Database_model.Model
{
    public class Student_Assignment
    {
        public int id { get; set; }
        public SqlDateTime LastUpdate { get; set; }
        public float Point { get; set; }
        public SqlDateTime TimeGive { get; set; }
        public Account_Teacher TeacherGive { get; set; }
        public Account_Student Owns { get; set; }
        public List<FileSelf> LstFile { get; set; }
        public List<Comment> LstComment { get; set; }
        public int State { get; set; }

    }
}
