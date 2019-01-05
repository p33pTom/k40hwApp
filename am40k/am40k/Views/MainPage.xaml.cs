using System.Collections.Generic;
using Xamarin.Forms;

namespace am40k
{
    public partial class MainPage : ContentPage
	{
        Database database = new Database();
        List<Unit> Units = new List<Unit>();

        public MainPage()
        {
            var Armies = database.GetArmies();
            var ArmyPicker = new Picker { Title = "Select an army...", };
            foreach (Unit unit in Armies)
            {
                ArmyPicker.Items.Add(unit.ArmyOf);
            }
            
            //Unit Picker
            var UnitPicker = new Picker { Title = "Select unit...", IsVisible = false};

            //LAUNCH BUTTON
            Button Launch = new Button
            {
                Text = "LAUNCH THE SHIT",
                CornerRadius = 10,
                BorderWidth = 2,
            };

            //Add Unit BUTTON
            Button AddButton = new Button
            {
                Text = "Add Unit"
            };
            
            
            //populate Unit picker.
            ArmyPicker.SelectedIndexChanged += (sender, e) =>
            {
                UnitPicker.IsVisible = true;
                UnitPicker.Items.Clear();
                var UnitNames = database.GetUnitNames();
                foreach (Unit unit in UnitNames)
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
                        Launch
                    }
                }                              
            };
        }
    }
}
 