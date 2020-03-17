using System;

namespace CoffeeMaker {
    class Program {
        static void Main(string[] args) {
            var cafe = new Cafe();
            var drinkMaker = new DrinkMaker();
            
            Console.WriteLine("Input an Order: ");
            var orderCode = Console.ReadLine();

            try {
                var cost = cafe.TakeOrder(orderCode);
                Console.WriteLine($"Your order will cost {cost}");
            }
            catch (Exception e) {
                Console.WriteLine($"Invalid Order - {e.Message}");
                return;
            }

            Console.Write("How much will you pay? ");
            try {
                cafe.TakePayment(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            

            // try {
            //     var order = drinkMaker.MakeDrink(orderCode);
            //     Console.WriteLine($"You have selected {order.type.ToString().ToLower()}, with {order.numberOfSugars} sugar/s\nThis will cost {order.cost} euros");
            // }
            // catch (Exception e) {
            //     Console.WriteLine($"M:Invalid Order - {e.Message}");
            // }
        }
    }
}