using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Defining variables
            int trackId = 0;
            int speed = 0;
            string speedCategories = "unknown";
            double heading = 0.0;


            // tarckId reception
            Console.WriteLine("Enter the tarckId:");
            string tarckInput = Console.ReadLine();

            if (int.TryParse(tarckInput, out trackId))
            {
             
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for tarckId.");
            }

            // Speed reception
            Console.WriteLine("Enter the speed:");
            string speedInput = Console.ReadLine();

            if (int.TryParse(speedInput, out speed))
            {
                if (speed < 100) speedCategories = "slow";
                else if (speed < 300) speedCategories = "medium";
                else speedCategories = "fast";
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for speed.");

            }

            // Heading reception
            Console.WriteLine("Enter the heading:");
            string headingInput = Console.ReadLine();

            if (double.TryParse(headingInput, out heading))
            {
                if (heading < 0 || heading >= 360)
                {
                    Console.WriteLine("Invalid input. Please enter a valid heading between 0 and 359 degrees.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for heading.");

            }

            // Status reception
            Console.WriteLine("Enter the status:");
            string statusInput = Console.ReadLine();

            if (statusInput != "cruising" && statusInput != "turning" && statusInput != "stopped" && statusInput != "accelerating")
            {
                Console.WriteLine("Invalid input. Please enter a valid Status('cruising','turning','stopped','accelerating').");
            }



            Console.WriteLine("=== Track Report ===");
            Console.WriteLine($"Track ID: {trackId}");
            Console.WriteLine($"Speed: {speed} km/h ({speedCategories})");
            Console.WriteLine($"Heading: {heading} degrees");
            Console.WriteLine($"Status: {statusInput}");
            Console.WriteLine($"Division Demo 1: {heading}/30 = {heading/30}");
            Console.WriteLine($"Division Demo 2: {speed}/60 = {speed/60.0}");


        }
    }
}