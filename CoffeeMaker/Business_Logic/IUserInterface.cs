using System;

namespace CoffeeMaker.Business_Logic {

    public enum Response {
        Report,
        Order
    }
    public interface IUserInterface {
        public void NotEnoughMoney(double cost, double payment);

        public void ShowMessage(string message);

        public string GetInput();

        public Response GetOrder(string input);

        public Response GetChoice();

        public void GiveDrink(Drink myDrink) {
        }
        
    }

    public class ConsoleUI : IUserInterface {
        public void NotEnoughMoney(double cost, double payment) {
            Console.WriteLine($"Not Enough Money! you need ${cost - payment:0.00} more");
        }

        public void ShowMessage(string message) {
            Console.WriteLine(message);
        }

        public string GetInput() {
            Console.Write("Please enter an order code: ");
            return Console.ReadLine();
        }

        public Response GetOrder(string input) {
            if (input.ToUpper() == "REPORT") {
                return Response.Report;
            } if (input.Split(':').Length == 3) {
                return Response.Order;
            }
            else {
                throw new InvalidOrderException(input);
            }
        }

        public Response GetChoice() {
            Console.WriteLine("What would you like to do?\n" +
                              "1. Print Daily Report\n" +
                              "2. Make Order");

            var response = Console.ReadLine();

            return response switch {
                "1" => Response.Report,
                "2" => Response.Order,
                _ => throw new InvalidOrderException(response)
            };
        }

        public void GiveDrink(Drink myDrink) {
            const string thankYou = "Thank You! Here is your ";
            var extraHot = "";
            if (myDrink.isExtraHot) {
                extraHot = "extra hot ";
            }
            var drink = myDrink.type.ToString().ToLower();
            if (myDrink.type == DrinkType.OrangeJuice) {
                drink = "orange juice";
            }
            var sugar = "";
            if (myDrink.numberOfSugars == 1) {
                sugar = $" with {myDrink.numberOfSugars} sugar";
            }
            else if (myDrink.numberOfSugars > 1) {
                sugar = $" with {myDrink.numberOfSugars} sugars";
            }
            var stick = "!";
            if (myDrink.hasStick) {
                stick = " and a stick!";
            }
            Console.WriteLine($"{thankYou}{extraHot}{drink}{sugar}{stick}");
        }
        
    }
}