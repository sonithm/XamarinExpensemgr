using ExpenseMgr.View;
using ExpenseMgr.ViewModel;
using Xamarin.Forms;

namespace ExpenseMgr
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var vmVitalList = new VitalListViewModel();
            BindingContext = vmVitalList;
        }

        private void AddVitalsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddVitals());
        }
        private void ViewVitalsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new VeiwVitals());
        }
    }
}
