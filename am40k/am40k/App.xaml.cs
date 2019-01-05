using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace am40k
{
    public partial class App : Application
	{
        Database database = new Database();
        DeathWatchUnitsDataSetup deathWatchUnitsData = new DeathWatchUnitsDataSetup();

        public App ()
		{
            database.CreateDatabase();
            deathWatchUnitsData.DeathWatchUnitsHQSetup();
            InitializeComponent();
			MainPage = new MainPage();
            
            
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		} 
    }
}
