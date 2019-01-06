using Xamarin.Forms;

namespace am40k
{
    public partial class RosterPage : ContentPage
    {

        MainPage MainPage = new MainPage();
        Database Database = new Database();

        public RosterPage()
        {
            Button BackToMainPageButton = new Button()
            {
                Text = "Back to Main Page"
            };

            //Create page content
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new Label {Text = "ROSTER YOBA!!!", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center},
                        BackToMainPageButton
                    }
                }
            };
        }
    }
}