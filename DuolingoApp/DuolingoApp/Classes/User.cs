using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DuolingoApp.Classes
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int MaND { get; set; }
        public string TenND { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string Hinh { get; set; }
        public int Diem { get; set; }
    }
}
