using CoffeeMaker.Business_Logic;
using Moq;
using Xunit;

namespace CoffeeMakerTests {
    public class BeverageQuantityTests {

        [Fact(DisplayName = "IsEmpty Returns True When Beverage Quantity is Less than Required")]

        public void IsEmptyReturnsTrueWhenBeverageQuantityIsLessThanRequired() {
            
            var mock = new Mock<DrinkMaker>();
            mock.SetupProperty(f => f.WaterLevel, "50");
            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), mock.Object);
            
            Assert.True(coffeeMachine.WaterChecker.isEmpty("T:1:0"));
        }
    }
}