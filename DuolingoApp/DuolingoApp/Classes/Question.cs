using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DuolingoApp.Classes
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Lessonid { get; set; }
        public string Quest_ { get; set; }
        public string resp1_ { get; set; }
        public string resp2_ { get; set; }
        public string resp3_ { get; set; }
        public string resp4_ { get; set; }
        public string Correct { get; set; }

        public Question() { }
        public Question setting_question(Question quest) { return quest; }
    }
}
