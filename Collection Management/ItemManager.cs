﻿using System;
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
        public bool CheckIfIdNotExist(int id)
        {
            var idDoesNotExist = itemList.Find(x => x.Id.Equals(id));
            if (idDoesNotExist is null)
            {
                return true;
            }
            return false;
        }
        public void RemoveFromList(int id) 
        {
            //Usuwanie z listy jesli istnieje
            var itemToRemove=itemList.Find(x => x.Id.Equals(id));
            if (itemToRemove != null)
            {
                itemList.Remove(itemToRemove);
            }
        }
        public List<Item> GetList(string type)
        {
            List<Item> result = new();
            foreach(Item item in itemList)
            {
                if (item.Type==type||type=="All")
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
        public string OutDatedName(int id)
        {
            string name="NOT FOUND";
            foreach (Item item in itemList)
            {
                if (item.Id == id&& item.Name is not null)
                {
                    name = item.Name;
                }
                
            }
            return name;
        }
        public string OutDatedType(int id)
        {
            string type = "NOT FOUND";
            foreach (Item item in itemList)
            {
                if (item.Id == id&&item.Type is not null)
                {
                    type = item.Type;

                }

            }
            return type;
        }
    }
}
