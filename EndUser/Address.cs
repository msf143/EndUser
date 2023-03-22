using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressSpace
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Address")]
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; } 
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CountyCode { get; set; }
        public string CountryCode { get; set; }

    }
}
