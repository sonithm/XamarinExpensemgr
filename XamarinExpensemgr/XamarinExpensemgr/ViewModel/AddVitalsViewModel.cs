using MvvmHelpers;
using ExpenseMgr.Model;
using ExpenseMgr.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpenseMgr.ViewModel
{
    public class AddVitalsViewModel : BaseViewModel
    {
        AzureService azureService;
        public AddVitalsViewModel()
        {
            azureService = DependencyService.Get<AzureService>();
        }
        double dblPrice;
        public double Price
        {
            get { return dblPrice; }
            set
            {
                if (dblPrice == value) return;
                dblPrice = value;
                OnPropertyChanged();
            }
        }
        double dblBmi;
        public double Quantity
        {
            get { return dblBmi; }
            set
            {
                if (dblBmi == value) return;
                dblBmi = value;
                OnPropertyChanged();
            }
        }
        double dblTotal;
        public double Total
        {
            get { return dblTotal; }
            set
            {
                if (dblTotal == value) return;
                dblTotal = value;
                OnPropertyChanged();
            }
        }

        ICommand mSaveVitals;
        public ICommand SaveVitalsCommand =>
                mSaveVitals ??
                (mSaveVitals = new Command(async () => await SaveVitalsAsync()));


        async Task SaveVitalsAsync()
        {
            //if (IsBusy || !(await LoginAsync()))
            //    return;
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                var vVitalDetails = new ExpenseMaster()
                {
                    UsrEmail = "sonith2017@hotmail.com",
                    DateTaken = DateTime.Today,
                    Price = Convert.ToDecimal(dblPrice),
                    Quantity = Convert.ToDecimal(dblBmi),
                    Total = Convert.ToDecimal(dblTotal)
                };
               await azureService.AddVitals(vVitalDetails);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);
                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync coffees, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
