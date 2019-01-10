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

        public bool DropTables()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(DbFolder, DbName)))
                {
                    conn.Query<Unit>("DROP TABLE Unit;");
                    conn.Query<Roster>("DROP TABLE Roster;");
                    conn.Query<UserDetachments>("DROP TABLE UserDetachments");
                    conn.Query<DetachmentType>("DROP TABLE DetachmentType");
                    conn.Query<DetachmentType>("SELECT DetachmentCaption FROM DetachmentType;");
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
                    conn.Query<Unit>("PRAGMA foreign_keys = true;");
                    conn.Query<Unit>("ALTER TABLE Unit ADD CONSTRAINT (FK_UnitToRoster) FOREIGN KEY (RosterId) REFERENCES Roster(RosterId)");

                    // ROSTER TABLE FOREIGN KEYS
                    conn.Query<Roster>("ALTER TABLE Roster ADD CONSTRAINT 'FK_RosterToUnit' FOREIGN KEY (RosterId) REFERENCES Unit(RosterId)");
                    conn.Query<Roster>("ALTER TABLE Roster ADD CONSTRAINT FK_RosterToUserDetachments FOREIGN KEY (DetachId) REFERENCES UserDetachments(DetachId)");

                    // DETACHMENT TYPES TABLE FOREIGN KEYS
                    conn.Query<DetachmentType>("ALTER TABLE DetachmentType ADD CONSTRAINT FK_DetachmentTypeToRoster FOREIGN KEY (RosterId) REFERENCES Roster(RosterId)");
                    conn.Query<DetachmentType>("ALTER TABLE DetachmentType ADD CONSTRAINT FK_DetachmentTypeToUnit FOREIGN KEY (Unit) REFERENCES Unit(UnitId)");

                    // USER DETACHMENTS TABLE FOREIGN KEYS
                    conn.Query<UserDetachments>("ALTER TABLE UserDetachments ADD CONSTRAINT FK_UserDetachmentsToRoster FOREIGN KEY (RosterId) REFERENCES Roster(RosterId)");
                    conn.Query<UserDetachments>("ALTER TABLE UserDetachments ADD CONSTRAINT FK_UserDetachmentsToUnit FOREIGN KEY (Unit) REFERENCES Unit(UnitId)");
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

                    conn.CreateTable<Unit>();
                    conn.CreateTable<Roster>();
                    conn.CreateTable<DetachmentType>();
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
