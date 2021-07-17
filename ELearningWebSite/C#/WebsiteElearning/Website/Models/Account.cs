using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Website.Model
{
    public class Account
    {
        public int id { get; set; }
        public SqlDateTime DayCreate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Img { get; set; }
        public string BrithDay { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EduMaill { get; set; }
        public string Role { get; set; }
        public int State { get; set; }
        public List<Announcement> LstAnnoum { get; set; }
        public Account()
        {
            Role = "Account";
            DayCreate = new SqlDateTime(DateTime.Now);
        }
    }
}
