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
    public partial class Dangky : ContentPage
    {
        Database db;
        public Dangky()
        {
            InitializeComponent();
            db = new Database();
        }

        private void btndangky_Clicked(object sender, EventArgs e)
        {
            var ten = usrname.Text;
            var email = txtemail.Text;
            var mk = txtmk.Text;
            if (ten == null || mk == null || email == null)
            {
                DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin.", "OK");
            }

            else if (db.TonTai(ten, email) == true)
            {
                DisplayAlert("Thông báo", "Tài khoản đã tồn tại: Vui lòng nhập tên khác.", "OK");
                usrname.Text = "";
                usrname.Focus();
            }
            else
            {
                User nd = new User();
                nd.TenND = usrname.Text;
                nd.MatKhau = txtmk.Text;
                nd.Email = txtemail.Text;
                nd.Diem = 0;

                if (db.ThemNguoidung(nd) == true)
                {
                    DisplayAlert("Thông báo", "Chúc mừng đăng ký thành công", "Bắt đầu thôi");
                    Navigation.PushAsync(new SignIn());
                }
                else
                {
                    DisplayAlert("Thông báo", "Đăng ký không thành công. Vui lòng thử lại", "OK");
                }

            }
        }

        private void btnhuy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}