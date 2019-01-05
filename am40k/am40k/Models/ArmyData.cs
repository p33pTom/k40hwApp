using System;
using System.Collections.Generic;
using System.Text;

namespace am40k
{
    public static class ArmyData
    {
        public static IList<Army> Armies { get; private set; }

        static ArmyData()
        {
            Armies = new List<Army>
            {
                new Army
                {
                    ArmyId = 1,
                    ArmyShortName = "GK",
                    ArmyCaption = "Grey Knights",
                },

                new Army
                {
                    ArmyId = 2,
                    ArmyShortName = "DG",
                    ArmyCaption = "Death Guard",
                },

                new Army
                {
                    ArmyId = 3,
                    ArmyShortName = "AdMch",
                    ArmyCaption = "Adeptus Mechanicus",
                },

                new Army
                {
                    ArmyId = 4,
                    ArmyShortName = "DW",
                    ArmyCaption = "Deathwatch",
                }
            };
        }
    }
}
