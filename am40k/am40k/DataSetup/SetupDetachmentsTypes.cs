using System;
using System.Collections.Generic;
using System.Text;
using Android.Util;
using SQLite;

namespace am40k
{
    public class SetupDetachmentsTypes
    {
        Database Database = new Database();
        //Roster Roster = new Roster();

        public SetupDetachmentsTypes() { }

        public bool InitializeDetachmentsTypes()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(Database.DbFolder, Database.DbName)))
                {
                    conn.Query<DetachmentsTypes>(DetachmentsTypesInsertQuery);
                    var testSelect = conn.Query<DetachmentsTypes>("SELECT DetachmentTypeCaption FROM DetachmentsTypes");
                    return true;
                }
                
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<DetachmentsTypes> GetDetachments()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(Database.DbFolder, Database.DbName)))
                {
                    var DetachmentsList = conn.Query<DetachmentsTypes>("SELECT DISTINCT DetachmentTypeCaption FROM DetachmentsTypes");
                    return DetachmentsList;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEX", ex.Message);
                return null;
            }

        }

        readonly string DetachmentsTypesInsertQuery = ("INSERT INTO DetachmentsTypes (DetachmentTypeCaption, DetachmentPointsBonus) VALUES " +
                        "('Patrol Detachment', 1), " +
                        "('Batallion Detachment', 5), " +
                        "('Brigade Detachment', 11), " +
                        "('Vanguard Detachment', 1), " +
                        "('Spearhead Detachment', 1), " +
                        "('Outrider Detachment', 1), " +
                        "('Supreme Command Detachment', 1), " +
                        "('Air Wing Detachment', 1), " +
                        "('Super Heavy Detachment', 3)");

    }
}
