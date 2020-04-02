using System.Text.RegularExpressions;
using CoffeeMaker;
using CoffeeMaker.Business_Logic;
using Moq;
using Xunit;

namespace CoffeeMakerTests {
    public class BeverageQuantityTests {

        [Fact(DisplayName = "IsEmpty Returns True When Beverage Quantity is Less than Required")]

        public void IsEmptyReturnsTrueWhenBeverageQuantityIsLessThanRequired() {
            
            var drinkMaker = new DrinkMaker {WaterLevel = 50};
            
            // var mock = new Mock<IDrinkMaker>();
            // mock.SetupSet(f => f.WaterLevel = 50);
            
            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), drinkMaker);
            
            Assert.True(coffeeMachine.WaterChecker.isEmpty(new MenuItem("T", DrinkType.Tea, 0.4, true, 100, 10), coffeeMachine._drinkMaker.WaterLevel));
        }
        
        [Fact(DisplayName = "IsEmpty Returns False When Beverage Quantity has Enough for Drink")]

        public void IsEmptyReturnsFalseWhenBeverageQuantityHasEnoughForDrink() {


            var drinkMaker = new DrinkMaker {WaterLevel = 150};


            // var mock = new Mock<IDrinkMaker>();
            // mock.SetupSet(f => f.WaterLevel = 150);
            
            
            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), drinkMaker);
            
            Assert.False(coffeeMachine.WaterChecker.isEmpty(new MenuItem("T", DrinkType.Tea, 0.4, true, 100, 10), coffeeMachine._drinkMaker.WaterLevel));
        }
        
        [Fact(DisplayName = "Ordering a drink depletes correct amount of resources")]

        public void OrderingADrinkDepletesCorrectAmountOfResources() {

            var drinkMaker = new DrinkMaker {WaterLevel = 150};
            var coffeeMachine = new CoffeeMachine(new MakeTeaOneSugarUI(), drinkMaker);
            coffeeMachine.MakeSelection();
            
            Assert.Equal(50, coffeeMachine._drinkMaker.WaterLevel);
        }


    }
}