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
    public partial class TongQuan : ContentPage
    {
        public TongQuan()
        {
            InitializeComponent();
        }

        private void continue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MucTieu());
        }

        private void test_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GioiThieu());
        }
    }
}