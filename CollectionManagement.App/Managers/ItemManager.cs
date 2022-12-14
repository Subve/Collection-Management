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
    {   public const int SELECT_CATEGORY_MENU = 1;
        public const int SELECT_NEW_ITEM_NAME = 3;
        public const int SELECT_ADD_ID_MENU = 4;
        public const int SELECT_DELETE_ID_MENU = 5;
        public const int SELECT_SHOW_ID_MENU = 6;
        public const int ALL_TYPE_OPTION = 7;
        public const int PRE_SHOW_MESSAGE = 8;
        public const int AFTER_UPDATE_MESSAGE = 18;
        private readonly MenuService _menuService;
        private readonly ItemService _itemService;
        public ItemManager(MenuService menuService,ItemService itemService)
        {
            _itemService = itemService;
            _menuService = menuService;
        }
        public void UpdateItemView( Item item)
        {

            _itemService.UpdateItemByGivenItem(item);
            _menuService.FindItemById(AFTER_UPDATE_MESSAGE);
            
        }
        public int RemoveItemView()
        {
            
            int itemId=ValidateExistingItemId(SELECT_DELETE_ID_MENU);
            var foundItem = _itemService.FindItemById(itemId);
            _itemService.RemoveItem(foundItem);
            Console.WriteLine($"Deleted item with ID: {itemId}");
            return itemId;
        }
        public void ShowItemByIdView()
        {
            //Show item with id

            Item itemToShow;
            do
            {
                ShowMenuByState(SELECT_SHOW_ID_MENU);
                int itemId = Convert.ToInt32(Console.ReadLine());
                itemToShow = _itemService.FindItemById(itemId);
            } 
            while (itemToShow is null);
            Console.WriteLine($"Item ID: {itemToShow.Id} Item Name: {itemToShow.Name} Item Type: {itemToShow.Type}");
        }
        public void ShowItemsByCategoryView()
        {
            ShowMenuByState(SELECT_CATEGORY_MENU);
            ShowMenuByState(ALL_TYPE_OPTION);
            ShowMenuByState(PRE_SHOW_MESSAGE);
             string? categoryInput = Console.ReadLine();
             Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string categoryToDisplay = chosenCategory.ToString();
             List<Item> listToDisplay = _itemService.GetList(categoryToDisplay);
             foreach (var item in listToDisplay)
             {
                Console.WriteLine($"Item ID: {item.Id} Item Name: {item.Name} Item Type: {item.Type}");
             }
        }
        public int AddItemView()
        {
            string? categoryInput = "9";
            do
            {
                ShowMenuByState(SELECT_CATEGORY_MENU);
                categoryInput = Console.ReadLine();
            }
            while (!(categoryInput is "1" or "2" or "3"));
            Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string itemCategory = chosenCategory.ToString();
            int itemId = _itemService.GetLastId() + 1;
            string itemName=ValidateNewItemName();
            _itemService.AddItemToList(itemId, itemName, itemCategory);
            return itemId;
        }
        public void ShowMenuByState(int state)
        {
            var menuList = _menuService.PassMenuListByState(state);
            foreach (var menu in menuList)
            {
                Console.WriteLine(menu.Name);
            }
        }
        public int UpdateItemView()
        {
            int previousItemId=ValidateExistingItemId(SELECT_ADD_ID_MENU);
            var itemCategory=ValidateNewItemCategory();
            var itemName=ValidateNewItemName();
            var previousItem=_itemService.FindItemById(previousItemId);
            Item newItem = new Item(previousItemId, itemName, itemCategory);
            _itemService.UpdateItemByGivenItem(newItem);
            return newItem.Id;
        }
        public string ValidateNewItemName()
        {
            ShowMenuByState(SELECT_NEW_ITEM_NAME);
            string? itemName = Console.ReadLine();
            while (itemName is "")
            {
                Console.WriteLine("You didnt give a proper name! Try again.");
                itemName = Console.ReadLine();
            }
            return itemName;
        }
        public string ValidateNewItemCategory()
        {
            string? categoryInput;
            do
            {
                ShowMenuByState(SELECT_CATEGORY_MENU);
                categoryInput = Console.ReadLine();
            }
            while (!(categoryInput is "1" or "2" or "3"));
            Enum.TryParse(categoryInput, out ItemType chosenCategory);
            string itemCategory = chosenCategory.ToString();
            return itemCategory;
        }
        public int ValidateExistingItemId(int state)
        {
            int itemId;
            do
            {
                ShowMenuByState(state);
                itemId = Convert.ToInt32(Console.ReadLine());
            } while ((_itemService.FindItemById(itemId) is null));
            return itemId;
        }

    }
}
