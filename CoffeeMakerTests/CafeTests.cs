using System;
using CoffeeMaker;
using Xunit;

namespace CoffeeMakerTests {
    public class CafeTests {
        private CoffeeMachine _myCoffeeMachine = new CoffeeMachine();
        [Fact]
        public void TakingAnOrderReturnsCorrectCost() {
            //Arrange
            var order = "T:1:0";
            
            //Act
            var costOfTea = _myCoffeeMachine.TakeOrder(order);

            //Assert
            Assert.Equal(0.4, costOfTea);
        }
        
    }
}