
namespace poject
{
    class Program
    {
        abstract class Platform
        {
            protected int TrackId { get; }
            protected double _speedKnots; 
            protected double _heading;

            protected double Heading
            {
                get => _heading;

                set
                {
                    if (value < 0 || value > 359)
                    {
                        Console.WriteLine("heading must be > 0 and < 359");
                        _heading = 0;
                    }
                    else
                    {
                        _heading = value;
                    }
                }
            }

            protected double SpeedKnots
            {
                get => _speedKnots;

                set
                {
                    if (value < 0)
                    {
                        _speedKnots = 0;
                    }
                    else
                        _speedKnots = value;
                }
            }


            protected Platform(int trackId, double speedKnots, double heading)
            {
                TrackId = trackId;
                SpeedKnots = speedKnots;
                Heading = heading;
            }

            public abstract string StatusLine();

            public abstract bool IsTrackable();

            public override string ToString()
            {
                return $"TrackId: {TrackId} | SpeedKnots: {SpeedKnots} | Heading: {Heading}";
            }

        }


        class AirPlatform : Platform
        {
            private double AltitudeFeet { get; set; }

            public AirPlatform(int trackId, double speedKnots, double heading, double altitudeFeet) : base(trackId, speedKnots, heading)
            {
                AltitudeFeet = altitudeFeet;
            }


            public override bool IsTrackable()
            {
                if (AltitudeFeet >= 100 && AltitudeFeet <= 60000 && SpeedKnots > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override string StatusLine()
            {
                return $"AirPlatform {TrackId} is flying at speed {SpeedKnots} in direction {Heading} at altitude {AltitudeFeet}";
            }

        }

        class SeaPlatform : Platform
        {
            private double DepthMeters { get; set;}

            public SeaPlatform(int trackId, double speedKnots, double heading, double depthMeters) 
                : base(trackId, speedKnots, heading)
            {
                DepthMeters = depthMeters;
            }

            public override bool IsTrackable()
            {
                if (DepthMeters >= 0 && DepthMeters <= 300)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override string StatusLine()
            {
                return $"SeaPlatform {TrackId} was sailing at speed {SpeedKnots} in direction {Heading} at depth {DepthMeters}";
            }

        }

        class GroundPlatform : Platform
        {
            private string TerrainType { get; set; }


            public GroundPlatform(int trackId, double speedKnots, double heading, string terrainType) 
                : base(trackId, speedKnots, heading)
            {
                TerrainType = terrainType;
            }

            public override bool IsTrackable()
            {
                if (TerrainType.ToLowerInvariant() == "tunnel")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public override string StatusLine()
            {
                return $"Ground Platform {TrackId} traveling at speed {SpeedKnots} in direction {Heading} terrain type {TerrainType}";
            }

        }


        static void Main()
        {
            List<Platform> platforms = new();

            platforms.Add(new AirPlatform(1, 20, 30, 40));
            platforms.Add(new AirPlatform(2, 20, 30, 120));
            platforms.Add(new SeaPlatform(3, 40, 50, 60));
            platforms.Add(new SeaPlatform(4, 20, 30, 400));
            platforms.Add(new GroundPlatform(5, 20, 30, "road"));
            platforms.Add(new GroundPlatform(6, 20, 30, "Tunnel"));


            foreach (Platform platform in platforms)
            {
                Console.WriteLine(platform.StatusLine());
                Console.WriteLine($"Is Trackable: {platform.IsTrackable()}");
            }








        }


    }
}