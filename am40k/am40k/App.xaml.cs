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
            database.DropTables();
            database.CreateDatabase();

            //---DETACHMENTS TYPES SETUP---
            SetupDetachmentsTypes.InitializeDetachmentsTypes();

            //---UNITS SETUP---
            //***DEATHWATCH***
            deathWatchUnitsData.DeathWatchUnitsSetup();

            //---UPDATE TABLES WITH FOREIGN KEYS
            //database.UpdateTablesWithForeignKeys();

            //---INIT MAIN PAGE
            InitializeComponent();

            MainPage = new MainPage();
            ContentPage RosterPage = new ContentPage();
        }

		protected override void OnStart (){}
		protected override void OnSleep (){}
		protected override void OnResume (){}
    }
}
