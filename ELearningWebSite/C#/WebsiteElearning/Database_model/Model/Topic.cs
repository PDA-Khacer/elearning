using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Database_model.Model
{
    public class Topic
    {
        public int id { get; set; }
        public string CodeTopic { get; set; }
        public string Header { get; set; }
        public string Decription { get; set; }
        public SqlDateTime DayCreate { get; set; }
        public Account Self { get; set; }
        public List<Comment> LstComment { get; set; }
        public int State { get; set; }
    }
}