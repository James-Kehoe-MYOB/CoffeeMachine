using System.Text.RegularExpressions;
using CoffeeMaker;
using CoffeeMaker.Business_Logic;
using Moq;
using Xunit;

namespace CoffeeMakerTests {
    public class BeverageQuantityTests {

        [Fact(DisplayName = "IsEmpty Returns True When Water Quantity is Less than Required")]

        public void IsEmptyReturnsTrueWhenWaterQuantityIsLessThanRequired() {

            var drinkMaker = new DrinkMaker {WaterLevel = 50};

            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), drinkMaker);
            var tea = new MenuItem("T", DrinkType.Tea, 0.4, true, 100, 10);
            
            Assert.True(coffeeMachine.WaterChecker.isEmpty(tea, coffeeMachine._drinkMaker.WaterLevel));
        }
        
        [Fact(DisplayName = "IsEmpty Returns True When Milk Quantity is Less than Required")]

        public void IsEmptyReturnsTrueWhenMilkQuantityIsLessThanRequired() {
            
            var drinkMaker = new DrinkMaker {MilkLevel = 5};

            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), drinkMaker);
            var tea = new MenuItem("T", DrinkType.Tea, 0.4, true, 100, 10);
            
            Assert.True(coffeeMachine.MilkChecker.isEmpty(tea, coffeeMachine._drinkMaker.MilkLevel));
        }
        
        [Fact(DisplayName = "IsEmpty Returns False When Milk Quantity has Enough for Drink")]

        public void IsEmptyReturnsFalseWhenWaterQuantityHasEnoughForDrink() {
            
            var drinkMaker = new DrinkMaker {WaterLevel = 150};

            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), drinkMaker);
            var tea = new MenuItem("T", DrinkType.Tea, 0.4, true, 100, 10);
            
            Assert.False(coffeeMachine.WaterChecker.isEmpty(tea, coffeeMachine._drinkMaker.WaterLevel));
        }
        
        [Fact(DisplayName = "IsEmpty Returns False When Milk Quantity has Enough for Drink")]
        public void IsEmptyReturnsFalseWhenMilkQuantityHasEnoughForDrink() {
            
            var drinkMaker = new DrinkMaker {MilkLevel = 150};

            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), drinkMaker);
            var tea = new MenuItem("T", DrinkType.Tea, 0.4, true, 100, 10);
            
            Assert.False(coffeeMachine.MilkChecker.isEmpty(tea, coffeeMachine._drinkMaker.MilkLevel));
        }
        
        [Fact(DisplayName = "Ordering a drink depletes correct amount of Water")]

        public void OrderingADrinkDepletesCorrectAmountOfWater() {

            var drinkMaker = new DrinkMaker {WaterLevel = 150};
            var coffeeMachine = new CoffeeMachine(new MakeTeaOneSugarUI(), drinkMaker);
            coffeeMachine.MakeSelection();
            
            Assert.Equal(50, coffeeMachine._drinkMaker.WaterLevel);
            drinkMaker.Refill();
        }
        
        [Fact(DisplayName = "Ordering a drink depletes correct amount of Milk")]

        public void OrderingADrinkDepletesCorrectAmountOfMilk() {

            var drinkMaker = new DrinkMaker {MilkLevel = 150};
            var coffeeMachine = new CoffeeMachine(new MakeTeaOneSugarUI(), drinkMaker);
            coffeeMachine.MakeSelection();
            
            Assert.Equal(140, coffeeMachine._drinkMaker.MilkLevel);
            drinkMaker.Refill();
        }

        [Fact(DisplayName = "Order Cannot be made if Insufficient water")]

        public void OrderCannotBeMadeIfInsufficientWater() {

            var drinkMaker = new DrinkMaker {WaterLevel = 0};
            var coffeeMachine = new CoffeeMachine(new MakeTeaOneSugarUI(), drinkMaker);

            Assert.Throws<InsufficientBeverageException>(coffeeMachine.TakeOrder);
        }
        
        [Fact(DisplayName = "Order Cannot be made if Insufficient milk")]

        public void OrderCannotBeMadeIfInsufficientMilk() {

            var drinkMaker = new DrinkMaker {MilkLevel = 0};
            var coffeeMachine = new CoffeeMachine(new MakeTeaOneSugarUI(), drinkMaker);

            Assert.Throws<InsufficientBeverageException>(coffeeMachine.TakeOrder);
        }

    }
}