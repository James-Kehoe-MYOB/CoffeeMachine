using System.Runtime.CompilerServices;

namespace CoffeeMaker {
    public class Drink {
        
        public DrinkType type { get; protected set; }
        public int numberOfSugars { get; protected set; }
        public bool hasStick { get; protected set; }

        public Drink(DrinkType type, int numberOfSugars, double cost) {
            this.type = type;
            this.numberOfSugars = numberOfSugars;
            hasStick = numberOfSugars > 0;
        }
    }
}