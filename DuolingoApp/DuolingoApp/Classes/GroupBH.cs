using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DuolingoApp.Classes
{
    public class GroupBH : List<BaiHoc>
    {
        public int MaChang { get; set; }
        public int MaND { get; set; }
        public GroupBH(int machang, List<BaiHoc> bhs)
        {
            MaChang = machang;
            for (int i = 0; i < bhs.Count; i++)
            {
                this.Add(bhs[i]);
            }
        }
        // Thêm bài học, người dùng
        /*
        public List<BaiHoc> GroupBHND(int mand, List<BaiHoc> bhs)
        {
            MaND = mand;
            for (int i = 0; i< bhs.Count; i++)
            {
                this.Add(bhs[i]);
            }
            return bhs;
        }*/
    }
}
