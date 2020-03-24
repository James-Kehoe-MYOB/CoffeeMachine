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
        public List<MenuItem> Menu = FillMenu();
        private static DrinkMaker _drinkMaker;
        private double _cost;
        private string[] _currentOrderComponents;

        private string myOrder;

        public CoffeeMachine() {
            _drinkMaker = new DrinkMaker(Menu);
        }

        public void TakeMyOrder() {
            Console.WriteLine("Input an Order: ");
            myOrder = Console.ReadLine();
            _currentOrderComponents = SplitOrderComponents(myOrder);
            if (MenuContainsDrink()) {
                Console.WriteLine("Thank you!");
            }
        }

        private bool MenuContainsDrink() {
            var id = _currentOrderComponents[DrinkCode];
            if (Menu.Exists(m => m.ID == id[0].ToString())) {
                var myDrink = Menu.Find(m => m.ID == id[0].ToString());
                if (id.Length == 2) {
                    if (!myDrink.CanBeExtraHot) return false;
                    if (id[1] == 'h') {
                        return true;
                    }
                } else if (id.Length == 1 && id[0].ToString() == myDrink.ID) {
                    return true;
                }
            }
            else {
                return false;
            }
            return false;
        }

        public double TakeOrder(string order) {
            _currentOrderComponents = SplitOrderComponents(order);
            _drinkMaker.ParseOrder(_currentOrderComponents);
            var id = _currentOrderComponents[DrinkCode];
            _cost = Menu.Find(m => m.ID == id[0].ToString()).Cost;
            

            return _cost;
        }

        public void TakePayment(string money) {
            if (double.TryParse(money, out var payment)) {
                if (payment >= _cost) {
                    var returnDrink = _drinkMaker.MakeDrink(_currentOrderComponents);
                    Console.WriteLine(GenerateOrderMessage(returnDrink));
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
            List<MenuItem> menu;
            using (var reader = new StreamReader(_menuSource)) {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                menu = csv.GetRecords<MenuItem>().ToList();
            }
            return menu;
        }

        private string GenerateOrderMessage(Drink myDrink) {
            var thankyou = "Thank You! Here is your ";
            
            var extrahot = "";
            if (myDrink.isExtraHot) {
                extrahot = "extra hot ";
            }

            var drink = myDrink.type.ToString().ToLower();
            if (myDrink.type == DrinkType.OrangeJuice) {
                drink = "orange juice";
            }

            var sugar = "";
            if (myDrink.numberOfSugars == 1) {
                sugar = $" with {myDrink.numberOfSugars} sugar";
            }
            else if (myDrink.numberOfSugars > 1) {
                sugar = $" with {myDrink.numberOfSugars} sugars";
            }

            var stick = "!";
            if (myDrink.hasStick) {
                stick = " and a stick!";
            }

            return thankyou+extrahot+drink+sugar+stick;
        }
    }
}