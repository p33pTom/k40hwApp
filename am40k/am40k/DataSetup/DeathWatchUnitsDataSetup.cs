using SQLite;
using Android.Util;


namespace am40k
{
    public class DeathWatchUnitsDataSetup
    {
        public DeathWatchUnitsDataSetup() {}

        Database database = new Database();

        public bool DeathWatchUnitsSetup()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(database.DbFolder, database.DbName)))
                {
                    conn.Query<Unit>(deathwatchHQUnitsQuery);
                    return true;
                }
                    
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
            
        }

        //INSERT DEATHWATCH HQ UNITS QUERY:
        readonly string deathwatchHQUnitsQuery = "" +
            "INSERT INTO Unit (Caption, Name, Type, ArmyOf) VALUES" +
                        "('WatchMaster','Watch Master', 'HQ', 'Deathwatch')," +
                        "('Artemis', 'Watch Captain Artemis', 'HQ', 'Deathwatch')," +
                        "('WatchCaptain', 'Watch Captain', 'HQ', 'Deathwatch')," +
                        "('WatchCaptainJumpPack', 'Watch Captain with Jump Pack', 'HQ', 'Deathwatch')," +
                        "('WatchCaptainTermoArmour', 'Watch Captain in Terminator Armour', 'HQ', 'Deathwatch')," +
                        "('PrimarisWatchCaptain', 'Primaris Watch Captain', 'HQ', 'Deathwatch')," +
                        "('Librarian', 'Librarian', 'HQ', 'Deathwatch')," +
                        "('LibrarianJumpPack', 'Librarian with Jump Pack', 'HQ', 'Deathwatch')," +
                        "('LibrarianTermoArmour', 'Librarian in Terminator Armour', 'HQ', 'Deathwatch')," +
                        "('PrimarisLibrarian', 'Priamris Librarian', 'HQ', 'Deathwatch')," +
                        "('Chaplain', 'Chaplain', 'HQ', 'Deathwatch')," +
                        "('ChaplainJumpPack', 'Chaplain with Jump Pack', 'HQ', 'SOBAKA')," +
                        "('ChaplainTermoArmour', 'Chaplain in Terminator Armour', 'HQ', 'PES')," +
                        "('PrimarisChaplain', 'Primaris Chaplain', 'HQ', 'Deathwatch')";

    }
}
