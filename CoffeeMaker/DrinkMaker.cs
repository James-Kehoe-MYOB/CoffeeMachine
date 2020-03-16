using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace CoffeeMaker {
    public class DrinkMaker {
        private const string Tea = "T";
        private const string Chocolate = "H";
        private const string Coffee = "C";
        private const int Drink = 0;
        private const int Sugars = 1;
        private const int WithStick = 2;
        public int numberOfDrinks;
        private int sugar;
        public bool stick;
        private string[] _orderComponents;

        public Drink MakeDrink(string order) {
            numberOfDrinks = 1;
            _orderComponents = SplitOrderComponents(order);
            AddSugar();
            AddStick();
            return CreateDrink();
        }

        private string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != 3) {
                throw new InvalidOrderException(order);
            }

            return orderComponents;
        }

        private void AddSugar() {
            if (_orderComponents[Sugars] == "") {
                sugar = 0;
            } else {
                var isInt = int.TryParse(_orderComponents[Sugars], out var i);
                if (!isInt || i < 0) {
                    throw new InvalidSugarException(_orderComponents[Sugars]);
                }
                sugar = int.Parse(_orderComponents[Sugars]);
            }
        }

        private void AddStick() {
            if ((_orderComponents[WithStick] == "0" || _orderComponents[WithStick] == "") && sugar != 0) {
                stick = true;
            } else if (sugar == 0) {
                stick = false;
            }
            else {
                throw new InvalidStickException(_orderComponents[WithStick]);
            }
        }

        private Drink CreateDrink() {
            var returnDrink = _orderComponents[Drink] switch {
                Tea => new Drink(CoffeeMaker.Drink.DrinkType.Tea, sugar, 0.4),
                Chocolate => new Drink(CoffeeMaker.Drink.DrinkType.Chocolate, sugar, 0.5),
                Coffee => new Drink(CoffeeMaker.Drink.DrinkType.Coffee, sugar, 0.6),
                _ => throw new InvalidDrinkException(_orderComponents[Drink])
            };
            return returnDrink;
        }
    }
}