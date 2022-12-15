using CollectionManagement.App.Abstract;
using CollectionManagement.App.Common;
using CollectionManagement.Domain.Entity;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CollectionManagement.Tests.BaseSericeTests
{
    public class BaseServiceTests
    {
        [Fact]
        public void AddItem_Expect_ItemInList()
        {
            BaseService<Item> newBaseService= new BaseService<Item>();
            Item newItem = new(1,"Apple","Figure");

            newBaseService.AddItem(newItem);

            Assert.NotNull(newBaseService.Items);
            Assert.IsType<Item>(newBaseService.Items[0]);
            Assert.IsType<List<Item>>(newBaseService.Items);
            Assert.Contains<Item>(newItem, newBaseService.Items);
            Assert.Equal(newBaseService.Items[0], newItem);
        }
        [Fact]
        public void GetAllItems_Expect_ListOfAllItems()
        {
            BaseService<Item> newBaseService = new BaseService<Item>();
            var item2 = InitializeBaseService(newBaseService);

            var listOfAllItems=newBaseService.GetAllItems();

            Assert.NotNull(listOfAllItems);
            Assert.IsType<Item>(listOfAllItems[1]);
            listOfAllItems.Should().HaveCount(3);
            Assert.IsType<List<Item>>(listOfAllItems);           
            Assert.Contains<Item>(item2, listOfAllItems);
            Assert.Equal(listOfAllItems[1], item2);
        }
        [Fact]
        public void GetLastId_Expect_TheLastId()
        {
            BaseService<Item> newBaseService = new BaseService<Item>();
            InitializeBaseService(newBaseService);

            var lastId=newBaseService.GetLastId();

            Assert.NotNull(lastId);
            Assert.IsType<int>(lastId);
            Assert.Equal(3, lastId);
        }
        [Fact]
        public void FindItemById_Expect_TheItemWithASpecificId()
        {
            BaseService<Item> newBaseService = new BaseService<Item>();
            InitializeBaseService(newBaseService);

            var foundItem=newBaseService.FindItemById(2);

            Assert.NotNull(foundItem);
            Assert.IsType<Item>(foundItem);
            Assert.Equal(2, foundItem.Id);
            Assert.Equal("Apple2", foundItem.Name);
            Assert.Equal("Coin", foundItem.Type);
        }
        [Fact]
        public void RemoveItem_Expect_RemovingItemFromList()
        {
            BaseService<Item> newBaseService = new BaseService<Item>();
            var item2=InitializeBaseService(newBaseService);

            newBaseService.RemoveItem(item2);

            Assert.NotEmpty(newBaseService.Items);
            newBaseService.Items.Should().HaveCount(2);
            Assert.DoesNotContain<Item>(item2,newBaseService.Items);
            Assert.Equal("Apple", newBaseService.Items[0].Name);
            Assert.Equal("Teddy", newBaseService.Items[1].Type);

        }
        public Item InitializeBaseService(BaseService<Item> baseService)
        {
            Item newItem = new(1, "Apple", "Figure");
            baseService.AddItem(newItem);
            Item newItem2 = new(2, "Apple2", "Coin");
            baseService.AddItem(newItem2);
            Item newItem3 = new(3, "Apple3", "Teddy");
            baseService.AddItem(newItem3);
            return newItem2;
        }
    }
}
