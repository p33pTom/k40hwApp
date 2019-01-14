using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using Android.Util;

namespace am40k
{
    public partial class MainPage : ContentPage
	{
        Database database = new Database();
        List<Units> Units = new List<Units>();
        //RosterPage RosterPage = new RosterPage();
        DetachmentsTypes DetachmentTypes = new DetachmentsTypes();
        SetupDetachmentsTypes SetupDetachmentsTypes = new SetupDetachmentsTypes();


        public MainPage()
        {
            //ARMY PICKER - STATIC AND POPULATE
            Picker ArmyPicker = new Picker { Title = "Select Army (Faction)", };
            //ArmyPicker.BackgroundColor = Color.FromHex("#666666");
            var Armies = database.GetArmies();
            foreach (Units unit in Armies)
            {
                ArmyPicker.Items.Add(unit.ArmyOf);
            }

            //DETACHMENT PICKER
            Picker DetachmentPicker = new Picker { Title = "Specify Detachment" };
            //DetachmentPicker.BackgroundColor = Color.FromHex("#666666");
            var DetachmentTypes = SetupDetachmentsTypes.GetDetachments();
            foreach (DetachmentsTypes Detachment in DetachmentTypes)
            {
                DetachmentPicker.Items.Add(Detachment.DetachmentTypeCaption);
            }

            Button AddDetachment = new Button
            {
                //BackgroundColor = Color.FromHex("#666666"),
                Text = "Add Detachment"
            };
            

            //UNIT PICKER STATIC AND POPULATE
            Picker UnitPicker = new Picker { Title = "Select unit...", IsVisible = false};

            //Add Unit BUTTON
            Button AddUnit = new Button
            {
                IsVisible = false,
                Text = "Add Unit"
            };

            void AddUnitButton_Clicked(object sender, System.EventArgs e)
            {
                var SelectedUnit = UnitPicker.Items[UnitPicker.SelectedIndex];
                try
                {
                    using (var conn = new SQLiteConnection(System.IO.Path.Combine(database.DbFolder, database.DbName)))
                    {
                        string query = string.Format("INSERT INTO Rosters (Unit) VALUES ('{0}')", SelectedUnit);
                        conn.Query<Rosters>(query);
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                }
            }
            AddUnit.Clicked += AddUnitButton_Clicked;


            void AddDetachmentButton_Clicked (object sender, System.EventArgs e)
            {
                try
                {
                    var SelectedArmy = ArmyPicker.Items[ArmyPicker.SelectedIndex];
                    var SelectedDetachmentType = DetachmentPicker.Items[DetachmentPicker.SelectedIndex];
                    using (var conn = new SQLiteConnection(System.IO.Path.Combine(database.DbFolder, database.DbName)))
                    {
                        conn.BeginTransaction();
                        var SelectedDetachmentTypeId = string.Format("SELECT DetachmentTypeId FROM DetachmentsTypes where DetachmentTypeCaption = '{0}'", SelectedDetachmentType);
                        var TypeId = conn.Query<DetachmentsTypes>(SelectedDetachmentTypeId);
                        string CreateRoster = string.Format("INSERT INTO Rosters (DetachmentTypeId) VALUES ('{0}')", TypeId);
                        string CreateDetachQuery = string.Format("INSERT INTO UserDetachments (R.RosterId, R.DetachmentTypeId) " +
                                                                "SELECT RosterId, DetachmentTypeId FROM Rosters AS R " +
                                                                "JOIN DetachmentsTypes AS DT " +
                                                                "ON R.DetachmentTypeId = DT.DetachmentTypeId " +
                                                                "WHERE DT.DetachmentTypeCaption = '{0}'", SelectedDetachmentType);
                        conn.Query<Rosters>(CreateRoster);
                        var RosterResult = string.Format("SELECT RosterId FROM Rosters");
                        conn.Query<Rosters>(RosterResult);
                        conn.Query<UserDetachments>(CreateDetachQuery);
                        string Result = string.Format("SELECT DetachmentId FROM UserDetachments;");
                        List<UserDetachments> VASYA = conn.Query<UserDetachments>(Result);
                        RosterPage RosterPage = new RosterPage();

                        conn.Commit();
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Error("SQLiteEx", ex.Message);
                }
            }
            AddDetachment.Clicked += AddDetachmentButton_Clicked;

            //ROSTER PAGE BUTTON
            Button RosterPageButton = new Button
            {
                Text = "GO TO ROSTER PAGE"
            };
            RosterPageButton.Clicked += RosterPageButton_Clicked;
                
            //populate Unit picker.
            ArmyPicker.SelectedIndexChanged += (sender, e) =>
            {
                UnitPicker.IsVisible = true;
                AddUnit.IsVisible = true;
                UnitPicker.Items.Clear();
                foreach (Units unit in database.GetUnitNames())
                {
                    {
                        UnitPicker.Items.Add(unit.Name);
                    }
                }
            };

            Label GenerateRosterMainPage = new Label
            {
                Text = "Generate your Roster",
                TextColor = Color.White,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black,
            };

            //Create page content
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    BackgroundColor = Color.FromHex("#F7F7F7"),
                    Children =
                    {
                        GenerateRosterMainPage,
                        ArmyPicker,
                        DetachmentPicker,
                        AddDetachment,
                        new Label {Text = "", BackgroundColor = Color.Black, HorizontalOptions = LayoutOptions.FillAndExpand },
                        UnitPicker,
                        AddUnit,
                        RosterPageButton
                    }
                }                              
            };
        }
        private void RosterPageButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new RosterPage());
        }

        private void AddDetachmentButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new RosterPage());
            
        }
    }
}
 