using System.Runtime.CompilerServices;

namespace CoffeeMaker {
    public abstract class Drink {
        public enum DrinkType {
            Tea,
            Chocolate,
            Coffee
        }
        public DrinkType type { get; protected set; }
        public int numberOfSugars { get; protected set; }
        public bool hasStick { get; protected set; }
        public double cost { get; protected set; }
    }

    public class Tea : Drink {
        
        public Tea(int numberOfSugars = 0) {
            type = DrinkType.Tea;
            cost = 0.4;
            this.numberOfSugars = numberOfSugars;
            hasStick = numberOfSugars > 0;
        }
    }
    
    public class Chocolate : Drink {
        
        public Chocolate(int numberOfSugars = 0) {
            type = DrinkType.Chocolate;
            cost = 0.5;
            this.numberOfSugars = numberOfSugars;
            hasStick = numberOfSugars > 0;
        }
    }
    
    public class Coffee : Drink {
        public Coffee(int numberOfSugars = 0) {
            type = DrinkType.Coffee;
            cost = 0.6;
            this.numberOfSugars = numberOfSugars;
            hasStick = numberOfSugars > 0;
        }
    }
}