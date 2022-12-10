using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Azure.Data.Tables;

namespace BlazorApp.Api
{
    public class TableStorage
    {
        [FunctionName("TableOutput")]
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
