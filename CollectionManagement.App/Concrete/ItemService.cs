using CollectionManagement.App.Common;
using CollectionManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.App.Concrete
{
    public class ItemService:BaseService<Item>
    {
        public bool CheckIfIdNotExist(int id)
        {
            var idDoesNotExist = Items.Find(x => x.Id.Equals(id));
            if (idDoesNotExist is null)
            {
                return true;
            }
            return false;
        }
        public bool UpdateItemFromList(Item item)
        {
            var toDeleteItem= Items.Find(x => x.Id.Equals(item.Id));
            if(toDeleteItem is not null)
            {
                RemoveFromList(item.Id);
                AddItem(new Item(item.Id, item.Name, item.Type));
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddItemToList(int id, string name, string type)
        {
            Item item = new Item(id, name, type);
            AddItem(item);
        }
        public void RemoveFromList(int id) 
        {
            //Usuwanie z listy jesli istnieje
            var itemToRemove= Items.Find(x => x.Id.Equals(id));
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }
        public List<Item> GetList(string type)
        {
            List<Item> result = new();
            foreach(Item item in Items)
            {
                if (item.Type == type||type=="All")
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public List<Item> ShowOneItem(int id) 
        {   
            List<Item> result = new List<Item>();
            foreach(Item item in Items)
            {
                if (item.Id==id)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public Item FindItemById(int id)
        {
            Item result = new();
            foreach (Item item in Items)
            {
                if (item.Id == id)
                {
                    result = item;
                }
            }
            return result;
        }
        public string OutDatedName(int id)
        {
            string name="NOT FOUND";
            foreach (Item item in Items)
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
            foreach (Item item in Items)
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
