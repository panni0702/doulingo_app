using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuolingoApp.Classes;
using DuolingoApp.TestPages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DuolingoApp.Truyen_BaiHoc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaiHocPage : ContentPage
    {
        Database db = new Database();
        User u; BaiHoc bh;
        public BaiHocPage(User nd)
        {
            InitializeComponent();
            u = nd;
            Thu();
            HienThi(nd);

        }
        void HienThi(User nd)
        {
            txtdiem.Text = nd.Diem.ToString();
            txtten.Text = nd.TenND;
        }
        public BaiHocPage()
        {
            InitializeComponent();
            Thu();
            Navigation.PushAsync(new BaiHocPage(u));
        }
        void Thu()
        {
            List<GroupBH> dsgbh = new List<GroupBH>();
            GroupBH b1 = new GroupBH(1, new List<BaiHoc>
            {
                new BaiHoc
                {
                    MaBH = 1,
                    TenBH = "Family",
                    Hinh = "family.png",
                    MaChang = 1,
                    Diem = 40,
                    ThanhTich = "crown_stroke.png"
                },
                new BaiHoc
                {
                    MaBH = 2,
                    TenBH = "Travel",
                    Hinh = "lesson_bag.png",
                    MaChang = 1,
                    Diem = 40,
                    ThanhTich = "crown_stroke.png"
                },
                new BaiHoc
                {
                    MaBH = 3,
                    TenBH = "Food",
                    Hinh = "lesson_egg.png",
                    MaChang = 1,
                    Diem = 40,
                    ThanhTich = "crown_stroke.png"

                }
            });
            dsgbh.Add(b1);

            GroupBH b2 = new GroupBH(2, new List<BaiHoc>
            {
                new BaiHoc
                {
                    MaBH = 4,
                    TenBH = "Pencil",
                    Hinh = "lesson_pencil.png",
                    MaChang = 2,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"

                },
                new BaiHoc
                {
                    MaBH = 5,
                    TenBH = "Bike",
                    Hinh = "lesson_bike.png",
                    MaChang = 2,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"
                },
                new BaiHoc
                {
                    MaBH = 6,
                    TenBH = "Hat",
                    Hinh = "lesson_hat.png",
                    MaChang = 2,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"

                }
            });
            dsgbh.Add(b2);

            GroupBH b3 = new GroupBH(3, new List<BaiHoc>
            {
                new BaiHoc
                {
                    MaBH = 7,
                    TenBH = "Baby",
                    Hinh = "lesson_baby.png",
                    MaChang = 3,
                    Diem = 80,
                    ThanhTich = "crown_stroke.png"

                },
                new BaiHoc
                {
                    MaBH = 8,
                    TenBH = "Communication",
                    Hinh = "lesson_dialog.png",
                    MaChang = 3,
                    Diem = 80,
                    ThanhTich = "crown_stroke.png"
                },
                new BaiHoc
                {
                    MaBH = 9,
                    TenBH = "Heart",
                    Hinh = "lesson_heart.png",
                    MaChang = 3,
                    Diem = 80,
                    ThanhTich = "crown_stroke.png"

                }
            });
            dsgbh.Add(b3);
            lstbh.ItemsSource = dsgbh;


        }
        private void lstbh_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            HienThi(u);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton nutchon = (ImageButton)sender;
            BaiHoc bh = (BaiHoc)nutchon.CommandParameter;
            PopupNavigation.Instance.PushAsync(new BatDauTest(bh, u));
        }
    }
}