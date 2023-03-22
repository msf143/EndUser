using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSpace  
{
    public class Name
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string First { get; set; }
        public string Last { get; set; }
        public string Middle { get; set; }
        public string DisplayAs { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }
}
