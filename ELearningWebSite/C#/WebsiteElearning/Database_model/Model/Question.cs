using System.Collections.Generic;

namespace Database_model.Model
{
    public class Question
    {
        public int id { get; set; }
        public string CodeQuestion { get; set; }
        // số thứ tự của câu hỏi
        public string NumOrder { get; set; }
        // kí hiệu: câu, bài,...
        public string Header { get; set; }
        public string Content { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Imgs { get; set; }
        public int TypeQuest { get; set; }
        public int State { get; set; }

    }
}
