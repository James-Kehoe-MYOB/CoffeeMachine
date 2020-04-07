using System;
using System.Collections.Generic;
using CoffeeMaker;
using CoffeeMaker.Business_Logic;
using CoffeeMaker.Business_Logic.Exceptions;
using CoffeeMaker.Business_Logic.Models;

namespace CoffeeMakerTests {
    public class FakeDrinkMaker : IDrinkMaker {

        public Drink Translate(string order) {
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

        public int WaterLevel { get; set; }
        public int MilkLevel { get; set; }
        public Drink MakeDrink(string order, List<MenuItem> menu) {
            throw new NotImplementedException();
        }

        public void Refill() {
            throw new NotImplementedException();
        }
    }

    
}
