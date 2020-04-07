using CoffeeMaker;
using CoffeeMaker.Business_Logic;
using CoffeeMaker.Business_Logic.Models;

namespace CoffeeMakerTests {
    public class MakeTeaOneSugarUI : IUserInterface {
        public void NotEnoughMoney(double cost, double payment) {
            throw new System.NotImplementedException();
        }

        public void ShowMessage(string message) {
            return;
        }

        public string GetInput() {
            return "T:1:0";
        }

        public Response GetOrder(string input) {
            throw new System.NotImplementedException();
        }

        public Response GetChoice() {
            return Response.Order;
        }

        public void GiveDrink(Drink myDrink) {
            return;
        }

        public string GetPayment() {
            return "1";
        }
    }
}