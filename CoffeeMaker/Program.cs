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
        }
    }
}