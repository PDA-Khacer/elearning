using System.Data.SqlTypes;

namespace Winform.Model
{
    public class Lecture_Class : Lecture
    {
        public Lecture_Student LstLectureStudent { get; set; }
        public SqlDateTime DayAdd { get; set; }
    }
}
