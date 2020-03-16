using System;

namespace CoffeeMaker {
    class Program {
        static void Main(string[] args) {
            var drinkMaker = new DrinkMaker();
            Console.WriteLine("Input an Order: ");
            var orderCode = Console.ReadLine();
            try {
                var order = drinkMaker.MakeDrink(orderCode);
                Console.WriteLine($"You have selected {order.type.ToString().ToLower()}, with {order.numberOfSugars} sugar/s\nThis will cost {order.cost} euros");
            }
            catch (Exception e) {
                Console.WriteLine($"M:Invalid Order - {e.Message}");
            }
        }
    }
}