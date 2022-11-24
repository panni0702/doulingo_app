using System;
using System.Collections.Generic;
using System.Text;

namespace DuolingoApp.Classes
{
    public class Questionnaire : QuestionBuilder
    {
        public override void Building(Question q)
        {
            QuestionQuiz.setting_question(q);
        }
    }
}
