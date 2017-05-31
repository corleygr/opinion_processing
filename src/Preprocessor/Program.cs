using System;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace Preprocessor
{
    class Program
    {


        static void Main(string[] args)
        {
             var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var appSettings = builder.Build();
            var transforms = appSettings.GetSection("transforms");

            FileProcessor fp = new FileProcessor(appSettings["originals"], appSettings["converted"], appSettings["tokens"]);
            fp.Process();
        }
    }
}
