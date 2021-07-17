using System;
using System.Data.SqlTypes;

namespace Winform.Model
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
