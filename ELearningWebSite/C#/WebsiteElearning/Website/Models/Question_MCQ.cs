using System.Collections.Generic;

namespace Website.Model
{
    public class Question_MCQ : Question
    {
        public ListAnswer LstAnswer;
        public Question_MCQ()
        {
            LstAnswer = new ListAnswer();
        }
        public Question_MCQ(Question ques)
        {
            LstAnswer = new ListAnswer();
            this.id = ques.id;
            this.CodeQuestion = ques.CodeQuestion;
            this.Content = ques.Content;
            this.CorrectAnswer = ques.CorrectAnswer;
            this.Header = ques.Header;
            this.Imgs = ques.Imgs;
            this.NumOrder = ques.NumOrder;
            this.TypeQuest = 2;
        }
    }
}
