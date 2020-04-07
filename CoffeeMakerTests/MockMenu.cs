using System.Collections.Generic;
using CoffeeMaker;
using CoffeeMaker.Business_Logic.Enums;
using CoffeeMaker.Business_Logic.Models;

namespace CoffeeMakerTests {
    public class MockMenu {
        public static List<MenuItem> Menu = new List<MenuItem>() {
            new MenuItem("T", DrinkType.Tea, 0.4, true, 100, 10),
            new MenuItem("H", DrinkType.Chocolate, 0.5, true, 100, 25),
            new MenuItem("C", DrinkType.Coffee, 0.6, true, 100, 15),
            new MenuItem("O", DrinkType.OrangeJuice, 0.6, false, 0, 0)
        };
    }
}