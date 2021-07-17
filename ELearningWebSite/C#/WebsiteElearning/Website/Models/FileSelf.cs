using System.Data.SqlTypes;

namespace Website.Model
{
    public class FileSelf
    {
        public int id { get; set; }
        public string CodeFile { get; set; }
        public string NameFile { get; set; }
        public string Link { get; set; }
        public string PathSave { get; set; }
        public string Size { get; set; }
        public TypeFile TailFile { get; set; }
        public Account Self { get; set; }
        public SqlDateTime DayUpLoad { get; set; }
        public int State { get; set; }
    }
}