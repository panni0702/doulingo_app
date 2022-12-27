using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuolingoApp.Classes;
using DuolingoApp.TestPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DuolingoApp.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CapDo : ContentPage
    {
        List<Level> levelList;
        void LevelInit()
        {
            levelList = new List<Level>();
            levelList.Add(new Level { levelImg = "owl.png", levelName = "Đây là lần đầu bạn học Tiếng Anh?", levelDes = "Bắt đầu từ bài tập cơ bản nhé!" });
            levelList.Add(new Level { levelImg = "owl_2.png", levelName = "Bạn đã biết Tiếng Anh một chút?", levelDes = "Trả lời một vài câu hỏi để xác định cấp độ phù hợp." });

            lstcapdo.ItemsSource = levelList;
        }
        public CapDo()
        {
            InitializeComponent();
            LevelInit();
        }

        private void lstcapdo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Level level = (Level)e.SelectedItem;

        }

        private void continue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BatDauPage());
        }
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}