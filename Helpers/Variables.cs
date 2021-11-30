using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using TestProject.Entities;


namespace TestProject.Helpers
{
    public class Variables
    {
        private static readonly Lazy<Config> Configuration = new Lazy<Config>(() =>
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build().Get<Config>();
            
        });
        
        public static Config Config => Configuration.Value;
    }

}