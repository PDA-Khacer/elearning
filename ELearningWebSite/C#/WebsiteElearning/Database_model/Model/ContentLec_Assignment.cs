using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Database_model.Model
{
    public class ContentLec_Assignment : ContentLec
    {
        public SqlDateTime DayExpire { get; set; }
        public string Content { get; set; }
        public List<Student_Assignment> LstAssignmentStudent { get; set; }

        public ContentLec_Assignment()
        {

        }
        public ContentLec_Assignment(ContentLec conntentL)
        {
            this.CodeContentLec = conntentL.CodeContentLec;
            this.DayClose = conntentL.DayClose;
            this.DayCreate = conntentL.DayCreate;
            this.DayOpen = conntentL.DayOpen;
            this.Decription = conntentL.Decription;
            this.Header = conntentL.Header;
            this.State = conntentL.State;
            this.TypeContentLec = "1";
        }
    }
}
