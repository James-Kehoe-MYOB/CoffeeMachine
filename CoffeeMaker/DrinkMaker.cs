using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
        private List<MenuItem> Menu;

        public DrinkMaker(List<MenuItem> Menu) {
            this.Menu = Menu;
        }

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
        
        public void ParseOrder(string[] orderComponents) {

            if (!MenuContainsDrink(orderComponents[DrinkCode])) {
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
        
        private bool MenuContainsDrink(string drinkCode) {
            if (Menu.Exists(m => m.ID == drinkCode[0].ToString())) {
                var myDrink = Menu.Find(m => m.ID == drinkCode[0].ToString());
                if (drinkCode.Length == 2) {
                    if (!myDrink.CanBeExtraHot) return false;
                    if (drinkCode[1] == 'h') {
                        return true;
                    }
                } else if (drinkCode.Length == 1 && drinkCode[0].ToString() == myDrink.ID) {
                    return true;
                }
            }
            else {
                return false;
            }
            return false;
        }
    }
}