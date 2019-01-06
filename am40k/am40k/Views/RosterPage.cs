using Xamarin.Forms;

namespace am40k
{
	public class RosterPage : ContentPage
	{
        readonly MainPage MainPage = new MainPage();
        readonly Database Database = new Database();

        public RosterPage ()
		{
            Button BackToMainPageButton = new Button()
            {
                Text = "Back to Main Page"
            };

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new Label {Text = "ROSTERS YOBA!", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center},
                        BackToMainPageButton
                    }
                }
            };
        }
	}
}