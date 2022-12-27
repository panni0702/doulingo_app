using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DuolingoApp.Classes;
using DuolingoApp.Truyen_BaiHoc;
using DuolingoApp.UserPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DuolingoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : TabbedPage
    {
        Database db = new Database();
        User u;
        public TabPage(User nd)
        {
            InitializeComponent();
            u = nd;
            KhoiTao(u);
        }

        void KhoiTao(User nd)
        {
            var bh = new NavigationPage(new BaiHocPage(nd))
            {
                Title = "Trang Chủ",
                IconImageSource = "tab_lessons.png"
            };
            

            var tr = new NavigationPage(new TruyenPage(nd))
            {
                Title = "Kho Truyện",
                IconImageSource = "tab_stories.png"
            };

            var hs = new NavigationPage(new NguoiDungPage(nd))
            {
                Title = "Hồ Sơ",
                IconImageSource = "tab_profile.png"
            };
            Children.Add(bh);
            Children.Add(tr);
            Children.Add(hs);
        }

        protected override void OnCurrentPageChanged()
        {
            Console.WriteLine(Children.Count);
            if(Children.Count == 3)
            {
                if (Children != null && CurrentPage == Children[0])
                {
                    Children[0].IconImageSource = "tab_lessons_selected.png";
                    Children[1].IconImageSource = "tab_stories.png";
                    Children[2].IconImageSource = "tab_profile.png";
                }
                else if (Children != null && CurrentPage == Children[1])
                {
                    Children[0].IconImageSource = "tab_lessons.png";
                    Children[1].IconImageSource = "tab_stories_selected.png";
                    Children[2].IconImageSource = "tab_profile.png";
                }
                else if (Children != null && CurrentPage == Children[2])
                {
                    Children[0].IconImageSource = "tab_lessons.png";
                    Children[1].IconImageSource = "tab_stories.png";
                    Children[2].IconImageSource = "tab_profile_selected.png";
                }
            }
            
            
            
            base.OnCurrentPageChanged();
        }
    }
}