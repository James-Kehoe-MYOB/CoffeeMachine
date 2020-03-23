using System.Runtime.CompilerServices;

namespace CoffeeMaker {
    public class Drink {
        
        public DrinkType type { get; protected set; }
        public int numberOfSugars { get; protected set; }
        public bool hasStick { get; protected set; }
        public bool isExtraHot { get; protected set; }

        public Drink(DrinkType type, int numberOfSugars, bool isExtraHot) {
            this.type = type;
            this.numberOfSugars = numberOfSugars;
            this.isExtraHot = isExtraHot;
            hasStick = numberOfSugars > 0;
        }
    }
}