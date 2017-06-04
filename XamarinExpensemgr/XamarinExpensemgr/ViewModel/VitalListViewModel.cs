using MvvmHelpers;
using ExpenseMgr.Model;
using ExpenseMgr.Services;
using ExpenseMgr.View;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpenseMgr.ViewModel
{
    public class VitalListViewModel : BaseViewModel
    {
        AzureService azureService;
        public VitalListViewModel()
        {
            azureService = DependencyService.Get<AzureService>();
        }
        public ObservableRangeCollection<ExpenseMaster> VitalsList { get; } = new ObservableRangeCollection<ExpenseMaster>();
        string loadingMessage;
        public string LoadingMessage
        {
            get { return loadingMessage; }
            set { SetProperty(ref loadingMessage, value); }
        }

        ICommand loLoadVitalsCommand;
        public ICommand LoadExpenseMaster =>
            loLoadVitalsCommand ?? (loLoadVitalsCommand = new Command(async () => await ExecuteLoadVitalsCommandAsync()));

        async Task ExecuteLoadVitalsCommandAsync()
        {
            //if (IsBusy || !(await LoginAsync()))
            //    return;
            try
            {
                LoadingMessage = "Loading Vitals...";
                IsBusy = true;
                var vResultList = await azureService.GetVitals();
                VitalsList.ReplaceRange(vResultList);
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
