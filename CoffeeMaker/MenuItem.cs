using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CoffeeMaker {
    public class MenuItem {
        //private string _path;
        public string ID { get; private set; }
        public Drink.DrinkType Drink { get; private set; }
        public double Cost { get; private set; }

        public MenuItem(string ID, Drink.DrinkType Drink, double Cost) {
            this.ID = ID;
            this.Drink = Drink;
            this.Cost = Cost;
        }
    }
}