using System.Collections.Generic;
using CoffeeMaker.Business_Logic.Exceptions;
using CoffeeMaker.Business_Logic.Models;

namespace CoffeeMaker.Business_Logic {
    public static class OrderValidator {
        const int DrinkCode = 0;
        const int Sugars = 1;
        const int Stick = 2;

        public static void ParseOrder(List<MenuItem> Menu, string[] orderComponents) {
            
            if (!MenuContainsDrink(Menu, orderComponents[DrinkCode])) {
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
        
        private static bool MenuContainsDrink(List<MenuItem> Menu, string drinkCode) {
            if (Menu.Exists(m => m.ID == drinkCode[0].ToString())) {
                var myDrink = Menu.Find(m => m.ID == drinkCode[0].ToString());
                switch (drinkCode.Length) {
                    case 2 when !myDrink.CanBeExtraHot:
                        return false;
                    case 2 when drinkCode[1] == 'h':
                    case 1 when drinkCode[0].ToString() == myDrink.ID:
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