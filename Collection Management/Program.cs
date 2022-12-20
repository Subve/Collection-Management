using System;
using Collection_Management.Helpers;
using CollectionManagement.App.Concrete;
using CollectionManagement.Domain.Entity;
using CollectionManagement.App.Managers;

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
        public const int MENU_START = 0;
        
        static void Main(string[] args)
        {
            MenuService menuService = new();
            ItemService itemService = new();
            ItemManager _itemManager = new(menuService,itemService);
            Console.WriteLine("Welcome to Your Collection Manager");
            char stopKey = 'c';
            while (stopKey!='q')
            {
                _itemManager.ShowMenuByState(MENU_START);
                int chosenOperation;
                string? operation = Console.ReadLine();
                Int32.TryParse(operation, out chosenOperation);
                Console.WriteLine($"You have choosen option number: {chosenOperation}");
                
                //Int32.TryParse(categoryInput, out choosenCategory);

                switch (chosenOperation)
                {
                    case 1:
                        {
                            _itemManager.AddItemView();
                            
                            break;
                        }
                    case 2:
                        {
                            //Update
                            _itemManager.UpdateItemView();
                            break;
                        }
                    case 3:
                        {
                            //Delete
                            _itemManager.RemoveItemView();
                            break;
                        }
                    case 4:
                        {
                            //Show one item by id
                            _itemManager.ShowItemByIdView();
                            break;
                        }   
                    case 5:
                        {
                            //Show all from category
                            _itemManager.ShowItemsByCategoryView();
                            break;
                        }
                }
                //Quit the app if 'q'
                Console.WriteLine();
                Console.WriteLine("Press 'q' to quit");
                Console.WriteLine("Press 'c' to continue");
                stopKey = char.Parse(Console.ReadLine());
                if (stopKey == 'q')
                { 
                    _itemManager.GetDecisionAboutSaving();
                }
            }
        }
    }
}