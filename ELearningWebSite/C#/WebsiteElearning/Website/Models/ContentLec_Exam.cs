using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Website.Model
{
    public class ContentLec_Exam : ContentLec
    {
        public SqlDateTime DayExpire { get; set; }
        public SqlDateTime TimeStart { get; set; }
        public float Duration { get; set; }
        public ListQuestion_MCQ LstQuest { get; set; }
        public List<Student_Exam> LstExamStudent { get; set; }
    }
}
