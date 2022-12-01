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

            MenuManager menuManager = new();
            InitializeMenu(menuManager);
            menuManager.ShowMenuActionByState(0);
            
            int chosenOperation = 0;
            string? operation = Console.ReadLine();
            Int32.TryParse(operation, out chosenOperation);
            
            

            Console.WriteLine($"You have choosen option number: {chosenOperation}");

            if(chosenOperation==1)
            {
                menuManager.ShowMenuActionByState(chosenOperation); ;
            }
            chosenOperation++;    
            menuManager.ShowMenuActionByState(chosenOperation);
            string? category=Console.ReadLine();
            ItemType chosenCategory;
            Enum.TryParse(category, out chosenCategory);
            
            /*if(chosenOperation==1) 
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
            */
            
        }    
        private static MenuManager InitializeMenu(MenuManager menuAction)
        {
            
            menuAction.AddNewAction(1, "Please choose your action : ", 0);
            menuAction.AddNewAction(2, "1. Add Item", 0);
            menuAction.AddNewAction(3, "2. Update Item", 0);
            menuAction.AddNewAction(4, "3. Delete Item", 0);
            menuAction.AddNewAction(5, "4. Show Item", 0);
            menuAction.AddNewAction(6, "5. Show ALL Items", 0);

            menuAction.AddNewAction(7, "Please select the category", 1);
            menuAction.AddNewAction(8, "1. Figures", 1);
            menuAction.AddNewAction(9, "2. Coins", 1);
            menuAction.AddNewAction(10, "3. Teddies", 1);

            menuAction.AddNewAction(11, "Write id of item you want to add",2);
            menuAction.AddNewAction(12, "Write name of item you want to add",3);

            menuAction.AddNewAction(13, "Write the id of item you want to update", 4);

            menuAction.AddNewAction(14, "Write the id of item you want to delete", 5);

            menuAction.AddNewAction(15, "Write the id item you want to look into", 6);

            menuAction.AddNewAction(16, "You are about to see all items from category", 7);

            

            return menuAction;
        }
    }
}