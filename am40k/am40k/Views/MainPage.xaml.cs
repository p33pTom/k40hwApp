using System.Collections.Generic;
using Xamarin.Forms;

namespace am40k
{
    public partial class MainPage : ContentPage
	{
        Database database = new Database();
        List<Army> Armies = new List<Army>(); 
        List<Unit> Units = new List<Unit>();

        public MainPage()
        {

            var ArmyPicker = new Picker { Title = "Select an army..." };

            var UnitPicker = new Picker { Title = "Select unit...", IsVisible = false};

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
                        new Label {Text = "Armies:", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center},
                        ArmyPicker ,
                        UnitPicker,
                        AddButton
                    }
                }                              
            };
        }
    }
}
 