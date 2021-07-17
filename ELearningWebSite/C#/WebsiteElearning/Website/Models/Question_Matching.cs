using System.Collections.Generic;

namespace Website.Model
{
    public class Question_Matching : Question
    {
        public List<Answer> LstAnswer1;
        public List<Answer> LstAnswer2;
        public Question_Matching()
        {
            LstAnswer1 = new List<Answer>();
            LstAnswer2 = new List<Answer>();
        }
        public Question_Matching(Question ques)
        {
            this.CodeQuestion = ques.CodeQuestion;
            this.Content = ques.Content;
            //this.CorrectAnswer = ques.CorrectAnswer;
            this.Header = ques.Header;
            this.Imgs = ques.Imgs;
            this.NumOrder = ques.NumOrder;
            this.TypeQuest = 1;
            LstAnswer1 = new List<Answer>();
            LstAnswer2 = new List<Answer>();
        }
    }
}
