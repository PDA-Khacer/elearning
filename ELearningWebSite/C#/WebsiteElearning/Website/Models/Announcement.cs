using System;
using System.Data.SqlTypes;

namespace Website.Model
{
    public class Announcement
    {
        public int id { get; set; }
        public SqlDateTime DayCreate { get; set; }
        public Account UserRecive { get; set; }
        public SqlDateTime DayUpLoad { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public Account UserSent { get; set; }
        public int State { get; set; }
        public Announcement()
        {
            DayCreate = new SqlDateTime(DateTime.Now);
        }
    }
}
