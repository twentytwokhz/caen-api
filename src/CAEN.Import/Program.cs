// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using CAEN.Import;

Console.WriteLine("Press any key to start importing data...");

Console.ReadKey();

string outputFileName = "caen.json";
string inputFileName = "data\\CoduriCAEN.xlsx";
var dataImport = new CaenDataImportService();
dataImport.ConvertXlsToJson(inputFileName, outputFileName);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
