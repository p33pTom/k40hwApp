using SQLite;
using Android.Util;


namespace am40k.DB
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
                    conn.Query<Unit>(deathwatchHQUnitsQuery);
                    return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
            
        }

        //INSERT DEATHWATCH HQ UNITS QUERY:
        readonly string deathwatchHQUnitsQuery = "";

    }
}
