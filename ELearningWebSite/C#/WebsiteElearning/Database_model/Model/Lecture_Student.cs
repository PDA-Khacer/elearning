using System;
using System.Data.SqlTypes;

namespace Database_model.Model
{
    public class Lecture_Student : Lecture
    {
        public Account_Student Student { get; set; }
        public SqlBoolean isComplete { get; set; }
        public float PercentComplete { get; set; }
        public SqlDateTime DayComplete { get; set; }
        public Lecture_Student()
        {
            DayCreate = new SqlDateTime(DateTime.Now);
            isComplete = false;
            PercentComplete = 0;
        }
    }
}
