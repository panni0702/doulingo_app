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
    public partial class MucTieu : ContentPage
    {
        List<Aim> aimList;
        string[] DouLogo = new string[] {"dou.gif", "dou4.png", "dou5.png"};
        void AimInit()
        {
            aimList = new List<Aim>();
            aimList.Add(new Aim { aimName = "Dễ", aimDes = "5 phút mỗi ngày" });
            aimList.Add(new Aim { aimName = "Vừa", aimDes = "10 phút mỗi ngày" });
            aimList.Add(new Aim { aimName = "Khó", aimDes = "15 phút mỗi ngày" });
            aimList.Add(new Aim { aimName = "Rất khó", aimDes = "20 phút mỗi ngày" });

            lstmuctieu.ItemsSource = aimList;
        }
        public MucTieu()
        {
            InitializeComponent();
            AimInit();
        }


        private void continue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CapDo());
        }

        private void lstmuctieu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Aim aim = (Aim)e.SelectedItem;
        }

        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}