using CollectionManagement.App.Concrete;
using CollectionManagement.Domain.Entity;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.Tests.ItemServiceTests
{
    public class ItemServiceUpdateTests
    {
        [Fact]
        public void UpdateItemByGivenItem_Expect_UpdatedItemInCollection()
        {
            ItemService itemService= new ItemService();
            Item previousItem = new Item(1,"Apple","Coin");
            itemService.AddItem(previousItem);
            Item newItem = new Item(1, "Ferdek", "Teddy");
            
            itemService.UpdateItemByGivenItem(newItem);

            
            itemService.Items.Should().NotBeEmpty();
            Assert.Equal(previousItem.Id, newItem.Id);
            itemService.Items.Should().NotContain(previousItem);
            //itemService.Items.Should().Contain(newItem);
            Assert.Contains(itemService.Items, i => i.Id == newItem.Id);
            Assert.Contains(itemService.Items, i => i.Name == newItem.Name);
            Assert.Contains(itemService.Items, i => i.Type == newItem.Type);
        }
    }
}
