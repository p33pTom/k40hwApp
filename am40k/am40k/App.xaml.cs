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
            InitializeComponent();
            MainPage = new MainPage();
		}

		protected override void OnStart ()
        {
            database.CreateDatabase();
            deathWatchUnitsData.DeathWatchUnitsSetup();
        }
		protected override void OnSleep (){}
		protected override void OnResume (){}
    }
}
