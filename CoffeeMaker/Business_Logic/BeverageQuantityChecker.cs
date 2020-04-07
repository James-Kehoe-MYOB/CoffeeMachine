using CoffeeMaker.Business_Logic.Models;

namespace CoffeeMaker.Business_Logic {
    public interface BeverageQuantityChecker {
        public bool isEmpty(MenuItem drink, int beverageLevel);
    }
    
    public class WaterQuantityChecker : BeverageQuantityChecker {

        public bool isEmpty(MenuItem drink, int beverageLevel) {
            return drink.WaterUsage > beverageLevel;
        }
    }
    
    public class MilkQuantityChecker : BeverageQuantityChecker {
        public bool isEmpty(MenuItem drink, int beverageLevel) {
            return drink.MilkUsage > beverageLevel;
        }
    }
}