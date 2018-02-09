﻿using DbUp;
using System;
using System.Configuration;
using System.Reflection;

namespace Warehouse.Database
{
    public class Program
    {
        public static int Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WarehouseDb"].ConnectionString;

            //create the database if it doesn't exist
            EnsureDatabase.For.SqlDatabase(connectionString);

            //execute migration scripts
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

#if DEBUG
            Console.ReadLine();
#endif

            return 0;
        }
    }
}
