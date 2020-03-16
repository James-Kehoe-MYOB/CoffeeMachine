using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CoffeeMaker {
    public class MenuItem {
        //private string _path;
        public char ID { get; set; }
        public Drink.DrinkType type { get; set; }
        public double cost { get; set; }

        public MenuItem(char ID, Drink.DrinkType type, int cost) {
            this.ID = ID;
            this.type = type;
            this.cost = cost;
        }
    }
}