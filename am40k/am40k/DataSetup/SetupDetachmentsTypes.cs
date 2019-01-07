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
                    conn.Query<DetachmentType>(DetachmentsTypesInsertQuery);
                    var testSelect = conn.Query<DetachmentType>("SELECT DetachmentCaption FROM DetachmentType");
                    return true;
                }
                
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<DetachmentType> GetDetachments()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(Database.DbFolder, Database.DbName)))
                {
                    var DetachmentsList = conn.Query<DetachmentType>("SELECT DISTINCT DetachmentCaption FROM DetachmentType");
                    return DetachmentsList;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEX", ex.Message);
                return null;
            }

        }

        readonly string DetachmentsTypesInsertQuery = ("INSERT INTO DetachmentType (DetachmentCaption, DetachmentPointsBonus) VALUES " +
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
