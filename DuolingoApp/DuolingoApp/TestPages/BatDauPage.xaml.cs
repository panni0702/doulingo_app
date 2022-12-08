using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuolingoApp.Classes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DuolingoApp.TestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BatDauPage : ContentPage
    {
        BaiHoc b;
        public BatDauPage()
        {
            InitializeComponent();
            img.Source = "dou3min.gif";
        }

        public BatDauPage(BaiHoc bh)
        {
            InitializeComponent();
            b = bh;
            txtbh.Text = b.TenBH;
            img.Source = b.Hinh;
        }

        private void gotoTest_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestPage());
        }
    }
}