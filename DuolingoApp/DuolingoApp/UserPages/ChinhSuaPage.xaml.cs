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
    public partial class ChinhSuaPage : ContentPage
    {
        Database db;
        User u;
        public ChinhSuaPage()
        {
            InitializeComponent();
        }
        public ChinhSuaPage(User nd)
        {
            InitializeComponent();
            db = new Database();
            u = nd;
            HienThi();
        }
        void HienThi()
        {
            if (u != null)
            {
                txtmand.Text = u.MaND.ToString();
                txtten.Text = u.TenND; ;
                txtemail.Text = u.Email;
                txthinh.Text = u.Hinh;
                img.Source = txthinh.Text;
            }
        }
        private async void btnhuy_Clicked(object sender, EventArgs e)
        {
            var ans = await DisplayAlert("Thông báo", "Thay đổi của bạn sẽ không được lưu lại. Bạn có chắc muốn hủy?", "Yes", "No");
            if (ans)
            {
                 Navigation.PopAsync();
            }
        }

        private void btnluu_Clicked(object sender, EventArgs e)
        {
            var t = txtten.Text;
            var h = txthinh.Text;
            var eml = txtemail.Text;

            User u1 = new User { TenND = txtten.Text, Email = txtemail.Text, Hinh = txthinh.Text, Diem = u.Diem, MatKhau = u.MatKhau };
            if (txtmand.Text != "")
            {
                u1.MaND = int.Parse(txtmand.Text);
                /*if (db.TonTai(txtten.Text, txtemail.Text) == true)
                {
                    DisplayAlert("Thông báo", "Tên Đăng nhập hoặc Email đã có người sử dụng", "OK");
                }
                else*/
                if (db.SuaNguoiDung(u1) == true)
                {
                    u = u1;
                    DisplayAlert("Thông báo", "Cập nhật thông tin thành công", "OK");
                    HienThi();

                }
                else
                    DisplayAlert("Thông báo", "Ghi lỗi", "OK");
            }

        }


        private void btndx_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new NguoiDungPage(u));
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            img.Source = txthinh.Text;
            txthinh.Focus();

        }
    }
}