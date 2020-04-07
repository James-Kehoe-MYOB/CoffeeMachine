using System.Collections.Generic;
using CoffeeMaker.Business_Logic.Models;

namespace CoffeeMaker.Business_Logic {
    public interface IDrinkMaker {
        
        int WaterLevel { get; set; }
        int MilkLevel { get; set; }
        Drink MakeDrink(string order, List<MenuItem> menu);
        void Refill();
    }
}