using System;

namespace Collection_Management
{
    internal class Program
    {   
        //Przywitanie
        //Wybor operacji
        //A1 Pobranie danych do dodania
        //B1 Pobranie danych do update-u
        //C1 Pobranie danych do usuniecia
        //D1 Pokazanie przedmiotu
        //E1 Pokazanie wszystkich przedmiotow z kategorii
        //A2 Dodanie do listy
        //B2 pobranie danych do temp, usuniecie i dodanie zmienionego
        //C2 Usuniecie z listy
        public const string PATH_WAY = @"C:\Users\milos\Documents\Collection_Manager\ImportFile.xlsx";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Your Collection Manager");
            Console.WriteLine("Please choose your action : ");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Update Item");
            Console.WriteLine("3. Delete Item");
            Console.WriteLine("4. Show Item");
            Console.WriteLine("5. Show All Items from category");

            string? operation=Console.ReadLine();
            int chosenOperation = 0;
            Int32.TryParse(operation, out chosenOperation);


            Console.WriteLine($"You have choosen option number: {chosenOperation}");
            Console.WriteLine("Please choose collection : ");
            Console.WriteLine("1. Figures");
            Console.WriteLine("2. Coins");
            Console.WriteLine("3. Teddies");
            string? category=Console.ReadLine();
            ItemType chosenCategory;
            Enum.TryParse(category, out chosenCategory);
            
            if(chosenOperation==1) 
            {   if (chosenCategory==ItemType.Figure)
                {
                    //Add as figure
                }
                // Add the object
                Item item = new Item() { Id = 1, Name="Spiderman" };
            }
            else if (chosenOperation==2)
            {
                //Update the object
            }
            else if (chosenOperation==3)
            {
                //Delete the object

            }
            else if (chosenOperation==4)
            {
                //Show the object

            }
            else
            {   //The wrong option
                Console.WriteLine("Choose the right operation");
               
            }

        }
    }
}