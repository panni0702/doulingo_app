using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DuolingoApp.Classes;
using DuolingoApp.UserPages;

namespace DuolingoApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            QuestionDatabase db = new QuestionDatabase();
            List<Question> lstq;
            lstq = db.SelectAllQuestions();
            if (lstq.Count == 0)
            {
                db.CreateQuestion();
            }
        }

        private void cmdstart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GioiThieu());
        }

        private void cmdtk_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignIn());
        }




    }
}
