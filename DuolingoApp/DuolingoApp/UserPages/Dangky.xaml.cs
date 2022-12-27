using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuolingoApp.Classes;
using Xamarin.Essentials;
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

        private bool validateEmail(string email)
        {
            string[] emailArray = email.Split('@');
            if (emailArray.Length != 2)
            {
                return false;
            } else if (emailArray[0] == "" || emailArray[1] == "")
            {
                return false;
            }
            return true;
        }

        private async void  btndangky_Clicked(object sender, EventArgs e)
        {
            var ten = usrname.Text;
            var email = txtemail.Text;
            var mk = txtmk.Text;

            //check thong tin dang ky
            if(email != null)
            {
                bool isValidate = validateEmail(email);
                if (isValidate == false)
                {
                    Console.WriteLine(isValidate);
                    await DisplayAlert("Thông báo", "Vui lòng điền email hợp lệ", "OK");
                }
                else
                {
                    if (ten == null || mk == null)
                    {
                        await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin.", "OK");
                    }

                    else if (db.TonTai(ten, email) == true)
                    {
                        await DisplayAlert("Thông báo", "Tài khoản đã tồn tại: Vui lòng nhập tên khác.", "OK");
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
                            await DisplayAlert("Thông báo", "Chúc mừng đăng ký thành công", "Bắt đầu thôi");
                            Navigation.PushAsync(new SignIn());
                        }
                        else
                        {
                            DisplayAlert("Thông báo", "Đăng ký không thành công. Vui lòng thử lại", "OK");
                        }

                    }
                }

                
            }   
        }

        private void btnhuy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}