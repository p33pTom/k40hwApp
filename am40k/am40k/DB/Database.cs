using SQLite;
using Android.Util;
using System;
using System.Collections.Generic;

namespace am40k
{
    public class Database      
    {
        public Database() {}

        // DB PATH:
        public string DbName = "40k01";
        public string DbFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        //CREATE DB. CREATE UNIT AND ROSTER TABLE
        public bool CreateDatabase()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    conn.CreateTable<Unit>();
                    conn.CreateTable<Roster>();
                    conn.CreateTable<RosterData>();
                    conn.CreateTable<DetachmentType>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Unit> GetArmies()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    var ArmiesList = conn.Query<Unit>("SELECT DISTINCT ArmyOf FROM Unit");
                    return ArmiesList;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEX", ex.Message);
                return null;
            }

        }

        public List<Unit> GetUnitNames ()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    var UnitNamesList = conn.Query<Unit>("SELECT DISTINCT Name FROM Unit");
                    return UnitNamesList;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEX", ex.Message);
                return null;
            }
        }
    }
}
