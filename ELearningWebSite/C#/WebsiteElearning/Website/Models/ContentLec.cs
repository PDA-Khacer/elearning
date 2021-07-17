using System;
using System.Data.SqlTypes;

namespace Website.Model
{
    public class ContentLec
    {
        public int id { get; set; }
        public string CodeContentLec { get; set; }
        public SqlDateTime DayCreate { get; set; }
        public string Header { get; set; }
        public string Decription { get; set; }
        public SqlDateTime DayOpen { get; set; }
        public SqlDateTime DayClose { get; set; }
        public int State { get; set; }
        public string TypeContentLec { get; set; }
        public Account_Teacher Self { get; set; }
        public ContentLec()
        {
            DayCreate = new SqlDateTime(DateTime.Now);
        }
    }
}