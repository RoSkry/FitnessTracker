using FitnessTracker.BL.Controller;
using System;

namespace FitnessTracker.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Enter your name");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter gender");
                var gender = Console.ReadLine();

                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height"); ;

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Enter date of birth (dd.MM.yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong date format");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong {name} format");
                }
            }
        }
    }
}
