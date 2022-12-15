using CollectionManagement.App.Concrete;
using CollectionManagement.Domain.Entity;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.Tests.MenuServiceTests
{
    public class MenuServiceTests
    {
        [Fact]
        public void PassMenuByState_Expect_TheRightMenuOptions()
        {
            MenuService menuService = new();
            Menu newMenu = new Menu(8, "1. Figures", 1);

            var menuList=menuService.PassMenuListByState(1);

            Assert.NotNull(menuList);
            menuList.Should().AllBeOfType<Menu>();
            menuList.Should().HaveCount(4);
            menuList[0].Name.Should().Be("Please select the category");
            Assert.Equal(newMenu.Id, menuList[1].Id);
            Assert.Equal(newMenu.Name, menuList[1].Name);
            Assert.Equal(newMenu.State, menuList[1].State);
        }
    }
}
