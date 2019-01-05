using SQLite;
using Android.Util;
using System;
using System.Collections.Generic;

namespace am40k
{
    public class Database      
    {
        public Database() {}

        //TEST DATA
        //readonly string DraigoQuery = "INSERT INTO Unit (UnitShortName, UnitCaption, Name, Type) VALUES ('LKD', 'Draigo', 'Kaldor Draigo', 'HQ')";
        //private readonly string DreadQuery = "INSERT INTO Unit (UnitShortName, UnitCaption, Name, Type) VALUES ('ND', 'Dreadknight', 'Nemesis Dreadknight', 'HQ')";
        //TEST DATA

        // DB PATH:
        readonly string DbName = "40k01";
        readonly string DbFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        //CREATE DB
        public bool CreateDatabase()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    conn.CreateTable<Unit>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool SetupData()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    //conn.Query<Unit>(DraigoQuery);
                    //conn.Query<Unit>(DreadQuery);
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Unit> GetUnitNames ()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    var UnitNamesList = conn.Query<Unit>("SELECT Name FROM Unit");
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
