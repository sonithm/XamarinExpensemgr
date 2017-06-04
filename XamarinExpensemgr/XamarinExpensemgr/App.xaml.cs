
using Xamarin.Forms;

namespace ExpenseMgr
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ExpenseMgr.MainPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#C3006B")
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
