using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CoffeeMaker {
    public class MenuItem {
        public string ID { get; private set; }
        public DrinkType Drink { get; private set; }
        public double Cost { get; private set; }
        public bool CanBeExtraHot { get; private set; }
        public int WaterUsage { get; private set; }
        public int MilkUsage { get; private set; }

        public MenuItem(string ID, DrinkType Drink, double Cost, bool CanBeExtraHot, int WaterUsage, int MilkUsage) {
            this.ID = ID;
            this.Drink = Drink;
            this.Cost = Cost;
            this.CanBeExtraHot = CanBeExtraHot;
            this.WaterUsage = WaterUsage;
            this.MilkUsage = MilkUsage;

        }
    }
}