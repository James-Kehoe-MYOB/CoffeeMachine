using System;
using System.Collections.Generic;

namespace CoffeeMaker.Business_Logic {
    public class DrinkMaker {
        private const int DrinkCode = 0;
        private const int Sugars = 1;
        private const int Stick = 2;
        public int numberOfDrinks;
        private int sugar;
        public bool stick;
        private string[] _orderComponents;
        private List<MenuItem> Menu;

        public DrinkMaker(List<MenuItem> menu) {
            Menu = menu;
        }

        public Drink MakeDrink(string order) {
            _orderComponents = SplitOrderComponents(order);
            numberOfDrinks = 1;
            AddSugar();
            AddStick();
            var returnDrink = MixIngredients();
            
            return returnDrink;
        }

        public bool CheckDrink(string order) {
            _orderComponents = SplitOrderComponents(order);
            try {
                OrderValidator.ParseOrder(Menu, _orderComponents);
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        private void AddSugar() {
            sugar = _orderComponents[Sugars] == "" ? 0 : int.Parse(_orderComponents[Sugars]);
        }

        private void AddStick() {
            if ((_orderComponents[Stick] == "0" || _orderComponents[Stick] == "") && sugar != 0) {
                stick = true;
            } else if (sugar == 0) {
                stick = false;
            }
        }

        private bool CheckIfHot() {
            var myItem = Menu.Find(m => m.ID == _orderComponents[DrinkCode][0].ToString());
            return _orderComponents[0].Length == 2 && myItem.CanBeExtraHot;
        }

        private Drink MixIngredients() {
            var myItem = Menu.Find(m => m.ID == _orderComponents[DrinkCode][0].ToString());
            var myType = myItem.Drink;
            var returnDrink = new Drink(myType, sugar, CheckIfHot());
            return returnDrink;
        }

        public string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != 3) {
                throw new InvalidOrderException(order);
            }
            return orderComponents;
        }

    }
}