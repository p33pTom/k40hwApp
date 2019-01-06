using System.Collections.Generic;
using Xamarin.Forms;

namespace am40k
{
    public partial class MainPage : ContentPage
	{
        Database database = new Database();
        List<Unit> Units = new List<Unit>();
        RosterPage RosterPage = new RosterPage();

        public MainPage()
        {
            //ARMY PICKER - STATIC AND POPULATE
            var ArmyPicker = new Picker { Title = "Select an army...", };
            var Armies = database.GetArmies();
            foreach (Unit unit in Armies)
            {
                ArmyPicker.Items.Add(unit.ArmyOf);
            }

            //UNIT PICKER STATIC AND POPULATE
            var UnitPicker = new Picker { Title = "Select unit...", IsVisible = false};

            //Add Unit BUTTON
            Button AddButton = new Button
            {
                Text = "Add Unit"
            };

            //ROSTER PAGE BUTTON
            Button RosterPageButton = new Button
            {
                Text = "GO TO ROSTER PAGE"
            };

            AddButton.Clicked += AddButton_Clicked;
                
            //populate Unit picker.
            ArmyPicker.SelectedIndexChanged += (sender, e) =>
            {
                UnitPicker.IsVisible = true;
                UnitPicker.Items.Clear();
                foreach (Unit unit in database.GetUnitNames())
                {
                    {
                        UnitPicker.Items.Add(unit.Name);
                    }
                }
            };
            
            //Create page content
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new Label {Text = "YOBA? ETO TI?", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center},
                        ArmyPicker ,
                        UnitPicker,
                        AddButton,
                        RosterPageButton
                    }
                }                              
            };
        }

        private async void AddButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(RosterPage);
        }       
    }
}
 