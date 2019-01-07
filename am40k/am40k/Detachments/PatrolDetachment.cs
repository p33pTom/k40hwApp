using System;
using System.Collections.Generic;
using System.Text;

namespace am40k.Detachments
{
    public class PatrolDetachment
    {
        List<Unit> Units = new List<Unit>();

        public PatrolDetachment() { }

        public int HqQuantity, TroopsQuantity, Elites, FastAttack, HeavySupport, Flyers;

        public PatrolDetachment(int hqQuantity, int troopsQuantity, int elites, int fastAttack, int heavySupport, int flyers)
        {
            HqQuantity = hqQuantity;
            TroopsQuantity = troopsQuantity;
            Elites = elites;
            FastAttack = fastAttack;
            HeavySupport = heavySupport;
            Flyers = flyers;
        }
    }
}
