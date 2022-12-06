using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Management
{
    internal interface IMenu
    {
        int Id { get; set; }

        string? Description { get; set; }

        int State { get; set; }
    }
}
