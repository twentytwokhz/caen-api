// Copyright (c) Florin Bobis. All Rights Reserved.

using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ClosedXML.Excel;

namespace CAEN.Import
{
    public class CaenDataImportService
    {
        public void ConvertXlsToJson(string fileName, string outputFileName)
        {
            var options = new JsonWriterOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                Indented = true
            };

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream, options);

            XLWorkbook wb = new XLWorkbook(fileName);
            var ws = wb.Worksheets.FirstOrDefault();
            bool sectionStarted = false;
            bool divisionStarted = false;
            bool groupStarted = false;
            bool first = true;

            foreach (IXLRow row in ws.Rows().Skip(1))
            {
                var col1 = row.Cell(1).Value.ToString().Trim();
                var col2 = row.Cell(2).Value.ToString().Trim();
                var col3 = row.Cell(3).Value.ToString().Trim();
                var col4 = row.Cell(4).Value.ToString().Trim();
                var col5 = row.Cell(5).Value.ToString().Trim();
                var col6 = row.Cell(6).Value.ToString().Trim();
                bool isSection = string.IsNullOrEmpty(col1) && string.IsNullOrEmpty(col2) && string.IsNullOrEmpty(col3) && !string.IsNullOrEmpty(col4);
                bool isDivision = !string.IsNullOrEmpty(col1);
                bool isGroup = !string.IsNullOrEmpty(col2);
                bool isClass = !string.IsNullOrEmpty(col3);
                if (isSection)
                {
                    if (groupStarted)
                    {
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                        groupStarted = false;
                    }
                    if (divisionStarted)
                    {
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                        divisionStarted = false;
                    }
                    if (sectionStarted)
                    {
                        //divison array
                        writer.WriteEndArray();
                        //section obj
                        writer.WriteEndObject();
                        sectionStarted = false;
                    }

                    sectionStarted = true;
                    //section array
                    if (first)
                    {
                        first = false;
                        writer.WriteStartArray();
                    }
                    writer.WriteStartObject();
                    var id = col4.Split(" - ")[0].Split(' ')[1];
                    var name = col4.Split(" - ")[1];
                    writer.WriteString("Sectiune", id);
                    writer.WriteString("Denumire", name);
                    writer.WriteStartArray("Diviziuni");
                }
                else if (isDivision)
                {
                    if (groupStarted)
                    {
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                        groupStarted = false;
                    }
                    if (divisionStarted)
                    {
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                        divisionStarted = false;
                    }

                    divisionStarted = true;
                    writer.WriteStartObject();
                    writer.WriteString("Diviziune", col1);
                    writer.WriteString("Denumire", col4);
                    writer.WriteStartArray("Grupe");
                }
                else if (isGroup)
                {
                    if (groupStarted)
                    {
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                        groupStarted = false;
                    }

                    groupStarted = true;
                    writer.WriteStartObject();
                    writer.WriteString("Grupa", col2);
                    writer.WriteString("Denumire", col4);
                    writer.WriteStartArray("Clase");
                }
                else if (isClass)
                {
                    writer.WriteStartObject();
                    writer.WriteString("CAENRev2", col3.PadLeft(4, '0'));
                    writer.WriteString("Denumire", col4);
                    writer.WriteString("CAENRev1", col5);
                    writer.WriteString("ISICRev4", col6);
                    writer.WriteEndObject();
                }
            }

            if (groupStarted)
            {
                writer.WriteEndArray();
                writer.WriteEndObject();
                groupStarted = false;
            }
            if (divisionStarted)
            {
                writer.WriteEndArray();
                writer.WriteEndObject();
                divisionStarted = false;
            }
            if (sectionStarted)
            {
                //divison array
                writer.WriteEndArray();
                //section obj
                writer.WriteEndObject();
                //section array
                writer.WriteEndArray();
                sectionStarted = false;
            }

            writer.Flush();

            string json = Encoding.UTF8.GetString(stream.ToArray());
            File.WriteAllText(outputFileName, json);
        }
    }
}
