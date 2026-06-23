

namespace project_day_2
{
    class Exercise
    {

        static void Main()
        {
            static void PrintMenu()
            {
                Console.WriteLine("""
                    ====================
                    = Signal Intercept =
                    ====================
                    1. log a new transmission.
                    2. calibrate the strength of an existing source.
                    3. list all sources.
                    4. Exit

                    Choose option (1-4)
                    """);

                
            }


            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine(PrintMenu);

                string userInput = Console.ReadLine();

                
                if (int.TryParse(userInput, out int input))
                {
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("1");
                            break;

                        case 4:
                            Console.WriteLine("Exit");
                            keepRunning = false;
                            break;
                        


                    }
                   
                }
            }


        }
    }
}