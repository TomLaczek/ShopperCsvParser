// See https://aka.ms/new-console-template for more information

using DataMover;
using Microsoft.Extensions.Configuration;
using ProductsIntoDb;
using ShoperCsvParser;

Console.WriteLine("Application starts...");
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.json");
var config = configuration.Build();
var configHelper = new ConfigHelper(config);

var parser = new CsvParser(configHelper._path);
var result = await parser.ParseCsvFile();

if(result.Products != null)
{
    var db = new InsertProducts(configHelper._connectionString);
    await db.InsertProductsToDb(result.Products);
}

Console.ReadLine();