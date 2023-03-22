using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using MongoDB.Driver;
using API.Helpers;
using API.Models;
using NameSpace;
using EmailSpace;
using AddressSpace;
using PhoneSpace;
using System.Collections.Generic;
using System;
using MongoDB.Bson.Serialization.Conventions;

namespace API.Functions
{
    public class RegisterEndUser
    {
        private readonly MongoClient _mongoClient; // Underscores denote private objects.
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        private readonly IMongoCollection<EndUser> _endUserCollection;

        public RegisterEndUser(
            MongoClient mongoClient,
            ILogger<RegisterEndUser> logger,
            IConfiguration config)
        {
            _mongoClient = mongoClient;
            _logger = logger;
            _config = config;

            IMongoDatabase endUserDatabase = _mongoClient.GetDatabase(_config.GetValue<string>("EndUserDatabaseName"));
            _endUserCollection = endUserDatabase.GetCollection<EndUser>(_config.GetValue<string>("EndUserCollectionName"));
            //var pack = new ConventionPack();
            //pack.Add(new CamelCaseElementNameConvention());

        }

        [FunctionName("RegisterEndUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "register")] HttpRequest req,
            //[Blob("schemas/SchedulerSchema.json", FileAccess.Read)] Stream validationSchema),
            ILogger log)
        {

            IActionResult returnValue = null;

            log.LogInformation("'RegisterEndUser' processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Console.WriteLine(requestBody);

            var input = JsonConvert.DeserializeObject<EndUser>(requestBody);

            EndUser endUser = new EndUser
            {
                LoginId = input.LoginId
            };

            try
            {
                _endUserCollection.InsertOne((EndUser)endUser);
                returnValue = new OkObjectResult(endUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown: {ex.Message}");
                returnValue = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return returnValue;
        }
    }
}
