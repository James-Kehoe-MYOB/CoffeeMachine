using System.Runtime.CompilerServices;

namespace CoffeeMaker {
    public class Drink {
        public enum DrinkType {
            Tea,
            Chocolate,
            Coffee
        }
        public DrinkType type { get; protected set; }
        public int numberOfSugars { get; protected set; }
        public bool hasStick { get; protected set; }
        public double cost { get; protected set; }

        public Drink(DrinkType type, int numberOfSugars, double cost) {
            this.type = type;
            this.numberOfSugars = numberOfSugars;
            this.cost = cost;
            hasStick = numberOfSugars > 0;
        }
    }
}