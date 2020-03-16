using CoffeeMaker;
using Xunit;

namespace CoffeeMakerTests {
    public class CafeTests {
        private Cafe myCafe;
        [Fact]
        public void OrderingATeaCostsZeroPointFourDollars() {
            //Arrange
            var order = "T:1:0";
            
            //Act
            var costOfTea = myCafe.TakeOrder(order);

            //Assert
            Assert.Equal(0.4, costOfTea);
        }
        
    }
}