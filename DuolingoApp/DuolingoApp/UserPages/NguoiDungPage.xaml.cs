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
    public partial class NguoiDungPage : ContentPage
    {
        Database db = new Database();
        User u;
        public NguoiDungPage()
        {
            InitializeComponent();
            Thu();
        }
        public NguoiDungPage(User nd)
        {
            InitializeComponent();
            u = nd;
            HienThi(nd);
        }

        void HienThi(User nd)
        {
            txtten.Text = nd.TenND;
            txtemail.Text = nd.Email;
            txtdiem.Text = nd.Diem.ToString();
            img.Source = nd.Hinh;
            KhoiTao();
        }
        public NguoiDungPage(string ten, string hinh, string email)
        {
            InitializeComponent();
            txtten.Text = ten;
            txtemail.Text = email;
            img.Source = hinh;
            KhoiTao();
        }

        void KhoiTao()
        {
            List<User> nds = new List<User>();
            nds = db.LayTopND();
            lstnd.ItemsSource = nds;
        }
        void Thu()
        {
            List<User> nds = new List<User>();
            nds.Add(
                new User
                {
                    TenND = "Marge",
                    Email = "user1@gmail.com",
                    Hinh = "profile_friends_marge.png",
                    Diem = 150
                });
            nds.Add(
                new User
                {
                    TenND = "Lisa",
                    Email = "user2@gmail.com",
                    Hinh = "profile_friends_lisa.png",
                    Diem = 320
                });
            nds.Add(
                new User
                {
                    TenND = "Homer",
                    Email = "user3@gmail.com",
                    Hinh = "profile_friends_homer.png",
                    Diem = 60
                });
            nds.Add(
                new User
                {
                    TenND = "HuaHua",
                    Email = "user4@gmail.com",
                    Hinh = "dc_1.jpg",
                    Diem = 360
                });
            nds.Add(
                new User
                {
                    TenND = "Nagisa",
                    Email = "user5@gmail.com",
                    Hinh = "dc_4.jfif",
                    Diem = 150
                });
            lstnd.ItemsSource = nds;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChinhSuaPage(u));
        }

        private async void btndx_Clicked(object sender, EventArgs e)
        {

             Navigation.PopModalAsync();
            await Navigation.PushAsync(new MainPage());

        }

        private void img_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChinhSuaPage(u));
        }

        private async void btnmk_Clicked(object sender, EventArgs e)
        {
            var mk = new MatKhauPage(u);
            await Navigation.PushModalAsync(mk);
        }

        private void lstnd_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            User u1 = db.LayNd(u.TenND);
            HienThi(u1);
        }
    }
}