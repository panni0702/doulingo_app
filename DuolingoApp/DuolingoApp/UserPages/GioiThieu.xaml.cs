using DuolingoApp.Classes;
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
    public partial class GioiThieu : ContentPage
    {
        List<Introduce> introduceArr;
        public GioiThieu()
        {
            InitializeComponent();
            AddIntroduce();
            CarVIntroduce.ItemsSource = introduceArr;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                CarVIntroduce.Position = (CarVIntroduce.Position + 1) % introduceArr.Count;
                return true;
            }));
        
        }

        private void AddIntroduce()
        {
            introduceArr = new List<Introduce>();
            introduceArr.Add(new Introduce { Text = "3.600+ Từ vựng", Image="dictionary.png" });
            introduceArr.Add(new Introduce { Text = "7.600+ câu", Image = "pencil.png" });
            introduceArr.Add(new Introduce { Text = "Gọi món và hỏi đường như người bản địa.", Image = "map.png" });
            introduceArr.Add(new Introduce { Text = "Hỗ trợ giúp lớp học của bạn nổi bật ở trường.", Image = "lightbulb.png" });
            introduceArr.Add(new Introduce { Text = "Đáp ứng yêu cầu thăng tiến và sự nghiệp", Image = "growth.png" });
        }

        private void continue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MucTieu());
        }


    }
}