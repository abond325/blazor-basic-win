using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using BlazorApp.Shared;
using Azure.Data.Tables;

namespace BlazorApp.Api
{
    public class ReadTableStorage
    {
        [FunctionName("ReadTableData")]
        public static IActionResult ReadTableData(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var conStr = "DefaultEndpointsProtocol=https;AccountName=staticwebappstore;AccountKey=SABE2yIUUV1ENEjgN6tUPGOie8mSDBxTAimySZcYsiXoQhk9Wze6ddLF1YUCAlbkPGqtkE4iGMW/+AStMCzDyA==;EndpointSuffix=core.windows.net";
            TableClient tableClient = new TableClient(conStr, "MyTable");
            var entities = tableClient.Query<MyPoco>(x => x.PartitionKey == "Http");

            return new OkObjectResult(entities);
        }

    }
}
