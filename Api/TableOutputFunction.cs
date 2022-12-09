using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;


using BlazorApp.Shared;
using Microsoft.Azure.WebJobs.Description;
using Azure.Data.Tables;
//using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Api
{
    public class TableStorage
    {
        public class MyPoco
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public string Text { get; set; }
        }

        public static void TableOutput([HttpTrigger] dynamic input, ILogger log)
        {
            var conStr = "DefaultEndpointsProtocol=https;AccountName=staticwebappstore;AccountKey=SABE2yIUUV1ENEjgN6tUPGOie8mSDBxTAimySZcYsiXoQhk9Wze6ddLF1YUCAlbkPGqtkE4iGMW/+AStMCzDyA==;EndpointSuffix=core.windows.net";

            TableClient tableClient = new TableClient(conStr, "MyTable");              
            TableEntity entity = new TableEntity("Http", Guid.NewGuid().ToString())
            {
                { "Text", "Hello Api World!"}
            };

            tableClient.AddEntity(entity);

        }
    }
}
