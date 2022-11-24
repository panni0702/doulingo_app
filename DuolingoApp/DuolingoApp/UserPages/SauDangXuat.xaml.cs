using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DuolingoApp.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SauDangXuat : ContentPage
    {
        public SauDangXuat()
        {
            InitializeComponent();
        }

        private void signin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignIn());
        }

        private void startnow_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TongQuan());
        }
    }
}