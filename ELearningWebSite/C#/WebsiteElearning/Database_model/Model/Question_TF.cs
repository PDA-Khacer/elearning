using System.Collections.Generic;

namespace Database_model.Model
{
    public class Question_TF : Question
    {
        public List<Answer> LstAnswer;
        public List<bool> LstCorrectAnser;

        public Question_TF()
        {
            LstAnswer = new List<Answer>();
            LstCorrectAnser = new List<bool>();
        }
        public Question_TF(Question ques)
        {
            LstAnswer = new List<Answer>();
            LstCorrectAnser = new List<bool>();
            this.CodeQuestion = ques.CodeQuestion;
            this.Content = ques.Content;
            //this.CorrectAnswer = ques.CorrectAnswer;
            this.Header = ques.Header;
            this.Imgs = ques.Imgs;
            this.NumOrder = ques.NumOrder;
            this.TypeQuest = 3;
        }
    }
}
