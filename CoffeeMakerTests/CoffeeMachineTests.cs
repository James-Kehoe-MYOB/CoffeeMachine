using System;
using CoffeeMaker;
using CoffeeMaker.Business_Logic;
using Xunit;

namespace CoffeeMakerTests {
    public class CoffeeMachineTests {
        
        [Fact (DisplayName = "Menu is not empty")]
        public void MenuIsNotEmpty() {
           var cm = new CoffeeMachine(new ConsoleUI(), new DrinkMaker());
           
           Assert.NotEmpty(cm.Menu);
        }
        
    }
}