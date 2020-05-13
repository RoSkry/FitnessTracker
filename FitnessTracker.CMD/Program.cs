using FitnessTracker.BL.Controller;
using FitnessTracker.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace FitnessTracker.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("FitnessTracker.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter gender");
                var gender = Console.ReadLine();

                var birthDate = ParseDateTime("date of birth");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("What do you want to do ?");
                Console.WriteLine("E - enter eating");
                Console.WriteLine("A - enter exercise");
                Console.WriteLine("Q - exit");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var ex = EnterExercise();
                        exerciseController.Add(ex.Activity, ex.Begin, ex.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity.Name} from {item.Start.ToShortTimeString()} till {item.Finish.ToShortTimeString()}");
                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Enter exercise name");
            var name = Console.ReadLine();

            var energy = ParseDouble("consumption of energy");
            var begin = ParseDateTime("beginning of exercise");
            var end = ParseDateTime("end of exercise");

            var activity = new Activity(name, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Enter product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("callories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");

            var weight = ParseDouble("portion weight");

            var product = new Food(food, calories, proteins, fats, carbohydrates);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Enter {value} (dd.MM.yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Wrong date format {value}");
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
