using System;
using CoffeeMaker;
using Xunit;

namespace CoffeeMakerTests {
    public class UnitTest1 {
        
        [Fact (DisplayName = "Accept User Input")]
        public void AcceptUserInput() {
            OrderTranslator orderTranslator = new OrderTranslator();
            string order = "my order";
            
            Assert.IsType<string>(orderTranslator.Translate(order));
        }
        
        [Fact (DisplayName = "Validate User Input")]
        public void ValidateUserInput() {
        }
        
        [Fact (DisplayName = "Process User Input")]
        public void ProcessUserInput() {
        }
        
        [Fact (DisplayName = "Valid Input Returns one drink")]
        public void ValidInputReturnsOneDrink() {
        }
        
        [Fact (DisplayName = "Valid Input with one or more sugars has stick")]
        public void ValidInputWithSugarHasStick() {
        }
        
        [Fact (DisplayName = "Drink Maker Returns a Message to the interface")]
        public void DrinkMakerReturnsMessageToInterface() {
        }
    }
}