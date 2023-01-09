using DuolingoApp.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace DuolingoApp.Translate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TranslatePage : ContentPage
    {
        User user;
        public TranslatePage()
        {
            InitializeComponent();
        }

        public TranslatePage(User nd)
        {
            InitializeComponent();
            user = nd;
        }

        private async Task<String> TranslateText(string input)
        {

            string urlVI = "http://103.75.185.190:5010/vi/" + input;
            string urlEN = "http://103.75.185.190:5010/en/" + input;
            HttpClient httpClient = new HttpClient();
            if (radioEN.IsChecked)
            {
                var result = await httpClient.GetStringAsync(urlEN);
                return result;
            }
            else if (radioVI.IsChecked){
                var result = await httpClient.GetStringAsync(urlVI);
                return result;
            }
            

            return null;

        }
        private string formatString(string input)
        {
            return input.Split('"')[1];
        } 
        private async  void btnTranlate_Clicked(object sender, EventArgs e)
        {
            var text = input.Text;
            if (text != null)
            {
                var translatedStr = await TranslateText(text);
                
                output.Text = formatString(translatedStr);
            }
            
        }
    }
}