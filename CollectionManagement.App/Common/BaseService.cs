using CollectionManagement.App.Abstract;
using CollectionManagement.Domain.Common;
using CollectionManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.App.Common
{
    public class BaseService<T> : IService<T> where T: BaseEntity
    {
        public readonly string PATH_WAY = @"C:\tmp\CollectionManager\data.txt";
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
            List<T> items = new List<T>();
            items= Items.OrderBy(x=>x.Id).ToList();
            return Items;
        }
        public int GetLastId()
        {
            if(Items!=null&&Items.Count>0) 
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
        public T FindItemById(int id)
        {
            T entity = Items.FirstOrDefault(x => x.Id == id);
            return entity;
        }
        public void RemoveItem(T item)
        {
            if (item is not null)
            {
                Items.Remove(item);
            }
        }

        

        /*
        public int UpdateItem(T item)
        {
            var entity = Items.SingleOrDefault(x => x.Id == item.Id);
            if (entity is not null)
            {
                entity = item;
            }
            return item.Id;
        }*/
    }
}
