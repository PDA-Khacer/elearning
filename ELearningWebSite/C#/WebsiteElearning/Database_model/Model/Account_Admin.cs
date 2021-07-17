using System;
using System.Data.SqlTypes;

namespace Database_model.Model
{
    public class Account_Admin : Account
    {
        public Account_Admin()
        {
            Role = "Admin";
            DayCreate = new SqlDateTime(DateTime.Now);
        }
    }
}
