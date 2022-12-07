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
        public string GetItemToUpdate(int id,string name,string type)
        {
            _itemService.RemoveFromList(id);
            int newId = _itemService.GetLastId() + 1;
            Item item = new Item(newId, name,type);
            _itemService.AddItem(item);
            return _menuService.ShowMenuActionById(18);
        }
        public void GetItemToRemove()
        {
            _menuService.ShowMenuToUserByState(5);
            int itemId = Convert.ToInt32(Console.ReadLine());
            var foundItem = _itemService.FindItemById(itemId);
            _itemService.RemoveItem(foundItem);
            Console.WriteLine($"Deleted item with ID: {itemId}");
        }
        public void ShowUserItemById()
        {
            //Show item with id
            
            _menuService.ShowMenuToUserByState(6);
            int itemId = Convert.ToInt32(Console.ReadLine());
            List<Item> showedItem = new();
            showedItem = _itemService.ShowOneItem(itemId);
            foreach (var item in showedItem)
            {
                Console.WriteLine($"Item ID: {item.Id} Item Name: {item.Name} Item Type: {item.Type}");
            }
        }
        public void ShowUserAllFromCategory()
        {
            _menuService.ShowMenuToUserByState(1);
            _menuService.ShowMenuToUserByState(7);
            _menuService.ShowMenuToUserByState(8);
             string? categoryInput = Console.ReadLine();
             Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string categoryToDisplay = chosenCategory.ToString();
             List<Item> listToDisplay = _itemService.GetList(categoryToDisplay);
             foreach (var item in listToDisplay)
             {
                Console.WriteLine($"Item ID: {item.Id} Item Name: {item.Name} Item Type: {item.Type}");
             }
        }
        public void GetItemToAdd()
        {
            bool validCategory = false;
            string? categoryInput = "9";
            while (!validCategory)
            {
                _menuService.ShowMenuToUserByState(1);

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
            int itemId = _itemService.GetLastId() + 1;

            Enum.TryParse(categoryInput, out ItemType chosenCategory);
            while (!_itemService.CheckIfIdNotExist(itemId))
            {
                Console.WriteLine($"ID {itemId} is taken. Please use an unused one.");
                itemId = Convert.ToInt32(Console.ReadLine());
            }
            string itemCategory = chosenCategory.ToString();
            _menuService.ShowMenuToUserByState(3);
            string? itemName = Console.ReadLine();
            while (itemName is null)
            {
                Console.WriteLine("You didnt give a proper name! Try again.");
                itemName = Console.ReadLine();
            }
            _itemService.AddItemToList(itemId, itemName, itemCategory);
        }
        public void GetItemToUpdate()
        {
            _menuService.ShowMenuToUserByState(4);
            int previousItemId = Convert.ToInt32(Console.ReadLine());
            /* string tmpName= _itemManager.OutDatedName(previousItemId);
             string tmp_type= _itemManager.OutDatedType(previousItemId);*/
            _menuService.ShowMenuToUserByState(1);

            string? categoryInput = Console.ReadLine();

            Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string itemCategory = chosenCategory.ToString();

            _menuService.ShowMenuToUserByState(3);
            string? itemName = Console.ReadLine();
            while (itemName is null)
            {
                Console.WriteLine("You didnt give a proper name! Try again.");
                itemName = Console.ReadLine();
            }
            
            Console.WriteLine(GetItemToUpdate(previousItemId, itemName, itemCategory));
        }
        public void ShowUserTheBeginPanel()
        {
            _menuService.ShowMenuToUserByState(0);
        }

    }
}
