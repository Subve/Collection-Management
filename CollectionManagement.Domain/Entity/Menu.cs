using CollectionManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.Domain.Entity
{
    public class Menu:BaseEntity
    {
        public Menu(int id, string name, int state)
        {
            Id = id;
            Name= name;
            State= state;
        }
        public string? Name { get; set; }

        public int State { get; set; }
    }
}
