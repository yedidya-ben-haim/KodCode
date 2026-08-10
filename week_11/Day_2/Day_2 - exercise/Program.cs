using System;

namespace project
{

    class prohect_day_2
    {
        static void AddTrack(List<int> ids, List<double> speeds, List<string> headings, int id, double speed, string heading)
        {
            ids.Add(id);
            speeds.Add(speed);
            headings.Add(heading);
        }


        static void RemoveATrackById(List<int> ids, List<double> speeds, List<string> headings, int id)
        {
            int trackIndex = FindTrackById(ids, id);
            if (trackIndex < 0)
            {
                Console.WriteLine("Tracks not found");
            }
            else
            {
                ids.RemoveAt(trackIndex);
                speeds.RemoveAt(trackIndex);
                headings.RemoveAt(trackIndex);

                Console.WriteLine($"Tracks {id} was removed");
            }

            
        
        }


        static int FindTrackById(List<int> ids, int id)
        {
            return ids.IndexOf(id);

        }


        static void AllTracks(List<int> ids, List<double> speeds, List<string> headings)
        {
            if (ids.Count > 0)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    Console.WriteLine($"tracks id: {ids[i]} \n speed: {speeds[i]} \n heading: {headings[i]}");
                }
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }



        static List<int> FilterTracks(List<int> ids, List<double> speeds, double speed_threshold)
        {
            List<int> filteredId = new();

            for (int i = 0; i < ids.Count; i++)
            {
                if (speeds[i] < speed_threshold)
                {
                    filteredId.Add(ids[i]);
                }
            }

            return filteredId;
        }



        static List<int> FilterTracks(List<int> ids, List<string> headings, string heading_sector)
        {
            List<int> filteredId = new();

            for (int i = 0; i < ids.Count; i++)
            {
                if (headings[i] == heading_sector)
                {
                    filteredId.Add(ids[i]);
                }
            }

            return filteredId;
        }


        static void FleetSummarize(List<int> ids, List<double> speeds, List<string> headings)
        {
            if (ids.Count == 0) 
            {
                Console.WriteLine("Fleet is empty.");
                return;
            }

            // count
            int count = ids.Count;

            // average speed
            double sumSpeed = 0;
            double averageSpeed;
            foreach (double speed in speeds)
            {
                sumSpeed += speed;
            }
             averageSpeed = sumSpeed / count;
        




            // fastest track
            int fastestTrackId = ids[0];
            double fastestTrackSpeed;


        }


        static void Main()
        {
            List<int> idList = new();
            List<double> speedList = new();
            List<string> headingList = new();

            AddTrack(idList, speedList, headingList,1, 50, "straight");
            AddTrack(idList, speedList, headingList,2, 100, "straight");
            AllTracks(idList, speedList, headingList);
            List<int> filterList = FilterTracks(idList, headingList, "straigh");
            Console.WriteLine(filterList[0]);


        }
    }
}
