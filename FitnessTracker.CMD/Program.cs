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

            Console.WriteLine("Enter your gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter your date of birth");
            var birthDate = DateTime.Parse(Console.ReadLine()); //rewrite

            Console.WriteLine("Enter weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name,gender,birthDate,weight,height);
            userController.Save();
        }
    }
}
