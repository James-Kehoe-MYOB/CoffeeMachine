using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace CoffeeMaker {
    public class CoffeeMachine {
        private const int DrinkCode = 0;
        private const int NumberOfComponents = 3;
        private static string _menuSource = "../../../Menu.csv";
        public static List<MenuItem> Menu = FillMenu();
        private static DrinkMaker _drinkMaker = new DrinkMaker();
        

        private double _cost;
        private string[] _currentOrderComponents;

        public double TakeOrder(string order) {
            _currentOrderComponents = SplitOrderComponents(order);
            _drinkMaker.ParseOrder(_currentOrderComponents);
            var id = _currentOrderComponents[DrinkCode];
            _cost = Menu.Find(m => m.ID == id).Cost;
            

            return _cost;
        }

        public void TakePayment(string money) {
            if (double.TryParse(money, out var payment)) {
                if (payment >= _cost) {
                    var returnDrink = _drinkMaker.MakeDrink(_currentOrderComponents);
                    Console.WriteLine($"Thank You! Here is your {returnDrink.type} with {returnDrink.numberOfSugars} sugar/s");
                }
                else {
                    Console.WriteLine($"Not Enough Money! you need ${_cost - payment:0.00} more");
                }
            }
            else {
                throw new InvalidPaymentException(money);
            }
        }

        private string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != NumberOfComponents) {
                throw new InvalidOrderException(order);
            }
            return orderComponents;
        }

        private static List<MenuItem> FillMenu() {
            using (var reader = new StreamReader(_menuSource)) {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                Menu = csv.GetRecords<MenuItem>().ToList();
            }
            return Menu;
        }
    }
}