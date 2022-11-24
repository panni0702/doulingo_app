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
    public partial class TuMoiPage : ContentPage
    {
        public TuMoiPage()
        {
            InitializeComponent();
        }

        public TuMoiPage(tumoi tm)
        {
            InitializeComponent();
            txttu.Text = tm.tentu;
            txtnghia1.Text = tm.nghia1;
            txtnghia2.Text = tm.nghia2;
            txtvidu.Text = tm.vidu;

            LayDsTuDN(tm);
            LayDsTuTN(tm);
        }

        async void LayDsTuDN(tumoi t)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://qltruyenapi.somee.com/api/ServiceController/LayDsTuDongNghia?matu=" + t.matu.ToString());
            var dstu = JsonConvert.DeserializeObject<List<tudn>>(chuoi);
            lstdn.ItemsSource = dstu;
        }

        async void LayDsTuTN(tumoi t)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://qltruyenapi.somee.com/api/ServiceController/LayDsTuTraiNghia?matu=" + t.matu.ToString());
            var dstu = JsonConvert.DeserializeObject<List<tutn>>(chuoi);
            lsttn.ItemsSource = dstu;
        }
    }
}