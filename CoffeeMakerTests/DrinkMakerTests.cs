using System;
using System.Collections.Generic;
using CoffeeMaker;
using CoffeeMaker.Business_Logic;
using Xunit;

namespace CoffeeMakerTests {
    public class DrinkMakerTests {
        static MockMenu testMenu = new MockMenu();
        private readonly DrinkMaker _drinkMaker = new DrinkMaker(testMenu.Menu);
        private readonly FakeDrinkMaker _fakeDrinkMaker = new FakeDrinkMaker(testMenu.Menu);
        
        [Fact (DisplayName = "Validate User Input")]
        public void ValidateUserInput() {
            var order = "T:1:0";
            var orderComponents = order.Split(':');
            Assert.NotNull(_drinkMaker.MakeDrink(orderComponents));
        }

        [Fact]
        public void CannotInputInvalidOrder() {
            var order = "INVALID ORDER";
            
            Assert.Throws<InvalidOrderException>(() => _fakeDrinkMaker.Translate(order));
        }
        
        [Fact (DisplayName = "Process User Input")]
        public void ProcessUserInput() {
            var order = "T:1:0";
            var orderComponents = order.Split(':');
            var expectedDrink = new Drink(DrinkType.Tea, 1, false);
            Assert.NotStrictEqual(expectedDrink, _drinkMaker.MakeDrink(orderComponents));
        }
        
        [Fact (DisplayName = "Valid Input Returns one drink")]
        public void ValidInputReturnsOneDrink() {
            var order = "C:1:";
            var orderComponents = order.Split(':');
            _drinkMaker.MakeDrink(orderComponents);
            Assert.Equal(1, _drinkMaker.numberOfDrinks);
        }
        
        [Fact (DisplayName = "Valid Input with one or more sugars has stick")]
        public void ValidInputWithSugarHasStick() {
            var order = "H:1:0";
            var orderComponents = order.Split(':');
            _drinkMaker.MakeDrink(orderComponents);
            Assert.True(_drinkMaker.stick);
        }
    }
}