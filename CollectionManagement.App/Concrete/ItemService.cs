using CollectionManagement.App.Common;
using CollectionManagement.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.App.Concrete
{
    public class ItemService:BaseService<Item>
    {
        private readonly FileService _fileService;
        public ItemService()
        {
            FileService fileService= new FileService();
            _fileService = fileService;
            GetListFromJson();
        }
        public int AddItemToList(int id, string name, string type)
        {
            Item newItem = new Item(id,name,type);
            AddItem(newItem);
            return newItem.Id;
        }
        private void RemoveFromList(int id) 
        {
            //Usuwanie z listy jesli istnieje
            var itemToRemove= FindItemById(id);
            RemoveItem(itemToRemove);
        }
        public int UpdateItemByGivenItem(Item item)
        {
            RemoveFromList(item.Id);
            Item updatedItem= new Item(item.Id,item.Name,item.Type);
            AddItemToList(updatedItem.Id, updatedItem.Name, updatedItem.Type);
            return updatedItem.Id;
        }
        public List<Item> GetList(string type)
        {
            List<Item> result = new();
            
            if (type == "All")
             {
                return GetAllItems();
             }

            foreach (Item item in Items)
             {
                result=Items.Where(x=>x.Type== type).OrderBy(x=>x.Id).ToList();
             }    
            return result;
        }
        public void GetListFromJson()=> Items = _fileService.LoadList();
        public void SaveListInJason()=>_fileService.SaveList(Items);
        
            
        

    }
}
