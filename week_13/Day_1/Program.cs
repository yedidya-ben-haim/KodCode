namespace project
{
    class project_day_1
    {
        class ImageMetadataManagerBadVersion
        {
            public int Id { set; get; }
            public double CloudCover { set; get; }
            public string Sensor { set; get; }

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
                return $"Image {Id}:{CloudCover} cloud {Sensor}.";
            }

            void SaveToFile(string path)
            {
                File.WriteAllText(path, Format());
            }

            public int Score()
            {
                int SensorScore = 0;

                switch (Sensor)
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
                return SensorScore - (int)CloudCover;
            }





        }

        abstract class SatelliteImage
        {
            public int Id { get; }
            public double CloudCover { get; }

            protected SatelliteImage(int id, double cloudCover)
            {
                if (cloudCover < 0 || cloudCover > 100)
                {
                    throw new ArgumentException("Cloud cover must be between 0 and 100");
                }

                Id = id;
                CloudCover = cloudCover;
            }

            public abstract string SensorName { get; }

            public abstract int Score();
        }

        class SarImage : SatelliteImage
        {
            public SarImage(int id, double cloudCover) : base(id, cloudCover)
            {

            }

            public override string SensorName => "SAR";

            public override int Score()
            {
                return 100 - (int)CloudCover;
            }
        }

        class EoImage : SatelliteImage
        {
            public EoImage(int id, double cloudCover) : base(id, cloudCover)
            {

            }

            public override string SensorName => "EO";

            public override int Score()
            {
                return 60 - (int)CloudCover;
            }
        }
        class IrImage : SatelliteImage
        {
            public IrImage(int id, double cloudCover) : base(id, cloudCover)
            {

            }

            public override string SensorName => "IR";

            public override int Score()
            {
                return 40 - (int)CloudCover;
            }
        }

        class MultispectralImage : SatelliteImage
        {
            public MultispectralImage(int id, double cloudCover) : base(id, cloudCover)
            {

            }

            public override string SensorName => "MULTISPECTRAL";

            public override int Score()
            {
                return 80 - (int)CloudCover;
            }
        }

        class Repository<T>
        {
            private readonly List<T> _items = new();

            public void Add(T item)
            {
                _items.Add(item);
            }

            public T Get(int index)
            {
                return _items[index];
            }

            public int Count()
            {
                return _items.Count;
            }

            public List<T> GetAll()
            {
                return _items;
            }

        }


        public static void Main()
        {
            Repository<SatelliteImage> repository = new();

            repository.Add(new SarImage(1, 20));
            repository.Add(new EoImage(1, 150));
            repository.Add(new IrImage(1, 4));
            repository.Add(new MultispectralImage(1, 25));

        }
    }
}
