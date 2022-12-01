using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Management
{
    public class MenuManager
    {
        List<Menu> menuList = new();
        public MenuManager() { }
        public void AddNewAction(int id,string description, int state)
        {
            Menu menuAction=new Menu() {Id=id,Description=description, State=state};
            menuList.Add(menuAction);
        }
        public void ShowMenuActionByState(int state) 
        {
            //Show actions of state
            foreach (Menu menu in menuList)
            {
                if(menu.State==state)
                { 
                    Console.WriteLine(menu.Description);
                }
                else
                { 
                    continue; 
                }
            }
        }
    }
}
