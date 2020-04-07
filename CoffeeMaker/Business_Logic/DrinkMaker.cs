using System.Collections.Generic;
using CoffeeMaker.Business_Logic.Exceptions;
using CoffeeMaker.Business_Logic.Models;
using CoffeeMaker.Data_Access;

namespace CoffeeMaker.Business_Logic {
    public class DrinkMaker : IDrinkMaker {
        private const int DrinkCode = 0;
        private const int Sugars = 1;
        private const int Stick = 2;
        
        private static readonly BeverageQuantityUpdater Updater = new BeverageQuantityUpdater();
        private MenuItem _menuItem;
        private int _sugar;
        private bool _stick;
        private string[] _orderComponents;
        public int WaterLevel { get; set; } = Updater.ReadLevels()[0].Level;
        public int MilkLevel { get; set; } = Updater.ReadLevels()[1].Level;
        
        
        public Drink MakeDrink(string order, List<MenuItem> menu) {
            _orderComponents = SplitOrderComponents(order);
            _menuItem = menu.Find(m => m.ID == _orderComponents[DrinkCode][0].ToString());
            AddSugar();
            AddStick();
            WaterLevel -= _menuItem.WaterUsage;
            MilkLevel -= _menuItem.MilkUsage;
            Updater.WriteLevels(WaterLevel, MilkLevel);
            var returnDrink = MixIngredients(menu);

            return returnDrink;
        }

        private void AddSugar() {
            _sugar = _orderComponents[Sugars] == "" ? 0 : int.Parse(_orderComponents[Sugars]);
        }

        private void AddStick() {
            if ((_orderComponents[Stick] == "0" || _orderComponents[Stick] == "") && _sugar != 0) {
                _stick = true;
            } else if (_sugar == 0) {
                _stick = false;
            }
        }

        private bool CheckIfHot(List<MenuItem> menu) {
            var myItem = menu.Find(m => m.ID == _orderComponents[DrinkCode][0].ToString());
            return _orderComponents[0].Length == 2 && myItem.CanBeExtraHot;
        }

        private Drink MixIngredients(List<MenuItem> menu) {
            var myType = _menuItem.Drink;
            var returnDrink = new Drink(myType, _sugar, CheckIfHot(menu));
            return returnDrink;
        }

        private string[] SplitOrderComponents(string order) {
            var orderComponents = order.Split(':');
            if (orderComponents.Length != 3) {
                throw new InvalidOrderException(order);
            }
            return orderComponents;
        }

        public void Refill() {
            Updater.WriteLevels(500, 100);
        }

        public bool HasStick() {
            return _stick;
        }

    }
}