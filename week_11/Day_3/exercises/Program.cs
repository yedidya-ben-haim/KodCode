namespace project_day_2
{
    class Exercise
    {
        enum ClassificationStatus { Friendly = 1, Hostile = 2, Nunidentified = 3 }


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


        static int GetId()
        {
            while (true)
            {
                Console.Write("Please enter source ID: ");
                string idInput = Console.ReadLine();

                if (int.TryParse(idInput, out int validId))
                {
                    return validId;
                }
                else
                {
                    Console.WriteLine("Error: ID must be number. Try again.");
                }
            }
        }


        static double? GetNewSignalStrength()
        {
            while (true)
            {
                Console.Write("Please enter source signal strength: ");
                string signalStrengthInput = Console.ReadLine();

                // The user did not enter anything.
                if (string.IsNullOrEmpty(signalStrengthInput))
                {
                    return null;
                }

                if (double.TryParse(signalStrengthInput, out double validStrengthInput))
                {
                    return validStrengthInput;
                }
                else
                {
                    Console.WriteLine("Error: signal strength must be double number. Try again.");
                }
            }
        }


        static ClassificationStatus GetNewClassification()
        {
            while (true)
            {
                Console.WriteLine("Please enter source Classification:");
                Console.WriteLine("""
                                    1 = Friendly
                                    2 = Hostile
                                    3 = Unidentified
                                    """);
                Console.Write("Choose option (1-3): ");

                string classificationInput = Console.ReadLine();


                if (int.TryParse(classificationInput, out int validClassification)
                    && validClassification >= 1 && validClassification <= 3)
                {

                    return (ClassificationStatus)validClassification;
                }
                else
                {

                    Console.WriteLine("Invalid selection. Please enter 1, 2, or 3.");
                }
            }
        }



        static void ShowAll(List<int> Ids, List<double?> signalStrengthList, List<ClassificationStatus> classificationList)
        {

            Console.WriteLine("=======all Signal Intercept========== ");


            for (int i = 0; i < Ids.Count; i++)
            {

                string signalStrength = signalStrengthList[i]?.ToString()?? "unknown";


                Console.WriteLine($"""
                    \nId: {Ids[i]}
                    Signal strength: {signalStrength}
                    Classification status: {classificationList[i]}
                    """);
            }
        }



        static void Main()
        {
            List<int> IdList = new();
            List<double?> signalStrengthList = new();
            List<ClassificationStatus> classificationList = new();


            bool keepRunning = true;

            while (keepRunning)
            {
                PrintMenu();

                string userInput = Console.ReadLine();


                if (int.TryParse(userInput, out int input))
                {
                    switch (input)
                    {
                        case 1:
                            int newId = GetId();
                            ClassificationStatus newClassification = GetNewClassification();
                            double? newSignalStrength = GetNewSignalStrength();

                            IdList.Add(newId);
                            classificationList.Add(newClassification);
                            signalStrengthList.Add(newSignalStrength);
                            break;
                        
                        case 2:
                            int inputId = GetId();
                            int index = IdList.IndexOf(inputId);
                            if (index >= 0)
                            {
                                double? inputSignalStrength = GetNewSignalStrength();
                                signalStrengthList[index] = inputSignalStrength;
                            }
                            else
                            {
                                Console.WriteLine("The id does not exist.");
                            }
                            break;

                        case 3:
                            ShowAll(IdList, signalStrengthList, classificationList);
                            break;

                        case 4:
                            Console.WriteLine("Exit");
                            keepRunning = false;
                            break;

                        default:
                            Console.WriteLine("Please enter a number between 1-4");
                            break;
                    }

                }
            }


        }
    }
}