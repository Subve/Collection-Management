using CollectionManagement.App.Concrete;
using CollectionManagement.Domain.Entity;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace CollectionManagement.Tests.ItemServiceTests
{
    public class ItemServiceDeleteTests
    {
        [Fact]
        public void RemoveItem_Expects_NullElementInColletion()
        {
            Item item= new Item(1,"Apple","Figure");
            ItemService itemService = new();
            itemService.AddItem(item);
            itemService.AddItem(new Item(2, "Banana", "Coin"));
            
            itemService.RemoveItem(item);
            
            itemService.Items.Should().NotContain(item);
        }
    }
}
