using System;
using CoffeeMaker;
using Xunit;

namespace CoffeeMakerTests {
    public class CoffeeMachineTests {


        [Fact]
        public void TakingAnOrderReturnsCorrectCost() {
            
            CoffeeMachine myCoffeeMachine = new CoffeeMachine();
            //Arrange
            var order = "T:1:0";
            
            //Act
            var costOfTea = myCoffeeMachine.TakeOrder(order);

            //Assert
            Assert.Equal(0.4, costOfTea);
        }
        
    }
}