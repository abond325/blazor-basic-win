using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp.Shared
{
    public class MyPoco : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Text { get; set; }
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;
    }

    public class MyPocoDto
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Text { get; set; }
    }
}
