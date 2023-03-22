using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NameSpace;
using AddressSpace;
using EmailSpace;
using PhoneSpace;
using Newtonsoft.Json;

namespace API.Models
{
    public class EndUser
    {
        [JsonProperty ("UserId")]
        public string UserId { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("LoginId")]
        public string LoginId { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Salt")]
        public string Salt { get; set; }
        public List<Phone> Phones { get; set; } 
        public Name Name { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Email> Emails { get; set; } 

    }

}
