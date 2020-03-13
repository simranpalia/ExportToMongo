using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using ExportToMongo.Models;

namespace ExportToMongo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ExportToMongo()
        {
            try
            {

                foreach (var item in DAL.GetMailConversations())
                {
                    MongoUtils.RunAndSaveMailConversation(new MailConversationViewModel(item));
                }

                return Content("OK");
            }
            catch (Exception ex)
            {
                return Content("Error : " + ex.Message);
            }
        }

        public ActionResult ExportMailsToMongo()
        {
            try
            {

                foreach (var item in DAL.GetMails())
                {
                    MongoUtils.RunAndSaveMail(new MailViewModel(item));
                }

                return Content("OK");
            }
            catch (Exception ex)
            {
                return Content("Error : " + ex.Message);
            }
        }
    }
}
