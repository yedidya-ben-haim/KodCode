using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using System.Threading.Channels;
using static Day2Week14.Program;
using static System.Net.Mime.MediaTypeNames;

namespace Day2Week14
{
    class Program
    {
        public class Report
        {
            public int Id { get; set; }
            public string Category { get; set; }
            public int Priority { get; set; }
            public string Zone { get; set; }
            public int SignalStrength { get; set; }
            public string Shift { get; set; }

            public Report(int id, string category, int priority, string zone, int signalStrength, string shift)
            {
                Id = id;
                Category = category;
                Priority = priority;
                Zone = zone;
                SignalStrength = signalStrength;
                Shift = shift;
            }

            public override string ToString()
            {
                return $"Id: {Id},  Category: {Category}, Priority: {Priority}, Zone: {Zone}, SignalStrength: {SignalStrength}, Shift: {Shift}";
            }
        }

        public static List<Report> LoadReports(string FileName)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(FileName))
                {
                    string back = streamReader.ReadToEnd();
                    List<Report> reports = JsonSerializer.Deserialize<List<Report>>(back) ?? new();
                    return reports;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"No report file:{ex.FileName}");
                return new();
            }
        }
        static void Main()
        {
            List<Report> reports = LoadReports("reports.json");

            // How many reports are there in total?
            int totalCount = reports.Count();

            // List the ids of all 'SIGNAL' reports
            var signalIds = reports.Where(r => r.Category == "SIGNAL").Select(r => r.Id);

            // List the ids of all reports with Priority of 4 or higher
            var idOfPriority4 = reports.Where(r => r.Priority >= 4).Select(r => r.Id).ToList();


            // List the ids of all Night shift reports in the North zone.
            var nightShiftNorthZoneids = reports.Where(r => r.Shift == "Night" && r.Zone == "North").Select(r => r.Id).ToList();

            // List the id and priority of every COMMS report.
            var commsIdsAndPriority = reports.Where(r => r.Category == "COMMS").Select(r => new { r.Id, r.Priority }).ToList();

            // List the ids of all reports whose SignalStrength is between 70 and 90(inclusive).
            var signalStrengthBetween70And90 = reports.Where(r => r.SignalStrength >= 70 && r.SignalStrength <= 90).Select(r => r.Id).ToList();

            // List the ids of all reports that are not in the West zone.
            var notWestZone = reports.Where(r => r.Zone != "West").Select(r => r.Id).ToList();

            // List all report ids ordered by Priority, highest first.
            var orderByPriorityids = reports.OrderByDescending(r => r.Priority).Select(r => r.Id).ToList();

            // List all report ids ordered by Zone (alphabetically), and within the same zone by Priority descending
            var orderByZoneAndPriority = reports.OrderBy(r => r.Zone).ThenByDescending(r => r.Priority).Select(r => r.Id).ToList();

            // ids of the three strongest reports(highest SignalStrength)
            var threeStrongestIds = reports.OrderByDescending(r => r.SignalStrength).Select(r => r.Id).Take(3).ToList();

            // ids of the two weakest reports(lowest SignalStrength)
            var twoLowestIds = reports.OrderBy(r => r.SignalStrength).Take(2).Select(r => r.Id).ToList();


            // Skipping the five highest-priority reports, list the ids of the rest, still ordered by priority descending
            var orderedByPrioritySkipFive = reports.OrderByDescending(r => r.Priority).Select(r => r.Id).Skip(5).ToList();

            // List the id of every IMAGERY report, ordered from weakest to strongest signal.
            var imageryDescendingSignalOrder = reports.Where(r => r.Category == "IMAGERY").OrderBy(r => r.SignalStrength).Select(r => r.Id).ToList();

            // reports have Priority 5
            int priorityFive = reports.Count(r => r.Priority == 5);


            // average SignalStrength across all reports
            var signalStrengthAverage = reports.Average(r => r.SignalStrength);


            //strongest signal value in the data(the number itself)
            var strongestSignal = reports.Max(r => r.SignalStrength);

            // weakest signal value among Night - shift reports?
            var weakestSignalNightShift = reports.Where(r => r.Shift == "Night").Min(r => r.SignalStrength);

            // sum of all priorities of SIGNAL reports?
            var sumOfSignalPriority = reports.Where(r => r.Category == "SIGNAL").Sum(r => r.Priority);

            // average Priority of reports in the South zone
            var priorityAvgSouthZone = reports.Where(r => r.Zone == "South").Average(r => r.Priority);

            // distinct zones appear in the data
            var countDistinctZones = reports.Select(r => r.Zone).Distinct().Count();

            // List the distinct categories, alphabetically.
            var listOfCategories = reports.Select(r => r.Category).Distinct().OrderBy(category => category).ToList();

            // For each category: how many reports does it have
            var countEachCategory = reports.GroupBy(r => r.Category).Select(g => new { category = g.Key, count = g.Count() }).ToList();

            // For each zone: what is the average SignalStrength? (one line per zone)
            var averageSignalStrengthByZone = reports.

            Console.WriteLine(countDistinctZones);
            countEachCategory.ForEach(r => Console.WriteLine(r));

        }
    }
}

