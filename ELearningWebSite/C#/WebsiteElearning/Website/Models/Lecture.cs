using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Website.Model
{
    public class Lecture
    {
        public int id { get; set; }
        public string CodeLecture { get; set; }
        public SqlDateTime DayCreate { get; set; }
        public string Header { get; set; }
        public string Decription { get; set; }
        public int State { get; set; }
        public List<ContentLec> LstConLec { get; set; }
        public Lecture()
        {
            DayCreate = new SqlDateTime(DateTime.Now);
        }
    }
}
