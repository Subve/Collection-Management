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
        public int GetItemToUpdate( Item item)
        {

            _itemService.UpdateItemByGivenItem(item);
            _menuService.ShowMenuActionById(18);
            return item.Id;
        }
        public int GetItemToRemoveView()
        {
            _menuService.ShowMenuToUserByState(5);
            int itemId = Convert.ToInt32(Console.ReadLine());
            var foundItem = _itemService.FindItemById(itemId);
            _itemService.RemoveItem(foundItem);
            Console.WriteLine($"Deleted item with ID: {itemId}");
            return itemId;
        }
        public int ShowUserItemById()
        {
            //Show item with id
            _menuService.ShowMenuToUserByState(6);
            int itemId = Convert.ToInt32(Console.ReadLine());
            var itemToShow = _itemService.ShowOneItem(itemId);
            Console.WriteLine($"Item ID: {itemToShow.Id} Item Name: {itemToShow.Name} Item Type: {itemToShow.Type}");
            return itemToShow.Id;
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
        public int GetItemToAddView()
        {
            var categoryInput = _menuService.ValidateTheCategory();
            Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string itemCategory = chosenCategory.ToString();
            int itemId = _itemService.GetLastId() + 1;
            var itemName = _menuService.ValidateTheName();
            _itemService.AddItemToList(itemId, itemName, itemCategory);
            return itemId;
        }
        public int GetItemToUpdateView()
        {
            _menuService.ShowMenuToUserByState(4);
            int previousItemId = Convert.ToInt32(Console.ReadLine());
            _menuService.ShowMenuToUserByState(1);
            string? categoryInput = Console.ReadLine();
            Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string itemCategory = chosenCategory.ToString();
            var itemName=_menuService.ValidateTheName();
            var previousItem=_itemService.FindItemById(previousItemId);
            Item newItem = new Item(previousItemId, itemName, itemCategory);
            GetItemToUpdate(newItem);
            Console.WriteLine();
            return newItem.Id;
        }
        public void ShowUserTheBeginPanel()
        {
            _menuService.ShowMenuToUserByState(0);
        }

    }
}
