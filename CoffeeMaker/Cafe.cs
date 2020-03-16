using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace CoffeeMaker {
    public class Cafe {
        private static string _menuSource = "../../MenuItem.csv";
        private static List<MenuItem> _menu;
        private static DrinkMaker _drinkMaker = new DrinkMaker();

        public Cafe() {
            FillMenu();
        }

        public double TakeOrder(string order) {
            double cost = 0;
            var orderComponents = SplitOrderComponents(order);
            if (orderComponents[0] == "T") {
                cost = 0.4;
            }
            return cost;
        }
        
        private string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != 3) {
                throw new InvalidOrderException(order);
            }

            return orderComponents;
        }

        private List<MenuItem> FillMenu() {
            using (var reader = new StreamReader(_menuSource)) {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                _menu = csv.GetRecords<MenuItem>().ToList();
            }
            return _menu;
        }
    }
}