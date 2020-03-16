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

        public Drink MakeDrink(string order) {
            numberOfDrinks = 1;
            var orderComponents = SplitOrderComponents(order);
            AddSugar(orderComponents);
            AddStick(orderComponents);
            return CreateDrink(orderComponents);
        }

        private string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != 3) {
                throw new InvalidOrderException(order);
            }

            return orderComponents;
        }

        private void AddSugar(string[] orderComponents) {
            if (orderComponents[Sugars] == "") {
                sugar = 0;
            } else {
                var isInt = int.TryParse(orderComponents[Sugars], out var i);
                if (!isInt) {
                    throw new InvalidSugarException(orderComponents[Sugars]);
                }
                sugar = int.Parse(orderComponents[Sugars]);
            }
        }

        private void AddStick(string[] orderComponents) {
            if ((orderComponents[WithStick] == "0" || orderComponents[WithStick] == "") && sugar != 0) {
                stick = true;
            } else if (sugar == 0) {
                stick = false;
            }
            else {
                throw new InvalidStickException(orderComponents[WithStick]);
            }
        }

        private Drink CreateDrink(string[] orderComponents) {
            Drink returnDrink = orderComponents[Drink] switch {
                Tea => new Tea(sugar),
                Chocolate => new Chocolate(sugar),
                Coffee => new Coffee(sugar),
                _ => throw new InvalidDrinkException(orderComponents[Drink])
            };
            return returnDrink;
        }
    }
}