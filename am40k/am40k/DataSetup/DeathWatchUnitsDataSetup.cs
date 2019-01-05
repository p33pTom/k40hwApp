using SQLite;
using Android.Util;


namespace am40k
{
    public class DeathWatchUnitsDataSetup
    {
        public DeathWatchUnitsDataSetup() {}

        readonly Database database = new Database();

        public bool DeathWatchUnitsHQSetup()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(database.DbFolder, database.DbName)))
                {
                    var test1 = conn.Query<Unit>("SELECT Name FROM Unit");
                    conn.Query<Unit>(deathwatchHQUnitsQuery);
                    var test2 = conn.Query<Unit>("SELECT Name FROM Unit");
                    conn.Query<Unit>(ArmyDWUpdate);
                    var test3 = conn.Query<Unit>("SELECT Name FROM Unit");
                    // CREATE OUTPUT
                    var test4 = conn.Query<Unit>("SELECT Name FROM Unit");
                    return true;
                }
                    
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
            
        }

        //ArmyOf DEATHWATCH HQ update
        readonly string ArmyDWUpdate = "INSERT INTO Unit (ArmyOf) VALUES ('Deathwatch') WHERE Type = 'HQ'";

        //INSERT DEATHWATCH HQ UNITS QUERY:
        readonly string deathwatchHQUnitsQuery = "" +
            "INSERT INTO Unit (Caption, Name, Type) VALUES" +
                        "('WatchMaster','Watch Master', 'HQ')," +
                        "('Artemis', 'Watch Captain Artemis', 'HQ')," +
                        "('WatchCaptain', 'Watch Captain', 'HQ')," +
                        "('WatchCaptainJumpPack', 'Watch Captain with Jump Pack', 'HQ')," +
                        "('WatchCaptainTermoArmour', 'Watch Captain in Terminator Armour', 'HQ')," +
                        "('PrimarisWatchCaptain', 'Primaris Watch Captain', 'HQ')," +
                        "('Librarian', 'Librarian', 'HQ')," +
                        "('LibrarianJumpPack', 'Librarian with Jump Pack', 'HQ')," +
                        "('LibrarianTermoArmour', 'Librarian in Terminator Armour', 'HQ')," +
                        "('PrimarisLibrarian', 'Priamris Librarian', 'HQ')," +
                        "('Chaplain', 'Chaplain', 'HQ')," +
                        "('ChaplainJumpPack', 'Chaplain with Jump Pack', 'HQ')," +
                        "('ChaplainTermoArmour', 'Chaplain in Terminator Armour', 'HQ')," +
                        "('PrimarisChaplain', 'Primaris Chaplain', 'HQ')";

    }
}
