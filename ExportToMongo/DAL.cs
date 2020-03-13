using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportToMongo
{
    public class DAL
    {
        public static IMSEntitiesDataContext GetContext()
        {
            return new IMSEntitiesDataContext();
        }




        internal static IEnumerable<MailConversation> GetMailConversations()
        {
            using (var db = GetContext())
            {
                return db.MailConversations.ToList();
            }
        }

        internal static IEnumerable<Mail> GetMails()
        {
            using (var db = GetContext())
            {
                return db.Mails.ToList();
            }
        }

        internal static void UpdateMailConversation(long p, MongoDB.Bson.ObjectId objectId)
        {
            using (var db = GetContext())
            {
                var dbObj = db.MailConversations.Where(x => x.Id == p).FirstOrDefault();

                if (dbObj != null)
                {
                    dbObj.MongoId = objectId.ToString();
                    db.SubmitChanges();

                }
            }
        }

        internal static void UpdateMail(long p, MongoDB.Bson.ObjectId objectId)
        {
            using (var db = GetContext())
            {
                var dbObj = db.Mails.Where(x => x.Id == p).FirstOrDefault();

                if (dbObj != null)
                {
                    dbObj.MongoId = objectId.ToString();
                    db.SubmitChanges();

                }
            } 
        }
    }
}