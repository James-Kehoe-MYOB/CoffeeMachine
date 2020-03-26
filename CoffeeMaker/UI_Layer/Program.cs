using CoffeeMaker.Business_Logic;

namespace CoffeeMaker.UI_Layer {
    class Program {
        static void Main(string[] args) {
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.TakeOrder();
        }
    }
}