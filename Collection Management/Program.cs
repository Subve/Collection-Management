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
        {   Console.WriteLine("Welcome to Your Collection Manager");
            char stopKey = 'c';
            ItemManager itemManager = new();
            MenuManager menuManager = new();
            InitializeMenu(menuManager);
            while (stopKey!='q')
            {   
                

                menuManager.ShowMenuActionByState(0);

                int chosenOperation;
                string? operation = Console.ReadLine();
                Int32.TryParse(operation, out chosenOperation);



                Console.WriteLine($"You have choosen option number: {chosenOperation}");
                
                //Int32.TryParse(categoryInput, out choosenCategory);

                switch (chosenOperation)
                {
                    case 1:
                        {
                            menuManager.ShowMenuActionByState(1);
                            string? categoryInput = Console.ReadLine();
                            menuManager.ShowMenuActionByState(2);
                            int itemId = Convert.ToInt32(Console.ReadLine());

                            Enum.TryParse(categoryInput, out ItemType chosenCategory);
                            bool idCheck=itemManager.CheckIfIdNotExist(itemId);
                            while (!idCheck)
                            {
                                Console.WriteLine($"ID {itemId} is taken. Please use an unused one.");
                                itemId = Convert.ToInt32(Console.ReadLine());
                            }
                            string itemCategory = chosenCategory.ToString();
                            menuManager.ShowMenuActionByState(3);
                            string? itemName = Console.ReadLine();
                            while (itemName is null)
                            {
                                Console.WriteLine("You didnt give a proper name! Try again.");
                                itemName = Console.ReadLine();
                            }
                            itemManager.AddToList(itemId, itemName, itemCategory);
                            
                            break;
                        }
                    case 2:
                        {
                            //Update
                            menuManager.ShowMenuActionByState(4);
                            int previousItemId = Convert.ToInt32(Console.ReadLine());
                            string tmpName=itemManager.OutDatedName(previousItemId);
                            string tmp_type=itemManager.OutDatedType(previousItemId);
                            menuManager.ShowMenuActionByState(1);
                            
                            string? categoryInput = Console.ReadLine();
                            menuManager.ShowMenuActionByState(2);
                            int itemId = Convert.ToInt32(Console.ReadLine());

                            Enum.TryParse(categoryInput, out ItemType chosenCategory);
                            string itemCategory = chosenCategory.ToString();
                            bool idCheck = itemManager.CheckIfIdNotExist(itemId);
                            if (itemId!=previousItemId)
                            {
                                while (!idCheck)
                                {
                                    Console.WriteLine("That ID exist. Enter another one.");
                                    itemId = Convert.ToInt32(Console.ReadLine());
                                    idCheck = itemManager.CheckIfIdNotExist(itemId);
                                }
                                menuManager.ShowMenuActionByState(3);
                                string? itemName = Console.ReadLine();
                                while (itemName is null)
                                {
                                    Console.WriteLine("You didnt give a proper name! Try again.");
                                    itemName = Console.ReadLine();
                                }
                                itemManager.RemoveFromList(previousItemId);
                                itemManager.AddToList(itemId, itemName, itemCategory);
                            }
                            else
                            {
                                menuManager.ShowMenuActionByState(3);
                                string? itemName = Console.ReadLine();
                                while (itemName is null)
                                {
                                    Console.WriteLine("You didnt give a proper name! Try again.");
                                    itemName = Console.ReadLine();
                                }
                                itemManager.RemoveFromList(previousItemId);
                                itemManager.AddToList(itemId, itemName, itemCategory);
                            }
                            break;
                        }
                    case 3:
                        {
                            //Delete
                            menuManager.ShowMenuActionByState(5);
                            int itemId = Convert.ToInt32(Console.ReadLine());
                            itemManager.RemoveFromList(itemId);
                            Console.WriteLine($"Deleted item with ID: {itemId}");
                            break;
                        }
                    case 4:
                        {
                            //Show item with id
                            menuManager.ShowMenuActionByState(6);
                            int itemId = Convert.ToInt32(Console.ReadLine());
                            List<Item> showedItem = new();
                            showedItem=itemManager.ShowOneItem(itemId);
                            foreach (var item in showedItem)
                            {
                                Console.WriteLine($"Item ID: {item.Id} Item Name: {item.Name} Item Type: {item.Type}");
                            }
                            break;
                        }   
                    case 5:
                        {
                            //Show all from category
                            menuManager.ShowMenuActionByState(1);
                            menuManager.ShowMenuActionByState(7);
                            menuManager.ShowMenuActionByState(8);
                            string? categoryInput = Console.ReadLine();
                            Enum.TryParse(categoryInput, out ItemType chosenCategory);
                            string categoryToDisplay=chosenCategory.ToString();
                            List<Item> listToDisplay=itemManager.GetList(categoryToDisplay);
                            foreach (var item in listToDisplay)
                            {
                                Console.WriteLine($"Item ID: {item.Id} Item Name: {item.Name} Item Type: {item.Type}");
                            }
                            break;
                        }

                }
                
                //Quit the app if 'q'
                menuManager.CloseTheApp(ref stopKey);
                



            }
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

            menuAction.AddNewAction(16, "4. All", 7);
            menuAction.AddNewAction(17, "You are about to see all items from the category", 8);



            return menuAction;
        }
    }
}