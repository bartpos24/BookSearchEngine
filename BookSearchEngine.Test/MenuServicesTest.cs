using BookSearchEngine.App.Concrete;
using BookSearchEngine.Domain.Entity;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookSearchEngine.Test
{
    public class MenuServicesTest
    {
        [Fact]
        public void Should_GetEmptyList_When_GivenEmptyString()
        {
            //Arrange
            MenuServices menuService = new MenuServices();
            //Act
            List<Menu> result = menuService.GetMenuByMenuName("");

            //Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void Should_GetMenuActions_When_GivenMenuName()
        {
            //Arrange
            Menu menuAction1 = new Menu(1, "Check it", "Test");
            Menu menuAction2 = new Menu(2, "Check it one more", "Test");
            MenuServices menuService = new MenuServices();
            menuService.AddItem(menuAction1);
            menuService.AddItem(menuAction2);

            //Act
            List<Menu> result = menuService.GetMenuByMenuName("Test");

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(2);
            result.Should().StartWith(menuAction1);

            //Clear
            menuService.RemoveItem(menuAction1);
            menuService.RemoveItem(menuAction2);
        }
    }
}
