using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuolingoApp.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DuolingoApp.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        Database db = new Database();
        public SignIn()
        {
            InitializeComponent();
            usrPassword.Text = "";
            usrName.Focus();
        }

        private async void cmdsubmit_Clicked(object sender, EventArgs e)
        {

            var ten = usrName.Text;
            var email = usrName.Text;
            var mk = usrPassword.Text;

            /*if (ten == "Ly" && mk == "8401")
            {
                DisplayAlert("Thông báo", "Chào Ly!", "Bắt đầu ngay");
                Navigation.PushAsync(new TabPage());
            }
            else*/
            if (db.XacThuc(ten, mk) == true)
            {
                User u = db.LayNd(ten);
                await DisplayAlert("Thông báo", "Đăng nhập thành công", "OK");
                usrPassword.Text = "";
                await Navigation.PushModalAsync(new TabPage(u));
            }
            else
            {
                await DisplayAlert("Thông báo", "Thông tin đăng nhập không chính xác", "OK");
                usrName.Text = "";
                usrPassword.Text = "";
                usrName.Focus();
            }
        }

        private void cmdfb_Clicked(object sender, EventArgs e)
        {

        }

        private void cmdgg_Clicked(object sender, EventArgs e)
        {

        }

        private void dk_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Taohs());
        }
    }
}