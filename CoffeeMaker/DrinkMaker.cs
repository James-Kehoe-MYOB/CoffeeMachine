using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace CoffeeMaker {
    public class DrinkMaker {
        private const int DrinkCode = 0;
        private const int Sugars = 1;
        private const int Stick = 2;
        public int numberOfDrinks;
        private int sugar;
        public bool stick;
        private string[] _orderComponents;

        public Drink MakeDrink(string[] orderComponents) {
            numberOfDrinks = 1;
            _orderComponents = orderComponents;
            AddSugar();
            AddStick();
            var returnDrink = MixIngredients();
            
            return returnDrink;
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

        private Drink MixIngredients() {
            var myType = CoffeeMachine.Menu.Find(m => m.ID == _orderComponents[DrinkCode]).Drink;
            var returnDrink = new Drink(myType, sugar, false);
            return returnDrink;
        }
        
        public void ParseOrder(string[] orderComponents) {

            if (!CoffeeMachine.Menu.Exists(m => m.ID == orderComponents[DrinkCode])) {
                throw new InvalidDrinkException(orderComponents[DrinkCode]);
            }
            
            if (orderComponents[Sugars] != "") {
                if (!int.TryParse(orderComponents[Sugars], out var sugars)) {
                    throw new InvalidSugarException(orderComponents[Sugars]);
                }
            }
            if (orderComponents[Stick] != "0" && orderComponents[Stick] != "") {
                throw new InvalidStickException(orderComponents[Stick]);
            }
        }
    }
}