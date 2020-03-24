using System;

namespace CoffeeMaker {
    class Program {
        static void Main(string[] args) {
            var coffeeMachine = new CoffeeMachine();


            Console.WriteLine("Input an Order: ");
            var orderCode = Console.ReadLine();
            
            try {
                var cost = coffeeMachine.TakeOrder(orderCode);
                Console.WriteLine($"Your order will cost ${cost:0.00}");
            }
            catch (Exception e) {
                Console.WriteLine($"Invalid Order - {e.Message}");
                return;
            }
            
            Console.Write("How much will you pay? $");
            try {
                coffeeMachine.TakePayment(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}