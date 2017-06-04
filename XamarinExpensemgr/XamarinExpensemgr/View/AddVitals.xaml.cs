using ExpenseMgr.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseMgr.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVitals : ContentPage
    {
        public AddVitals()
        {
            InitializeComponent();
            var vmAddVitals = new AddVitalsViewModel();
            BindingContext = vmAddVitals;
        }
    }
}
