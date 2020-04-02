using System;
using System.Collections.Generic;
using CoffeeMaker;
using CoffeeMaker.Business_Logic;

namespace CoffeeMakerTests {
    public class FakeDrinkMaker : DrinkMaker {

        public Drink Translate(string order) {
            numberOfDrinks = 1;
            string[] orderComponents;

            try {
                orderComponents = SplitOrderComponents(order);
            }
            catch (InvalidOrderException e) {
                throw new InvalidOrderException(order);
                return null;
            }

            return null;
        }

        private string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != 3) {
                throw new InvalidOrderException(order);
            }
            return orderComponents;
        }

        public FakeDrinkMaker() {
        }
    }

    
}
