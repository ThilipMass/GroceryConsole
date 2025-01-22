/* 
    Title       : Grocery Store Applicatiom
    Author      : Thilip Chandru
    Created at  : 13/12/2024
    Updated at  : 19/12/2024
    Reviewd by  : sabapathi
    Reviewed at : 23/12/2024
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Serilog;
namespace GroceryStoreApplication;
class Program
{
    public static string connectionString;

    //double num =0;
//Console.WriteLine(num);
    static Program()
    {
       IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@"appSettings.json",reloadOnChange: true,optional:false).Build();
    connectionString = configuration.GetConnectionString("DefaultConnection");

    }
  public static void Main(string[] args)
  {
    Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/myApp.log",rollingInterval:RollingInterval.Day)
    .CreateLogger();

    // DbConnection.DbConnect();
    // DbConnection.DisplayProduct();
    //DbConnection.DisplayCustomerDetails();
    Operations.AddDefaultValue();
    // Call MainMenu
    Operations.MainMenu();

  
  }
}