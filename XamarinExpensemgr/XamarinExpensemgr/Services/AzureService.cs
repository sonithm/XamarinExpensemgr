using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using ExpenseMgr.Model;
using ExpenseMgr.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]
namespace ExpenseMgr.Services
{
    public class AzureService
    {
        public MobileServiceClient Client { get; set; } = null;
        IMobileServiceSyncTable<AppUser> mAppUserTable;
        IMobileServiceSyncTable<ExpenseMaster> mExpenseMasterTable;
        public static bool UseAuth { get; set; } = false;

        public async Task Initialize()
        {
            if (Client?.SyncContext?.IsInitialized ?? false)
                return;
            var appUrl = "http://sonith.azurewebsites.net/";
           //Create our client
            Client = new MobileServiceClient(appUrl);
            //InitialzeDatabase for path
            var path = "expense.db";
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

            //setup our local sqlite store and intialize our table
            var store = new MobileServiceSQLiteStore(path);

            //Define table
            store.DefineTable<AppUser>();
            store.DefineTable<ExpenseMaster>();

            //Initialize SyncContext
            await Client.SyncContext.InitializeAsync(store);

            //Get our sync table that will call out to azure
            mAppUserTable = Client.GetSyncTable<AppUser>();
            mExpenseMasterTable = Client.GetSyncTable<ExpenseMaster>();

        }

        public async Task SyncVitals()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    return;

                await mExpenseMasterTable.PullAsync("allVitals", mExpenseMasterTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Vitals, that is alright as we have offline capabilities: " + ex);
            }

        }

        public async Task<IEnumerable<ExpenseMaster>> GetVitals()
        {
            //Initialize & Sync
            await Initialize();
            await SyncVitals();

            return await mExpenseMasterTable.OrderBy(c => c.DateTaken).ToEnumerableAsync(); ;

        }

        public async Task<bool> AddVitals(ExpenseMaster aExpenseMaster)
        {
            await Initialize();
            await mExpenseMasterTable.InsertAsync(aExpenseMaster);
            await SyncVitals();
            //return coffee
            return true;
        }

    }

}
