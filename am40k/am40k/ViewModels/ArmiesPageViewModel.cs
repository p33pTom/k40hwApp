using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace am40k
{
    public class ArmiesPageViewModel : ViewModelBase
    {
        public IList<Army> Armies { get { return ArmyData.Armies; } }

        Army selectedArmy;

        public Army SelectedArmy
        {
            get { return selectedArmy; }
            set
            {
                if (selectedArmy != value)
                {
                    selectedArmy = value;
                    OnPropertyChanged();

                }
            }
        }
    }
}
