using UnityEngine;

namespace Currencies
{
    public abstract class Currency
    {
        public static bool operator ==(Currency left, Currency right) => Equals(left, right);
        
        public static bool operator !=(Currency left, Currency right) => !Equals(left, right);

        internal readonly int amount;

        protected float exchangeRate;
        
        protected Currency(int amount) => this.amount = amount;
        protected Currency(){}

        public abstract Currency Times(int factor);
        public abstract Currency Add(int value);

        public abstract Currency Add(Currency currency);

        public override string ToString() => $"{this.amount} {GetType().Name}";

        public static Currency ConvertTo<T>(Currency convertFrom) where T : Currency, new()
        {
            var currency = new T();
            var result= currency.Add(Mathf.RoundToInt(convertFrom.exchangeRate / currency.exchangeRate * convertFrom.amount));
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj?.GetType() != this.GetType())
                return false;
            var currency = obj as Currency; 
            return currency?.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode() => amount;

        public static Dollar Dollar(int amount) => new Dollar(amount);

        public static SEK SEK(int amount) => new SEK(amount);
    }
}
