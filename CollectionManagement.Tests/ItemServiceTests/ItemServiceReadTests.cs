using CollectionManagement.App.Concrete;
using CollectionManagement.Domain.Entity;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CollectionManagement.Tests.ItemServiceTests
{
    public class ItemServiceReadTests
    {
        public void InitializeItemList(ItemService _itemService)
        {
            Item item1 = new Item(1, "Apple", "Figure");
            _itemService.AddItem(item1);
            Item item2 = new Item(2, "Banana", "Figure");
            _itemService.AddItem(item2);
            Item item3 = new Item(3, "Bozena", "Coin");
            _itemService.AddItem(item3);
            Item item4 = new Item(4, "Helena", "Coin");
            _itemService.AddItem(item4);
            Item item5 = new Item(5, "Lucio", "Teddy");
            _itemService.AddItem(item5);
            Item item6 = new Item(6, "Gucio", "Teddy");
            _itemService.AddItem(item6);
        }
        [Fact]
        public void GetList_Expect_ListOfAllElements()
        {
            ItemService itemService = new();
            InitializeItemList(itemService);

            var list=itemService.GetList("All");

            Assert.NotEmpty(list);
            list.Should().HaveCount(6);
            Assert.Equal("Bozena", list[2].Name);
            Assert.Equal("Teddy", list[4].Type.ToString());
        }
        [Fact]
        public void GetList_Expect_ListOfFigures()
        {
            ItemService itemService = new();
            InitializeItemList(itemService);

            var list=itemService.GetList("Figure");

            Assert.NotEmpty(list);
            list.Should().HaveCount(2);
            Assert.Equal("Banana", list[1].Name);
            Assert.Equal("Figure", list[0].Type.ToString());
        }
        [Fact]
        public void GetList_Expect_ListOfTeddies()
        {
            ItemService itemService = new();
            InitializeItemList(itemService);

            var list = itemService.GetList("Teddy");

            Assert.NotEmpty(list);
            list.Should().HaveCount(2);
            Assert.Equal("Gucio", list[1].Name);
            Assert.Equal("Teddy", list[0].Type.ToString());
        }
    }
}
