using System;
using CoffeeMaker;
using Xunit;

namespace CoffeeMakerTests {
    public class UnitTest1 {
        OrderTranslator orderTranslator = new OrderTranslator();
        [Fact (DisplayName = "Accept User Input")]
        public void AcceptUserInput() {
            
            string order = "my order";
            
            Assert.IsType<string>(orderTranslator.Translate(order));
        }
        
        [Fact (DisplayName = "Validate User Input")]
        public void ValidateUserInput() {
            string order = "T:1:0";

            Assert.NotEqual("Invalid Order", orderTranslator.Translate(order));

        }

        [Fact]
        public void CannotInputInvalidOrder() {
            string order = "my order";
            
            Assert.Equal("Invalid Order", orderTranslator.Translate(order));
        }
        
        [Fact (DisplayName = "Process User Input")]
        public void ProcessUserInput() {
            var order = "T:1:0";
            Assert.Equal("Drink maker makes 1 tea with 1 sugar and a stick", orderTranslator.Translate(order));
        }
        //
        // [Fact (DisplayName = "Valid Input Returns one drink")]
        // public void ValidInputReturnsOneDrink() {
        // }
        //
        // [Fact (DisplayName = "Valid Input with one or more sugars has stick")]
        // public void ValidInputWithSugarHasStick() {
        // }
        //
        // [Fact (DisplayName = "Drink Maker Returns a Message to the interface")]
        // public void DrinkMakerReturnsMessageToInterface() {
        // }
    }
}