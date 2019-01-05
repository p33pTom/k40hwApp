using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace am40k
{
    public static class UnitData
    {  
        public static IList<Unit> Units { get; private set; }
        static UnitData()
        {
            Units = new List<Unit>
            {
                new Unit
                {
                    UnitCaption = "",
                    ModelsInUnit = 1,
                    UnitShortName = "GK"
                },

                new Unit
                {
                    UnitCaption = "Strike Squad",
                    ModelsInUnit = 5,
                    UnitShortName = "GK"
                },

                new Unit
                {
                    UnitCaption = "Nemesis Dreadnight",
                    ModelsInUnit = 1,
                    UnitShortName = "GK"
                }
            };
        }

    }
}
