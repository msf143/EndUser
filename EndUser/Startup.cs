//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using API.Helpers;
using API.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Conventions;
using System.Xml.Linq;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

//[assembly: WebJobsStartup(typeof(Startup))]
[assembly: FunctionsStartup(typeof(API.Helpers.Startup))]

namespace API.Helpers
{
    //    public class Startup : IWebJobsStartup
    public class Startup : FunctionsStartup
    {
        private readonly IConfiguration _configuration;
        public override void Configure(IFunctionsHostBuilder builder)

        {

            builder.Services.AddOptions<ApiOptions>().Configure<IConfiguration>((settings, configuration) =>
            {
                //configuration.GetSection("ConnectionStrings").Bind(settings);
                configuration.GetConnectionString("EndUserDatabaseConnection");
            });

            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddFilter(level => true);
            });

            builder.Services.AddSingleton((s) =>
            {
                //MongoClient client = new MongoClient(config.GetConnectionString("EndUserDatabaseConnection"));
                MongoClient client = new MongoClient("mongodb+srv://mfranklin79:0szEnWJlOYmyeBV3@cluster0.llvptp8.mongodb.net/?retryWrites=true&w=majority");
                return client;
            });



        }
    }
}
