using CollectionManagement.App.Common;
using CollectionManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.App.Concrete
{
    public class MenuService : BaseService<Menu>
    {
        public MenuService()
        {
            InitializeMenu();
        }

        public List<Menu> PassMenuListByState(int state)
        {
            List<Menu> result = new List<Menu>();
            //Show actions of state
            foreach (Menu menu in Items)
            {
                if (menu.State == state)
                {
                    result.Add(menu);
                }
            }
            return result;
        }
        private void InitializeMenu()
        {

            AddItem(new Menu(1, "Please choose your action : ", 0));
            AddItem(new Menu(2, "1. Add Item", 0));
            AddItem(new Menu(3, "2. Update Item", 0));
            AddItem(new Menu(4, "3. Delete Item", 0));
            AddItem(new Menu(5, "4. Show Item", 0));
            AddItem(new Menu(6, "5. Show ALL Items", 0));

            AddItem(new Menu(7, "Please select the category", 1));
            AddItem(new Menu(8, "1. Figures", 1));
            AddItem(new Menu(9, "2. Coins", 1));
            AddItem(new Menu(10, "3. Teddies", 1));

            AddItem(new Menu(11, "Write id of item you want to add", 2));
            AddItem(new Menu(12, "Write name of item you want to add", 3));

            AddItem(new Menu(13, "Write the id of item you want to update", 4));

            AddItem(new Menu(14, "Write the id of item you want to delete", 5));

            AddItem(new Menu(15, "Write the id item you want to look into", 6));

            AddItem(new Menu(16, "4. All", 7));
            AddItem(new Menu(17, "You are about to see all items from the category", 8));
            AddItem(new Menu(18, "The item have been updated", 9));
            AddItem(new Menu(19, "Failed to update the item", 10));
        }   
    }
}

