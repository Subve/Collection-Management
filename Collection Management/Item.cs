using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Management
{
    public class Item: IItem
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
    public enum EnumType
    {
        Figures=1,
        Coins,
        Teddies
    }
}
