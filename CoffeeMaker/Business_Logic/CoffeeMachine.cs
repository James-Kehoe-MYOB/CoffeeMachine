using System;
using System.Collections.Generic;
using CoffeeMaker.Data_Access;

namespace CoffeeMaker.Business_Logic {
    public class CoffeeMachine {
        private const int DrinkCode = 0;
        private const int NumberOfComponents = 3;
        public List<MenuItem> Menu { get; private set; } = MenuHandler.FillMenu();
        private static DrinkMaker _drinkMaker;
        private ReportHandler _reportHandler = new ReportHandler();

        public CoffeeMachine() {
            _drinkMaker = new DrinkMaker(Menu);
        }

        public void TakeOrder() {
            Console.WriteLine("Input an Order: ");
            var order = Console.ReadLine();
            if (order.ToUpper() == "REPORT") {
                _reportHandler.GenerateReport();
                return;
            }
            var orderComponents = new string[3];
            string drinkCode;
            try {
                orderComponents = SplitOrderComponents(order);
                drinkCode = orderComponents[DrinkCode];
                OrderValidator.ParseOrder(Menu, orderComponents);
            }
            catch (Exception e) {
                Console.WriteLine($"Invalid Order - {e.Message}");
                return;
            }
            
            var menuItem = GetMenuItem(drinkCode);
            var orderCost = menuItem.Cost;
            Console.WriteLine($"Your order will cost ${orderCost:0.00}");
            try {
                var payment = TakePayment();
                if (PaymentIsEnough(payment, menuItem.Cost)) {
                    var returnDrink = _drinkMaker.MakeDrink(orderComponents);
                    Console.WriteLine(GenerateOrderMessage(returnDrink));
                    _reportHandler.AddOrder(menuItem);
                }
                else {
                    Console.WriteLine($"Not Enough Money! you need ${menuItem.Cost - payment:0.00} more");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private double TakePayment() {
            Console.Write("How much will you pay? $");
            var money = Console.ReadLine();
            if (double.TryParse(money, out var payment)) {
                return payment;
            }
            else {
                throw new InvalidPaymentException(money);
            }
        }

        private bool PaymentIsEnough(double payment, double cost) {
            return payment >= cost;
        }

        private static string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != NumberOfComponents) {
                throw new InvalidOrderException(order);
            }
            return orderComponents;
        }

        private MenuItem GetMenuItem(string drinkCode) {
            return Menu.Find(m => m.ID == drinkCode[0].ToString());
        }

        private static string GenerateOrderMessage(Drink myDrink) {
            const string thankYou = "Thank You! Here is your ";
            var extraHot = "";
            if (myDrink.isExtraHot) {
                extraHot = "extra hot ";
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
            return $"{thankYou}{extraHot}{drink}{sugar}{stick}";
        }
    }
}