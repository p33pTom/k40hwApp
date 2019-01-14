using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace am40k
{
    public class PatrolDetachment
    {
        List<Units> Units = new List<Units>();

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

        public void GetPatrolDetachmentRules()
        {

        }
    }

}
