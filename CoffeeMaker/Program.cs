using System;

namespace CoffeeMaker {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            OrderTranslator ot = new OrderTranslator();
            Console.WriteLine(ot.Translate("T:1:0"));
            Console.WriteLine(ot.Translate("T:5:"));
            Console.WriteLine(ot.Translate("C:2:0"));
        }
    }
}