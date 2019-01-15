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
        public string DbName = "k04hwApp";
        public string DbFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public bool DropTables()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    conn.Query<Units>("DROP TABLE Units;");
                    conn.Query<Rosters>("DROP TABLE Rosters;");
                    conn.Query<UserDetachments>("DROP TABLE UserDetachments");
                    conn.Query<DetachmentsTypes>("DROP TABLE DetachmentsTypes");
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLite", ex.Message);
                return false;
            }
        }


        public bool UpdateTablesWithForeignKeys()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    
                    conn.BeginTransaction();
                    // UNIT TABLE FOREIGN KEYS
                    conn.Query<Units>("PRAGMA foreign_keys = true;");
                    string FK_UnitToRoster_Query = string.Format("ALTER TABLE Units ADD CONSTRAINT FK_UnitToRoster FOREIGN KEY (RosterId) REFERENCES Rosters(RosterId) ON UPDATE ACTION");
                    conn.Query<Units>(FK_UnitToRoster_Query);

                    // ROSTER TABLE FOREIGN KEYS
                    conn.Query<Rosters>("ALTER TABLE Rosters ADD CONSTRAINT 'FK_RosterToUnit' FOREIGN KEY (RosterId) REFERENCES Units(RosterId)");
                    conn.Query<Rosters>("ALTER TABLE Rosters ADD CONSTRAINT FK_RosterToUserDetachments FOREIGN KEY (DetachId) REFERENCES UserDetachments(DetachId)");

                    // DETACHMENT TYPES TABLE FOREIGN KEYS
                    conn.Query<DetachmentsTypes>("ALTER TABLE DetachmentsTypes ADD CONSTRAINT FK_DetachmentTypeToRoster FOREIGN KEY (RosterId) REFERENCES Rosters(RosterId)");
                    conn.Query<DetachmentsTypes>("ALTER TABLE DetachmentsTypes ADD CONSTRAINT FK_DetachmentTypeToUnit FOREIGN KEY (Unit) REFERENCES Units(UnitId)");

                    // USER DETACHMENTS TABLE FOREIGN KEYS
                    conn.Query<UserDetachments>("ALTER TABLE UserDetachments ADD CONSTRAINT FK_UserDetachmentsToRoster FOREIGN KEY (RosterId) REFERENCES Rosters(RosterId)");
                    conn.Query<UserDetachments>("ALTER TABLE UserDetachments ADD CONSTRAINT FK_UserDetachmentsToUnit FOREIGN KEY (Unit) REFERENCES Units(UnitId)");
                    conn.Commit();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLite", ex.Message);
                return false;
            }
        }


        //CREATE DB. CREATE UNIT AND ROSTER TABLE
        public bool CreateDatabase()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    conn.BeginTransaction();

                    conn.CreateTable<Units>();
                    conn.CreateTable<Rosters>();
                    conn.CreateTable<DetachmentsTypes>();
                    conn.CreateTable<UserDetachments>();
                    conn.Commit();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Units> GetArmies()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    var ArmiesList = conn.Query<Units>("SELECT DISTINCT ArmyOf FROM Units");
                    return ArmiesList;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEX", ex.Message);
                return null;
            }

        }

        public List<Units> GetUnitNames ()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    var UnitNamesList = conn.Query<Units>("SELECT DISTINCT Name FROM Units");
                    return UnitNamesList;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEX", ex.Message);
                return null;
            }
        }

        public List<Rosters> GetRosters()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    var RostersList = conn.Query<Rosters>("SELECT DetachmentType FROM Rosters");
                    return RostersList;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<string> GetUserRosters()
        {
            List<string> UserRostersTypes = new List<string>();
            List<Rosters> rosters = GetRosters();
            foreach (Rosters userRoster in rosters)
            {
                UserRostersTypes.Add(userRoster.DetachmentType);
            }
            return UserRostersTypes;
        }
    }
}
