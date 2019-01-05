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
            InitializeComponent();
            database.CreateDatabase();
            deathWatchUnitsData.DeathWatchUnitsSetup();
            MainPage = new MainPage();  
		}

		protected override void OnStart (){}
		protected override void OnSleep (){}
		protected override void OnResume (){} 
    }
}
