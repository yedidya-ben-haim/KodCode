namespace Project
{
    class ProjectDay2
    {
        interface IScorable
        {
            int Score();
        }

        interface IRetaskable
        {
            void Retask();
        }

        interface IThermalCalibratable
        {
            void CalibrateThermal();
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

        class SarImage : SatelliteImage, IScorable
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

        class QuickLookImage : SatelliteImage
        {
            public QuickLookImage(int id, double cloudCover) : base(id, cloudCover)
            {

            }

            public override string SensorName => "QuickLook";

            public override int Score()
            {
               return 0;
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

            public int Count => _items.Count;

            public List<T> GetAll()
            {
                return _items;
            }
        }


        public static void Main()
        {
            Repository<SatelliteImage> repository = new();




            try
            {
                repository.Add(new SarImage(1, 20));
                repository.Add(new QuickLookImage(1, 150));
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"dropped corrupt record {ex}");
            }

          
        }
    }
}

