using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace am40k
{
    public partial class App : Application
	{
        Database database = new Database();
        SetupDetachmentsTypes SetupDetachmentsTypes = new SetupDetachmentsTypes();
        DeathWatchUnitsDataSetup deathWatchUnitsData = new DeathWatchUnitsDataSetup();

        public App ()
		{
            MainPage = new MainPage();
            ContentPage RosterPage = new ContentPage();
            InitializeComponent();
            database.CreateDatabase();

            //---DETACHMENTS TYPES SETUP---
            SetupDetachmentsTypes.InitializeDetachmentsTypes();

            //---UNITS SETUP---
            //***DEATHWATCH***
            deathWatchUnitsData.DeathWatchUnitsSetup();
            
		}

		protected override void OnStart (){}
		protected override void OnSleep (){}
		protected override void OnResume (){}
    }
}
