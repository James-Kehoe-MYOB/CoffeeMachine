namespace CoffeeMaker.Business_Logic {
    public interface EmailNotifier {
        void notifyMissingDrink(string drink);
    }
}