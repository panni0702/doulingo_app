using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DuolingoApp.Classes;

namespace DuolingoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Database db = new Database();
            QuestionDatabase qdb = new QuestionDatabase();
            db.CreateDatabase();
            qdb.CreateDatabase();

            MainPage = new NavigationPage(new MainPage());

            // Xem danh sách câu hỏi
            //MainPage = new Page2();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
