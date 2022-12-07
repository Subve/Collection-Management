using CollectionManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.Domain.Entity
{
    public class Item:BaseEntity
    {
        public string? Name { get; set; }
        public string? Type { get; set; }

        public Item()
        {

        }
        public Item(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
    
}
