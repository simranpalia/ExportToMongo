using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportToMongo.Models
{
    public class MailViewModel
    {
        [BsonId]
        public ObjectId MongoId { get; set; }

        public long Id { get; set; }

        [JsonProperty("CreatedAt")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? CreatedAt { get; set; }

        public string Recipient { get; set; }

        public string MessageId { get; set; }

        public string SenderName { get; set; }

        public string FromEmail { get; set; }

        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public bool? HasAttachment { get; set; }

        public bool? IsHtml { get; set; }

        public string MailBody { get; set; }

        public string Status { get; set; }

        public long? CustomerId { get; set; }

        public long? StaffId { get; set; }

        public long? MailConversationId { get; set; }

        public string MailBox { get; set; }

        public bool? IsRead { get; set; }

        public string ForwardFrom { get; set; }

        public MailViewModel()
        {

        }

        public MailViewModel(Mail dbObj)
        {
            this.Id = dbObj.Id;
            this.Recipient = dbObj.Recipient;
            this.MessageId = dbObj.MessageId;
            this.SenderName = dbObj.SenderName;
            this.FromEmail = dbObj.FromEmail;
            this.ToEmail = dbObj.ToEmail;
            this.Subject = dbObj.Subject;
            this.HasAttachment = dbObj.HasAttachment;
            this.IsHtml = dbObj.IsHtml;
            this.MailBody = dbObj.MailBody;
            this.Status = dbObj.Status;
            this.CustomerId = dbObj.CustomerId;
            this.StaffId = dbObj.StaffId;
            this.MailConversationId = dbObj.MailConversationId;
            this.MailBox = dbObj.MailBox;
            this.IsRead = dbObj.IsRead;
            this.ForwardFrom = dbObj.ForwardFrom;

        }
    }

    public class MailConversationViewModel
    {
        [BsonId]
        public ObjectId MongoId { get; set; }

        public long Id { get; set; }

        [JsonProperty("CreatedAt")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? CreatedAt { get; set; }

        public string SenderEmail { get; set; }

        public string SenderName { get; set; }

        public int? MessageCount { get; set; }

        public string Subject { get; set; }

        public string OwnerEmail { get; set; }

        [JsonProperty("LastMessageDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? LastMessageDate { get; set; }

        public string MailGunMessageId { get; set; }

        public MailConversationViewModel()
        {

        }

        public MailConversationViewModel(MailConversation dbObj)
        {
            this.Id = dbObj.Id;
            this.SenderName = dbObj.SenderName;
            this.SenderEmail = dbObj.SenderEmail;
            this.MessageCount = dbObj.MessageCount;
            this.Subject = dbObj.Subject;
            this.OwnerEmail = dbObj.OwnerEmail;
            this.LastMessageDate = dbObj.LastMessageDate;
            this.CreatedAt = dbObj.CreatedAt;
            this.MailGunMessageId = dbObj.MailGunMessageId;
        }
    }
}