namespace Currencies
{
    public abstract class Currency
    {
        public static bool operator ==(Currency left, Currency right) => Equals(left, right);
        
        public static bool operator !=(Currency left, Currency right) => !Equals(left, right);
        
        protected readonly int amount;
        
        protected Currency(int amount) => this.amount = amount;

        public abstract Currency Times(int factor);

        public override string ToString() => $"{this.amount} {GetType().Name}";

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var currency = obj as Currency; 
            return currency.amount == this.amount;
        }

        public override int GetHashCode() => amount;

        public static Dollar Dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static SEK SEK(int amount)
        {
            return new SEK(amount);
        }
    }
}
