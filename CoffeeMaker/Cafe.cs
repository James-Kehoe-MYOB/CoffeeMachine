using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace CoffeeMaker {
    public class Cafe {
        private const int DrinkCode = 0;
        private const int Sugars = 1;
        private const int Stick = 2;
        
        private static string _menuSource = "../../../Menu.csv";
        private static List<MenuItem> Menu;
        private static DrinkMaker _drinkMaker = new DrinkMaker();
        
        private double _cost;
        private string[] currentOrderComponents;

        public Cafe() {
            Menu = FillMenu();
        }

        public double TakeOrder(string order) {
            currentOrderComponents = SplitOrderComponents(order);
            ParseOrder(currentOrderComponents);
            var id = currentOrderComponents[DrinkCode];
            _cost = Menu.Find(m => m.ID == id).Cost;

            return _cost;
        }

        public void TakePayment(string money) {
            if (double.TryParse(money, out var payment)) {
                var drink = _drinkMaker.MakeDrink(currentOrderComponents);
                Console.WriteLine(payment >= _cost ? $"Thank You! Here is your {drink.type} with {drink.numberOfSugars} sugar/s"
                    : "Not Enough Money!");
            }
            else {
                throw new InvalidPaymentException(money);
            }
        }

        private string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != 3) {
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

        private static void ParseOrder(string[] orderComponents) {

            if (!Menu.Exists(m => m.ID == orderComponents[DrinkCode])) {
                throw new InvalidDrinkException(orderComponents[DrinkCode]);
            }
            if (!int.TryParse(orderComponents[Sugars], out int sugars)) {
                throw new InvalidSugarException(orderComponents[Sugars]);
            }
            if (orderComponents[Stick] != "0" && orderComponents[Stick] != "") {
                throw new InvalidStickException(orderComponents[Stick]);
            }

        }
    }
}