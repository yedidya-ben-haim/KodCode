namespace project
{
    class project_day_1
    {
        class ImageMetadataManagerBadVersion
        {
            public int Id { set; get; };
            public double CloudCover { set; get; };
            public string Sensor { set; get; };

            public bool IsValid()
            {
                if (CloudCover < 0 && CloudCover > 100)
                {
                    return true;
                }
                return false;
            }

            public string Format()
            {
                return $"Image {Id}:{CloudCover} cloud {Sensor}."
            }

            void SaveToFile(ImageMetadataManagerBadVersion i, string path)
            {
                File.WriteAllText(path, i.Format());
            }

            public int Score(ImageMetadataManagerBadVersion i)
            {
                int SensorScore = 0;

                switch (i.Sensor)
                {
                    case "SAR":
                        SensorScore = 100;
                        break;

                    case "EO":
                        SensorScore = 60;
                        break;

                    case "IR":
                        SensorScore = 40;
                        break;

                    default:
                        SensorScore = 0;
                        break;
                }
                return SensorScore - (int)i.CloudCover;
            }





        }
    }
}