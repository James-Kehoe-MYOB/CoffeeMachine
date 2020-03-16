using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CoffeeMaker {
    public class Menu {
        public Dictionary<Drink, double> drinksList;
        private string _path;

        public Menu(string path) {
            _path = path;
        }
    }
}