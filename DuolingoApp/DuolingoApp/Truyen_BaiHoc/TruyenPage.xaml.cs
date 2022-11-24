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
    public partial class TruyenPage : ContentPage
    {
        Database db = new Database();
        User u;
        public TruyenPage()
        {
            InitializeComponent();
            //Thu();
        }

        public TruyenPage(User nd)
        {
            InitializeComponent();
            u = nd;
            HienThiDsTruyen();
            HienThi(nd);
            //KhoiTao();

        }
        void HienThi(User nd)
        {
            txtdiem.Text = nd.Diem.ToString();
            txtten.Text = nd.TenND;

        }
        async void HienThiDsTruyen()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://qltruyenapi.somee.com/api/ServiceController/LayDsTruyen");
            var dstr = JsonConvert.DeserializeObject<List<truyen>>(chuoi);
            lsttr.ItemsSource = dstr;
        }

        private void lsttr_ItemTapped_1(object sender, ItemTappedEventArgs e)
        {
            User u1 = db.LayNd(u.TenND);
            HienThi(u1);
            
            if (e.Item != null)
            {
               
                truyen t;
                t = (truyen)e.Item;
                Navigation.PushAsync(new NdTruyenPage(t));
            }    
        }

        /*
        private void Button_Clicked(object sender, EventArgs e)
        {
            Button nutchon = (Button)sender;
            truyen tr = (truyen)nutchon.CommandParameter;

            Navigation.PushModalAsync(new NdTruyenPage(tr));
        }
        */
    }
}