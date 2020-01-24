using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.data.Db
{
    public static class ConfigHelper
    {
        public static string getCnxString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            return configuration.GetConnectionString("netDb").ToString();
        }
    }
}
