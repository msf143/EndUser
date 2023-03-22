using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSpace
{
    public class Email
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("EmailAddress")]
        public string Type { get; set; } 
        public string Address { get; set; }
    }
}
