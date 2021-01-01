using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.Extensions.Configuration;
using Nito.AsyncEx;

namespace TestApp
{
    class Program
    {
        private static  IConfiguration _config;
        private static ConnectionStringData  connectionString;
        private static IDataAccess db;
        private static IFoodData foodData;

        public static void InitConfig()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _config = builder.Build();
            connectionString = new ConnectionStringData();

            db = new SqlDB(_config);
            foodData = new FoodData(db, connectionString);

        }


        static void Main(string[] args)
        {
            InitConfig();

            var food = foodData.GetFood().Result;

            foreach (var f in food)
            {
                Console.WriteLine(f.Title);
            }
        }



       
    }
}
