using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Management
{
    public class ItemManager
    {
        List<Item> itemList = new();
        public void AddToList(int id,string name, string type)
        {
            //Dodaj waruenk sprawdzajacy czy nie istnieje o takim id

            Item item= new Item() { Id=id,Name=name,Type=type};
            itemList.Add(item);
            
        }
        public void RemoveFromList(int id) 
        { 
            //Usuwanie z listy jesli istnieje
        }
        public List<Item> GetList(string type)
        {
            List<Item> result = new();
            foreach(Item item in itemList)
            {
                if (item.Type==type)
                {
                    result.Add(item);
                }
                else if(type=="All")
                {
                    result.Add(item);
                }

            }
            return result;
        }
        public List<Item> ShowOneItem(int id) 
        {   
            List<Item> result = new List<Item>();
            foreach(Item item in itemList)
            {
                if (item.Id==id)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
