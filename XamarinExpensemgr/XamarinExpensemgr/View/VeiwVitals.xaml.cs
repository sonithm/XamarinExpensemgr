using ExpenseMgr.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseMgr.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VeiwVitals : ContentPage
    {
        public VeiwVitals()
        {
            InitializeComponent();
            var vmAddVitals = new VitalListViewModel();
            BindingContext = vmAddVitals;
        }
    }
}
