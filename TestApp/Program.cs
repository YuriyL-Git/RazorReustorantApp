using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace TestApp
{
    class Program
    {


        static void Main(string[] args)
        {

            GetFood();
        }



        public static async Task GetFood()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration config = builder.Build();
            ConnectionStringData connectionString = new ConnectionStringData();

            IDataAccess db = new SqlDB(config);
            IFoodData foodData = new FoodData(db, connectionString);

            var listOfFood =  await foodData.GetFood();

            int x = 5;
            foreach (var food in listOfFood)
            {
                Console.WriteLine(food.Title);
            }
          


        }
    }
}
