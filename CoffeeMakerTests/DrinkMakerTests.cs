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

            Assert.NotNull(_drinkMaker.MakeDrink(order));
        }

        [Fact]
        public void CannotInputInvalidOrder() {
            var order = "INVALID ORDER";
            
            Assert.Throws<InvalidOrderException>(() => _fakeDrinkMaker.Translate(order));
        }
        
        [Fact (DisplayName = "Process User Input")]
        public void ProcessUserInput() {
            var order = "T:1:0";
   
            var expectedDrink = new Drink(DrinkType.Tea, 1, false);
            Assert.NotStrictEqual(expectedDrink, _drinkMaker.MakeDrink(order));
        }
        
        [Fact (DisplayName = "Valid Input Returns one drink")]
        public void ValidInputReturnsOneDrink() {
            var order = "C:1:";

            _drinkMaker.MakeDrink(order);
            Assert.Equal(1, _drinkMaker.numberOfDrinks);
        }
        
        [Fact (DisplayName = "Valid Input with one or more sugars has stick")]
        public void ValidInputWithSugarHasStick() {
            var order = "H:1:0";

            _drinkMaker.MakeDrink(order);
            Assert.True(_drinkMaker.stick);
        }
    }
}