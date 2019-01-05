using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace am40k
{
    public class UnitsPageViewModel : ViewModelBase
    {
        public IList<Unit> Units { get { return UnitData.Units; } }

        Unit selectedUnit;

        public Unit SelectedUnit
        {
            get { return selectedUnit; }

            set
            {
                if (selectedUnit != value)
                {
                    selectedUnit = value;
                    
                    OnPropertyChanged();
                }
            }
        }
    }
}
