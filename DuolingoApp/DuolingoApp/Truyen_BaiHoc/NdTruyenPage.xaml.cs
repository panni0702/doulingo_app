using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DuolingoApp.Classes;

namespace DuolingoApp.Truyen_BaiHoc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NdTruyenPage : ContentPage
    {
        async void LayTuTheoTruyen(truyen t)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://qltruyenapi.somee.com/api/ServiceController/LayDsTuTheoTruyen?matruyen=" + t.Matruyen.ToString());
            List<tumoi> dstu = JsonConvert.DeserializeObject<List<tumoi>>(chuoi);
            lsttu.ItemsSource = dstu;
        }
        
        public NdTruyenPage()
        {
            InitializeComponent();
        }

        public NdTruyenPage(truyen t)
        {
            InitializeComponent();
            
            LayTuTheoTruyen(t);
            txtten.Text = t.Tentruyen;
            txtnd.Text = t.Noidung;
            img.Source = t.Hinh;
        }
        private void lsttu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                tumoi t;
                t = (tumoi)e.Item;
                Navigation.PushAsync(new TuMoiPage(t));
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button nutchon = (Button)sender;
            tumoi t = (tumoi)nutchon.CommandParameter;
            Navigation.PushModalAsync(new TuMoiPage(t));
        }
    }
}