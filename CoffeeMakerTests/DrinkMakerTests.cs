using System;
using System.Collections.Generic;
using CoffeeMaker;
using CoffeeMaker.Business_Logic;
using Xunit;

namespace CoffeeMakerTests {
    public class DrinkMakerTests {
        private readonly DrinkMaker _drinkMaker = new DrinkMaker();
        private readonly FakeDrinkMaker _fakeDrinkMaker = new FakeDrinkMaker();
        
        [Fact (DisplayName = "Validate User Input")]
        public void ValidateUserInput() {
            var order = "T:1:0";

            Assert.NotNull(_drinkMaker.MakeDrink(order, MockMenu.Menu));
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
            Assert.NotStrictEqual(expectedDrink, _drinkMaker.MakeDrink(order, MockMenu.Menu));
        }

        [Fact (DisplayName = "Valid Input with one or more sugars has stick")]
        public void ValidInputWithSugarHasStick() {
            var order = "H:1:0";

            _drinkMaker.MakeDrink(order, MockMenu.Menu);
            Assert.True(_drinkMaker.stick);
        }
    }
}