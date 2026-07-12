using System.Text.Json;

namespace PracticeDay1
{
    class Program
    {
        class ReportDataException : Exception
        {
            public ReportDataException(string message) : base(message) { }
        }

        class Report
        {
            public int Id { get; set; }
            public String Category { get; set; }
            public int Priority { get; set; }

            public Report(int id, string category, int priority)
            {
                Id = id;
                Category = category;
                Priority = priority;
            }

            public override string ToString()
            {
                return $"Id: {Id} | Category: {Category} | Priority: {Priority}";
            }
        }

        static int ParsePriority(string text)
        {
            if (!int.TryParse(text, out int priority))
            {
                throw new FormatException($"Priority is not a number: {text}");
            }
            else if (priority < 0)
            {
                throw new ReportDataException($"Priority cannot be negative:{priority}");
            }
            return priority;
        }

        static int ParseId(string text)
        {
            if (!int.TryParse(text, out int Id))
            {
                throw new FormatException($"Id is not a number:{text}");
            }

            return Id;
        }

        static void SaveToJson(string jsonFileName, List<Report> reports)
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(reports, opts);
            using (StreamWriter writer = new StreamWriter(jsonFileName))
            {
                writer.Write(json);
            }
            
            Console.WriteLine("Save all to json");
        }

        static List<Report> LoadFromJson(string JsonFileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(JsonFileName))
                {
                    string back = reader.ReadToEnd();
                    List<Report> loaded = JsonSerializer.Deserialize<List<Report>>(back) ?? new();
                    return loaded;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("JSON file was not found.");
                return new List<Report>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Invalid JSON: {ex.Message}");
                return new List<Report>();
            }



        }


        static List<Report> ReadFile(string filePath)
        {
            List<Report> reports = new();
            int acceptedReport = 0;
            int rejectedReport = 0;

            try
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string? line;


                    while ((line = r.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        if (lineSplit.Length != 3)
                        {
                            Console.WriteLine($"Malformed line: {line}");
                            rejectedReport++;
                            continue;
                        }

                        try
                        {
                            int id = ParseId(lineSplit[0]);
                            String category = lineSplit[1];
                            int priority = ParsePriority(lineSplit[2]);
                            Report report = new Report(id, category, priority);
                            reports.Add(report);
                            acceptedReport++;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Format error: {ex.Message}");
                            rejectedReport++;
                        }
                        catch (ReportDataException ex)
                        {
                            Console.WriteLine($"Report data error: {ex.Message}");
                            rejectedReport++;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("no reports yet");

            }
            finally
            {
                Console.WriteLine($"{acceptedReport} reports were accepted | {rejectedReport} reports were rejected");
            }
            return reports;
        }

        static void Main()
        {
            List<Report> reports = ReadFile("field_reports_input.txt");
            SaveToJson("reports.json", reports);
            List<Report> loadReports = LoadFromJson("reports_corrupted.json");
            foreach (Report report in loadReports)
            {
                Console.WriteLine(report);
            }
        }
    }
}