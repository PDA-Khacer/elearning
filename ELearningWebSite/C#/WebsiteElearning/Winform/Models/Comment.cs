using System.Data.SqlTypes;

namespace Winform.Model
{
    public class Comment
    {
        public int id { get; set; }
        public string Content { get; set; }
        public SqlDateTime TimeComment { get; set; }
        public Account Self { get; set; }
        public int State { get; set; }
    }
}