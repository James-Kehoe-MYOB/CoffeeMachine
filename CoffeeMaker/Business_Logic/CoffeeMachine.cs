using System;
using System.Collections.Generic;
using CoffeeMaker.Data_Access;

namespace CoffeeMaker.Business_Logic {
    public class CoffeeMachine {
        private const int DrinkCode = 0;
        private const int NumberOfComponents = 3;
        public List<MenuItem> Menu { get; private set; } = MenuHandler.FillMenu();
        public WaterQuantityChecker WaterChecker = new WaterQuantityChecker();
        public IDrinkMaker _drinkMaker { get; private set; }
        private readonly ReportHandler _reportHandler = new ReportHandler();
        private readonly IUserInterface _userIO;

        public CoffeeMachine(IUserInterface userIO, IDrinkMaker drinkMaker) {
            _drinkMaker = drinkMaker;
            _userIO = userIO;
        }

        public void MakeSelection() {
            try {
                var response = _userIO.GetChoice();
                switch (response) {
                    case Response.Report:
                        _reportHandler.GenerateReport();
                        break;
                    case Response.Order:
                        TakeOrder();
                        break;
                }
            }
            catch (Exception e) {
                _userIO.ShowMessage(e.Message);
                MakeSelection();
            }
            
        }

        private void TakeOrder() {
            var order = _userIO.GetInput();
            var orderComponents = new string[NumberOfComponents];
            string drinkCode;
            try {
                orderComponents = order.Split(':');
                drinkCode = orderComponents[DrinkCode];
                OrderValidator.ParseOrder(Menu, orderComponents);
            }
            catch (Exception e) {
                _userIO.ShowMessage($"Invalid Order - {e.Message}");
                return;
            }
            var menuItem = GetMenuItem(drinkCode);
            Transaction(order, menuItem);
        }

        private void Transaction(string order, MenuItem menuItem) {
            var orderCost = menuItem.Cost;
            _userIO.ShowMessage($"Your order will cost ${orderCost:0.00}");
            try {
                var payment = TakePayment();
                if (PaymentIsEnough(payment, menuItem.Cost)) {
                    var returnDrink = _drinkMaker.MakeDrink(order, Menu);
                    _userIO.GiveDrink(returnDrink);
                    _reportHandler.AddOrder(menuItem);
                }
                else {
                    _userIO.NotEnoughMoney(menuItem.Cost, payment);
                }
            }
            catch (Exception e) {
                _userIO.ShowMessage(e.Message);
                return;
            }
        }
        
        private double TakePayment() {
            _userIO.ShowMessage("How much will you pay? $");
            var money = _userIO.GetPayment();
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
        
        private MenuItem GetMenuItem(string drinkCode) {
            return Menu.Find(m => m.ID == drinkCode[0].ToString());
        }

        private bool CheckBeverage(MenuItem order, BeverageQuantityChecker checker) {
            return checker.isEmpty(order, _drinkMaker.WaterLevel);
        }
    }
}