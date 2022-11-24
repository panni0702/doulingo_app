using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DuolingoApp.Classes
{
    public class QuestionDatabase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateDatabase()
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                connect.CreateTable<Question>();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CreateQuestion()
        {
            try
            {
                List<Question> qs = new List<Question>();
                qs.Add(new Question { Id = 1, Lessonid = 2, Quest_ = "Đâu là 'Xe buýt'?", resp1_ = "bus", resp2_ = "car", resp3_ = "train", resp4_ = "airplane", Correct = "bus" });
                qs.Add(new Question { Id = 2, Lessonid = 1, Quest_ = "Từ nào sau đây có nghĩa là 'Mẹ'?", resp1_ = "father", resp2_ = "brother", resp3_ = "teacher", resp4_ = "mother", Correct = "mother" });
                qs.Add(new Question { Id = 3, Lessonid = 3, Quest_ = "Từ nào sau đây có nghĩa là 'Bữa ăn sáng'?", resp1_ = "good moring", resp2_ = "lunch", resp3_ = "breakfast", resp4_ = "dinner", Correct = "breakfast" });
                qs.Add(new Question { Id = 4, Lessonid = 1, Quest_ = "Dịch câu sau: 'My brother is very tall.'", resp1_ = "Anh trai tôi rất cao.", resp2_ = "Chị tôi rất cao.", resp3_ = "Anh trai tôi rất thấp.  ", resp4_ = "Đây là bố của tôi.", Correct = "Anh trai tôi rất cao." });
                qs.Add(new Question { Id = 5, Lessonid = 2, Quest_ = "Điền từ: I will travel by ___.", resp1_ = "vacation", resp2_ = "America", resp3_ = "airport", resp4_ = "car", Correct = "car" });
                qs.Add(new Question { Id = 6, Lessonid = 1, Quest_ = "Điền từ: My mother's mother is my ___.", resp1_ = "cousin", resp2_ = "sister", resp3_ = "grandmother", resp4_ = "aunt", Correct = "grandmother" });
                qs.Add(new Question { Id = 7, Lessonid = 1, Quest_ = "Dịch câu sau: 'Ông ấy có hai người con gái.'", resp1_ = "He has two sisters.", resp2_ = "She has two daughters.", resp3_ = "He have two daughters.", resp4_ = "He has two daughters.", Correct = "He has two daughters." });
                qs.Add(new Question { Id = 8, Lessonid = 2, Quest_ = "Dịch câu sau: 'Rất vui được gặp bạn'", resp1_ = "I'm fine, thank you. And you?", resp2_ = "Hello.", resp3_ = "Nice to meet you.", resp4_ = "How are you?", Correct = "Nice to meet you." });
                qs.Add(new Question { Id = 9, Lessonid = 2, Quest_ = "Dịch câu sau: 'Tôi đang ở ga tàu hỏa.'", resp1_ = "I'm at the bus station.", resp2_ = "I'm at the train station.", resp3_ = "I'm at the airport.", resp4_ = "I'm at the hotel.", Correct = "I'm at the train station." });
                qs.Add(new Question { Id = 10, Lessonid = 3, Quest_ = "Điền từ: Apples and oranges are ___.", resp1_ = "fruit", resp2_ = "meat", resp3_ = "drinks", resp4_ = "animals", Correct = "fruit" });
                qs.Add(new Question { Id = 11, Lessonid = 3, Quest_ = "Dịch câu sau: 'Tôi không uống cà phê.'", resp1_ = "I don't want coffee.", resp2_ = "I don't drink coffee.", resp3_ = "I don't drink a coffee.", resp4_ = "I want some coffee.", Correct = "I don't drink coffee." });
                qs.Add(new Question { Id = 12, Lessonid = 3, Quest_ = "Dịch câu sau: 'Would you like some milk ?'", resp1_ = "Bạn có muốn một ít sữa không?", resp2_ = "Bạn có muốn ăn mì không?", resp3_ = "Bạn có muốn uống gì không?", resp4_ = "Bạn có muốn ăn gì không?", Correct = "Bạn có muốn một ít sữa không?" });
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                for (int i = 0; i < qs.Count; i++)
                {
                    connect.Insert(qs[i]);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Question> SelectQuestions(int i)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                return connect.Table<Question>().Where(t => t.Lessonid == i).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<Question> SelectAllQuestions()
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                return connect.Table<Question>().ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Question> Select4Questions()
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                return connect.Query<Question>("select * from Question limit 4");
            }
            catch
            {
                return null;
            }
        }
        public bool InsertQuestion(Question q)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                connect.Insert(q);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Question SelectQuestion(int i)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                return connect.Table<Question>().FirstOrDefault(t => t.Id == i);
            }
            catch
            {
                return null;
            }
        }
        public bool UpdateQuestion(Question q)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                connect.Update(q);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteQuestion(Question q)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "Question1.db"));
                connect.Delete(q);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
