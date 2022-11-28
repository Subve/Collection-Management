using System;

namespace Collection_Management
{
    internal class Program
    {
        public const string PATH_WAY = @"C:\Users\milos\Documents\Collection_Manager\ImportFile.xlsx";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Your Collection Manager");
            Console.WriteLine("Please choose your action : ");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Update Item");
            Console.WriteLine("3. Delete Item");
            Console.WriteLine("4. Show Item");

            string? choose=Console.ReadLine();
            int chosenOption = 0;
            Int32.TryParse(choose, out chosenOption);

            Console.WriteLine($"You have choosen option number: {chosenOption}");
        }
    }
}