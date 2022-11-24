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
    public partial class Taohs : ContentPage
    {
        public Taohs()
        {
            InitializeComponent();
        }

        private void cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void profile_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Dangky());
        }
    }
}