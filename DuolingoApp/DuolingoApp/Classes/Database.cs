using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DuolingoApp.Classes
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateDatabase()
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                connect.CreateTable<User>();
                connect.CreateTable<BaiHoc>();
                connect.CreateTable<GroupBH>();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Lấy dữ liệu:
        public User LayNd(string ten)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                return connect.Table<User>().FirstOrDefault(t => t.TenND == ten || t.Email == ten);
            }
            catch
            {
                return null;
            }
        }

        public List<User> LayNguoidung()
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                return connect.Table<User>().ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool XacThuc(string ten, string mk)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                var data = connect.Table<User>();
                var d1 = data.Where(x => (x.TenND == ten || x.Email == ten) && x.MatKhau == mk).FirstOrDefault();
                if (d1 != null)
                {
                    return true;
                }

                else
                    return false;

            }
            catch
            {
                return false;
            }

        }


        public bool TonTai(string ten, string email)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                var data = connect.Table<User>();
                var d1 = data.Where(x => x.TenND == ten || x.Email == email).FirstOrDefault();
                if (d1 != null)
                {
                    return true;
                }

                else
                    return false;

            }
            catch
            {
                return false;
            }
        }
        /*
        public bool TonTaiBH(int mand, string tenBH, int machang)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                var data = connect.Table<BaiHoc>();
                var d1 = data.Where(x => x.MaND == mand && x.TenBH == tenBH && x.MaChang == machang).FirstOrDefault();
                if (d1 != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        */
        public List<BaiHoc> LayBaiHocTheoChang(int machang, int mand)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                return connect.Query<BaiHoc>("select * from BaiHoc where (MaChang=" + machang.ToString() + " and MaND=" + mand.ToString());
            }
            catch
            {
                return null;
            }
        }
        public List<BaiHoc> LayBaiHocTheoND(int mand)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                return connect.Query<BaiHoc>("select * from BaiHoc where MaND=" + mand.ToString());
            }
            catch
            {
                return null;
            }
        }



        public List<BaiHoc> LayBaiHoc()
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                return connect.Table<BaiHoc>().ToList();
            }
            catch
            {
                return null;
            }
        }


        public List<User> LayND()
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                return connect.Table<User>().ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<User> LayTopND()
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                return connect.Query<User>("select * from User order by Diem DESC limit 5");
            }
            catch
            {
                return null;
            }
        }
        // Thêm
        public bool ThemNguoidung(User nd)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                connect.Insert(nd);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool ThemBaiHoc(BaiHoc bh)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                connect.Insert(bh);
                return true;
            }
            catch
            {
                return false;
            }
        }


        // Sửa dữ liệu
        public bool SuaNguoiDung(User nd)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "ql.db"));
                connect.Update(nd);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /* Câu hỏi
        public List<Question> SelectQuestions(int i)
        {
            try
            {
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "abc.db"));
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
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "abc.db"));
                return connect.Table<Question>().ToList();
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
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "abc.db"));
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
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "abc.db"));
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
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "abc.db"));
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
                var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "abc.db"));
                connect.Delete(q);
                return true;
            }
            catch
            {
                return false;
            }
        }*/
    }
}
