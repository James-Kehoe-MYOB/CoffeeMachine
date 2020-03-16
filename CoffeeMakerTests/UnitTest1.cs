using System;
using CoffeeMaker;
using Xunit;

namespace CoffeeMakerTests {
    public class UnitTest1 {
        private readonly DrinkMaker _drinkMaker = new DrinkMaker();
        private readonly FakeDrinkMaker _fakeDrinkMaker = new FakeDrinkMaker();
        [Fact (DisplayName = "Accept User Input")]
        public void AcceptUserInput() {
            
            var order = "T:1:0";
            
            Assert.IsAssignableFrom<Drink>(_drinkMaker.MakeDrink(order));
        }
        
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
            var expectedDrink = new Tea(1);
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
        
        //[Fact (DisplayName = "Drink Maker Returns a Message to the interface")]
        // public void DrinkMakerReturnsMessageToInterface() {
        //     var message = "this is a message";
        //     var order = $"M:{message}";
        //     
        //     Assert.Equal("this is a message", _drinkMaker.MakeDrink(order));
        // }
    }
}