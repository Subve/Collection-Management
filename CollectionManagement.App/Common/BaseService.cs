using CollectionManagement.App.Abstract;
using CollectionManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.App.Common
{
    public class BaseService<T> : IService<T> where T: BaseEntity
    {
        public List<T> Items { get; set ; }

        public BaseService() 
        { 
            Items= new List<T>();
        }
        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }
        public int GetLastId()
        {
            if(Items.Any()) 
            {   
                var id=Items.OrderBy(x => x.Id).LastOrDefault().Id;
                return id;
            }
            else
            {
                var id = 0;
                return id;
            }
        }
        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }
        public int UpdateItem(T item)
        {
            var entity= Items.FirstOrDefault(x=>x.Id==item.Id);
            if(entity is not null)
            {
                entity = item;
            }
            return item.Id;
        }
    }
}
