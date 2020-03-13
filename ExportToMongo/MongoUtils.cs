using ExportToMongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportToMongo
{
    public class MongoUtils
    {
        public static string CONNECTION_STRING = "mongodb://immisys:USg2pK2Qwbe6gURKbC252jvVOVwKIc5yP3CBMNzmzL25DCUs6LgyiV6O49v7ud5KoiTjScjqnJrh6U3ojIvzZA==@immisys.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        public static string DB_NAME = "IMSMails";

        public static string COLLECTION_MAIL = "Mail";
        public static string COLLECTION_MAIL_CONV = "MailConversation";

        public static MongoClient GetClient()
        {
            var client = new MongoClient(connectionString: CONNECTION_STRING);

            return client;
        }

        public static void RunAndSaveMailConversation(MailConversationViewModel mc = null)
        {
            if (mc != null)
            {

                var client = GetClient();

                var database = client.GetDatabase(DB_NAME);

                //get mongodb collection
                var collection = database.GetCollection<MailConversationViewModel>(COLLECTION_MAIL_CONV);

                var query = collection.AsQueryable();

                if (query.Any(x => x.Id == mc.Id))
                {
                   
                }
                else
                {
                    //Add
                    collection.InsertOne(mc);

                    DAL.UpdateMailConversation(mc.Id, mc.MongoId);
                }
            }
        }

        public static void RunAndSaveMail(MailViewModel mc = null)
        {
            if (mc != null)
            {

                var client = GetClient();

                var database = client.GetDatabase(DB_NAME);

                //get mongodb collection
                var collection = database.GetCollection<MailViewModel>(COLLECTION_MAIL);

                var query = collection.AsQueryable();

                if (query.Any(x => x.Id == mc.Id))
                {
                    //Update
                    //MailViewModel mcObj = collection.Find(x => x.Id == mc.Id).FirstOrDefault();

                    //collection.DeleteOne<MailViewModel>(x => x.Id == mc.Id);

                    //collection.InsertOne(mcObj);
                }
                else
                {
                    //Add
                   collection.InsertOne(mc);

                   DAL.UpdateMail(mc.Id, mc.MongoId);
                }
            }
        }
    }
}