using System.Collections.Generic;
using CoffeeMaker.Business_Logic;
using CoffeeMaker.Data_Access;

namespace CoffeeMaker.UI_Layer {
    class Program {
        static void Main(string[] args) {
            var menu = MenuHandler.FillMenu();
            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), new DrinkMaker(menu));
            coffeeMachine.MakeSelection();
        }
    }
}