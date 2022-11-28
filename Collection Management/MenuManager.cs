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
        public void AddNewAction(int id,string name,string description, int state)
        {
            Menu menuAction=new Menu() {Id=id,Name=name,Description=description, State=state};
            menuList.Add(menuAction);
        }
        public void ShowMenuAction(int state) 
        {
            //Show actions of state
            switch (state)
            {
                case 1:
                    {
                        foreach (Menu menu in menuList)
                        {
                           Console.WriteLine(menu.Description);

                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Menu menu in menuList)
                        {
                            Console.WriteLine(menu.Description);

                        }
                        break;
                    }
                default:
                    break;
            }
        }

        
    }
}
