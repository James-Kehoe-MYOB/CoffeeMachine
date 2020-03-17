using System;

namespace CoffeeMaker {
    
    public class InvalidOrderException : Exception {
        public InvalidOrderException(string order) : base(string.Format($"'{order}' does not fit an order format")){
        }
    }
    class InvalidDrinkException : Exception {
        public InvalidDrinkException(string drink) : base(string.Format($"{drink} is not a valid drink DrinkType")) {
        }
    }
    
    class InvalidSugarException : Exception {
        public InvalidSugarException(string sugar) : base(string.Format($"Invalid sugar identifier '{sugar}'")){
        }
    }
    
    class InvalidStickException : Exception {
        public InvalidStickException(string stick) : base(string.Format($"Invalid stick identifier '{stick}'")){
        }
    }
    
    public class InvalidPaymentException : Exception {
        public InvalidPaymentException(string payment) : base(string.Format($"Cannot accept '{payment}' as payment")){
        }
    }
}