using System.Collections.Generic;
using CoffeeMaker;

namespace CoffeeMakerTests {
    public class MockMenu {
        public static List<MenuItem> Menu = new List<MenuItem>() {
            new MenuItem("T", DrinkType.Tea, 0.4, true),
            new MenuItem("H", DrinkType.Chocolate, 0.5, true),
            new MenuItem("C", DrinkType.Coffee, 0.6, true),
            new MenuItem("O", DrinkType.OrangeJuice, 0.6, false)
        };
    }
}