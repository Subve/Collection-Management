using CollectionManagement.App.Concrete;
using CollectionManagement.Domain.Entity;

namespace CollectionManagement.Tests.ItemServiceTests
{
    public class ItemServiceAddTests
    {
        public void AddItemToList_Expect_AttendItemToList()
        {
            ItemService _itemService = new();
            Item item = new Item(1, "Apple", "Figure");

            _itemService.AddItem(item);

            Assert.NotEmpty(_itemService.Items);
            Assert.Contains<Item>(item, _itemService.Items);
        }
        [Fact]
        public void Collection_Contains_Added_Item()
        {
            //Arange
            ItemService _itemService = new();
            Item newItem = new Item(1, "Apple", "Figure");

            //Act
            _itemService.AddItem(newItem);
            //Assert
            Assert.Contains<Item>(newItem, _itemService.Items);
        }
        [Fact]
        public void FindItemById_Finds_The_Right_Element()
        {
            //Arange
            ItemService _itemService = new();
            Item newItem = new Item(1, "Apple", "Figure");
            _itemService.AddItem(newItem);
            //Act
            var foundItem = _itemService.FindItemById(newItem.Id);
            //Assert
            Assert.NotNull(foundItem);
            Assert.IsType<Item>(foundItem);
            Assert.Same(newItem, foundItem);
        }
        [Fact]
        public void GetLastId_Returns_LastId()
        {
            //Arange
            ItemService _itemService = new();
            Item newItem = new Item(1, "Apple", "Figure");
            Item newItem2 = new Item(2, "Banana", "Coin");
            _itemService.AddItem(newItem);
            _itemService.AddItem(newItem2);

            var lastId = _itemService.GetLastId();

            Assert.NotNull(lastId);
            Assert.IsType<int>(lastId);
            Assert.Equal(2, lastId);
        }
    }
}