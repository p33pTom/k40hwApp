using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace am40k
{
    public partial class App : Application
	{
        Database database = new Database();
        DeathWatchUnitsDataSetup deathWatchUnitsData = new DeathWatchUnitsDataSetup();

        public App ()
		{
            MainPage = new MainPage();
            ContentPage RosterPage = new ContentPage();
            InitializeComponent();
            database.CreateDatabase();
            deathWatchUnitsData.DeathWatchUnitsSetup();
            
		}

		protected override void OnStart (){}
		protected override void OnSleep (){}
		protected override void OnResume (){}
    }
}
