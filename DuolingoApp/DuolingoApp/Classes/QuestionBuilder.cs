using System;
using System.Collections.Generic;
using System.Text;

namespace DuolingoApp.Classes
{
    public abstract class QuestionBuilder
    {
        protected Question QuestionQuiz;
        public Question gettingQuestion() { return QuestionQuiz; }

        public void CreateInstance() { QuestionQuiz = new Question(); }

        public abstract void Building(Question question);

    }
}
