using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuolingoApp.Classes;
using DuolingoApp.UserPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DuolingoApp.TestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        User u;
        public ResultPage(int a, User nd)
        {
            InitializeComponent();
            lblscore.Text = "Điểm số của bạn là " + a + "/40";
            u = nd;
        }

        public ResultPage(int a)
        {
            InitializeComponent();
            lblscore.Text = "Điểm số của bạn là " + a + "/40";
            u = new User();
            u.TenND = "";
        }

        private void btnfinish_Clicked(object sender, EventArgs e)
        {
            if (u.TenND == "")
            {
                DisplayAlert("Chào mừng bạn đến với Duolingo,", "Hãy hoàn thành hồ sơ ĐĂNG KÝ để bắt đầu học tập nhé!", "OK");
                Navigation.PushAsync(new Dangky());
                //Navigation.PopModalAsync();
            }
            else
            {
                Navigation.PopModalAsync();
                Navigation.PopModalAsync();
            }

        }
    }
}