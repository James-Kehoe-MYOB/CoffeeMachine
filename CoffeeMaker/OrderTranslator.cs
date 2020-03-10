using System;
using System.Text.RegularExpressions;

namespace CoffeeMaker {
    public class OrderTranslator {
        private string drink;
        private string sugar;
        private string stick;

        public OrderTranslator() {
            
        }

        public string Translate(string order) {
            if (Validate(order)) {
                var split = order.Split(':');

                drink = split[0] switch {
                    "T" => "tea",
                    "H" => "chocolate",
                    "C" => "coffee",
                    _ => drink
                };

                if (split[1] == "") {
                    sugar = "no";
                }
                else {
                    sugar = split[1];
                }

                if (split[2] == "0" && sugar != "no") {
                    stick = "and a stick";
                } else if (sugar == "no") {
                    stick = "- and therefore no stick";
                }

                var returnMessage = $"Drink maker makes 1 {drink} with {sugar} sugar/s {stick}";
                
                return returnMessage;
            }

            return "Invalid Order";
        }

        private bool Validate(string order) {
            string expression = @"((T|H|C):\d?:0?)";
            return Regex.IsMatch(order, expression);
        }
        
    }
}