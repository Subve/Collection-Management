using CollectionManagement.App.Concrete;
using CollectionManagement.Domain.Entity;
using CollectionManagement.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.App.Managers
{
    public class ItemManager
    {
        private readonly MenuService _menuService;
        private readonly ItemService _itemService;
        public ItemManager(MenuService menuService,ItemService itemService)
        {
            _itemService = itemService;
            _menuService = menuService;
        }

        public void AddItemToList(int id,string name,string type)
        {
            Item item= new Item(id,name,type);
            _itemService.AddItem(item);
        }

        public ConsoleKeyInfo AddNewViewByState(int state)
        {
            
            var addNewMenu= _menuService.ShowMenuActionByState(state);
            for (int i=0;i<addNewMenu.Count();i++) 
            {
                Console.WriteLine($"{addNewMenu[i].Id}. {addNewMenu[i].Name}");
            }
            var operation=Console.ReadKey();
            return operation;
        }
        public bool CheckExistenceOfId(int id)
        {
            return _itemService.CheckIfIdNotExist(id);
        }

        public List<Item> GetList(string categoryToDisplay)
        {
            return _itemService.GetList(categoryToDisplay);
        }

        public string UpdateFromList(int id,string name,string type)
        {
            
            _itemService.RemoveFromList(id);
            int newId = GiveNewId();
            Item item = new Item(newId, name,type);
            _itemService.AddItem(item);

            return _menuService.ShowMenuActionById(18);
        }
        public int GiveNewId()
        { 
            return _itemService.GetLastId()+1;
        }
        public void RemoveItemFromList()
        {

            
            DisplayMenuByState(5);
            int itemId = Convert.ToInt32(Console.ReadLine());
            var foundItem = _itemService.FindItemById(itemId);
            _itemService.RemoveItem(foundItem);
            Console.WriteLine($"Deleted item with ID: {itemId}");
        }
        public void ShowOneItem()
        {
            //Show item with id
            
            DisplayMenuByState(6);
            int itemId = Convert.ToInt32(Console.ReadLine());
            List<Item> showedItem = new();
            showedItem = _itemService.ShowOneItem(itemId);
            foreach (var item in showedItem)
            {
                Console.WriteLine($"Item ID: {item.Id} Item Name: {item.Name} Item Type: {item.Type}");
            }
        }
        public void ShowAllFromCategory()
        {
           
            DisplayMenuByState(1);
          
            DisplayMenuByState(7);
            
            DisplayMenuByState(8);
             string? categoryInput = Console.ReadLine();
             Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string categoryToDisplay = chosenCategory.ToString();
             List<Item> listToDisplay = GetList(categoryToDisplay);
             foreach (var item in listToDisplay)
             {
                Console.WriteLine($"Item ID: {item.Id} Item Name: {item.Name} Item Type: {item.Type}");
             }
}
        public void AddView()
        {
            bool validCategory = false;
            string? categoryInput = "9";
            while (!validCategory)
            {
                DisplayMenuByState(1);

                categoryInput = Console.ReadLine();

                if (categoryInput is "1" or "2" or "3")
                {
                    validCategory = true;
                }
                else
                {
                    Console.WriteLine("Select proper category");
                }
            }
            //menuService.ShowMenuActionByState(2);
            int itemId = GiveNewId();

            Enum.TryParse(categoryInput, out ItemType chosenCategory);
            while (!CheckExistenceOfId(itemId))
            {
                Console.WriteLine($"ID {itemId} is taken. Please use an unused one.");
                itemId = Convert.ToInt32(Console.ReadLine());
            }
            string itemCategory = chosenCategory.ToString();
            DisplayMenuByState(3);
            string? itemName = Console.ReadLine();
            while (itemName is null)
            {
                Console.WriteLine("You didnt give a proper name! Try again.");
                itemName = Console.ReadLine();
            }
            AddItemToList(itemId, itemName, itemCategory);
        }
        public void DisplayMenuByState(int state)
        {
            var menuList = _menuService.ShowMenuActionByState(state);
            foreach (var menu in menuList)
            {
                Console.WriteLine(menu.Name);
            }
        }
        public void UpdateView()
        {
            DisplayMenuByState(4);
            int previousItemId = Convert.ToInt32(Console.ReadLine());
            /* string tmpName= _itemManager.OutDatedName(previousItemId);
             string tmp_type= _itemManager.OutDatedType(previousItemId);*/
            DisplayMenuByState(1);

            string? categoryInput = Console.ReadLine();

            Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string itemCategory = chosenCategory.ToString();

            DisplayMenuByState(3);
            string? itemName = Console.ReadLine();
            while (itemName is null)
            {
                Console.WriteLine("You didnt give a proper name! Try again.");
                itemName = Console.ReadLine();
            }
            
            Console.WriteLine(UpdateFromList(previousItemId, itemName, itemCategory));
        }

    }
}
