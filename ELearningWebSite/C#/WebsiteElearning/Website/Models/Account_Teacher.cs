using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Website.Model
{
    public class Account_Teacher : Account
    {
        public List<ContentLec> LstLecSelf { get; set; }
        public Account_Teacher()
        {
            Role = "Teacher";
            DayCreate = new SqlDateTime(DateTime.Now);
            LstLecSelf = new List<ContentLec>();
        }
        public Account_Teacher(Account acc)
        {
            Role = "Teacher";
            this.Username = acc.Username;
            this.BrithDay = acc.BrithDay;
            this.DayCreate = acc.DayCreate;
            this.EduMaill = acc.EduMaill;
            this.Email = acc.Email;
            this.FullName = acc.FullName;
            this.Gender = acc.Gender;
            this.Img = acc.Img;
            this.LstAnnoum = acc.LstAnnoum;
            this.Password = acc.Password;
            this.PhoneNumber = acc.PhoneNumber;
            this.State = acc.State;
            DayCreate = new SqlDateTime(DateTime.Now);
            LstLecSelf = new List<ContentLec>();
        }
    }
}
