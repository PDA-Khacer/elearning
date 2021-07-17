using System;
using System.Data.SqlTypes;

namespace Database_model.Model
{
    public class Answer_Student : Answer
    {
        public SqlDateTime ChoseTime { get; set; }
        public Account_Student Self { get; set; }
        public Answer_Student()
        {
            ChoseTime = new SqlDateTime(DateTime.Now);
        }
        public Answer_Student(Answer ans)
        {
            ChoseTime = new SqlDateTime(DateTime.Now);
            this.CharOrder = ans.CharOrder;
            this.CodeAnswer = ans.CodeAnswer;
            this.ContentQ = ans.ContentQ;
            this.id = ans.id;
            this.Imgs = ans.Imgs;
            this.State = ans.State;
        }
        public Answer_Student(Answer ans, Account_Student self)
        {
            ChoseTime = new SqlDateTime(DateTime.Now);
            this.CharOrder = ans.CharOrder;
            this.CodeAnswer = ans.CodeAnswer;
            this.ContentQ = ans.ContentQ;
            this.id = ans.id;
            this.Imgs = ans.Imgs;
            this.State = ans.State;
        }
    }
}
