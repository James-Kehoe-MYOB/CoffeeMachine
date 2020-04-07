﻿using System.Collections.Generic;
using CoffeeMaker.Business_Logic;

namespace CoffeeMaker.UI_Layer {
    class Program {
        static void Main(string[] args) {
            var coffeeMachine = new CoffeeMachine(new ConsoleUI(), new DrinkMaker());
            coffeeMachine.MakeSelection();
        }
    }
}