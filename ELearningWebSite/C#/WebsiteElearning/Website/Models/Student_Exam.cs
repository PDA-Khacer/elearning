using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Website.Model
{
    public class Student_Exam
    {
        public int id { get; set; }
        public Account_Student StudentDo { get; set; }
        public SqlDateTime TimeStartDo { get; set; }
        public float DurationDo { get; set; }
        public float Point { get; set; }
        public int State { get; set; }
        public Account_Teacher TeacherGive { get; set; }
        public SqlDateTime TimeGivePoint { get; set; }
        public List<Answer_Student> LstAnswer { get; set; }
        public List<Comment> LstComment { get; set; }
    }
}
