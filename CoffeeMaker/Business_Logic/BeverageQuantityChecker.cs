namespace CoffeeMaker.Business_Logic {
    public interface BeverageQuantityChecker {
        public bool isEmpty(string drink);
    }
    
    public class WaterQuantityChecker : BeverageQuantityChecker {
        public bool isEmpty(string drink) {
            throw new System.NotImplementedException();
        }
    }
    
    public class MilkQuantityChecker : BeverageQuantityChecker {
        public bool isEmpty(string drink) {
            throw new System.NotImplementedException();
        }
    }
}