using System;
using System.Text.RegularExpressions;

namespace CoffeeMaker {
    public class OrderTranslator {
    
        private const int Drink = 0;
        private const int Sugars = 1;
        private const int Message = 1;
        private const int WithStick = 2;
        public int NumberOfDrinks;
        private string drink;
        private string sugar;
        public string stick;

        public OrderTranslator() {
            
        }

        public string Translate(string order) {
            if (Validate(order)) {
                var orderElements = order.Split(':');
                if (orderElements[Drink] == "M") { 
                    return orderElements[Message];
                }
                
                NumberOfDrinks = 1;
                drink = orderElements[Drink] switch {
                    "T" => "tea",
                    "H" => "chocolate",
                    "C" => "coffee",
                    _ => null
                };

                sugar = orderElements[Sugars] == "" ? "no" : orderElements[1];

                if (orderElements[WithStick] == "0" && sugar != "no") {
                    stick = "and a stick";
                } else if (sugar == "no") {
                    stick = "- and therefore no stick";
                }
                
                var returnMessage = $"Drink maker makes {NumberOfDrinks} {drink} with {sugar} sugar/s {stick}";
                
                return returnMessage;
            }

            return "Invalid Order";
        }

        private static bool Validate(string order) {
            const string expression = @"((T|H|C):\d?:0?)|(M):.*";
            return Regex.IsMatch(order, expression);
        }
    }
}