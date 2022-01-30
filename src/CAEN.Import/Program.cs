// Copyright (c) Florin Bobis. All Rights Reserved.

using CAEN.Import;

Console.WriteLine("Press any key to start importing data...");

Console.ReadKey();

string outputFileName = "caen.json";
string inputFileName = "data\\CoduriCAEN.xlsx";
var dataImport = new CaenDataImportService();
dataImport.ConvertXlsToJson(inputFileName, outputFileName);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
