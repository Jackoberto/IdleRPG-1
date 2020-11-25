/*namespace Currencies
{
    public class Dollar : Currency
    {
        internal Dollar(int amount) : base(amount)
        {
            exchangeRate = 1.0f;
        }

        public Dollar()
        {
            exchangeRate = 1.0f;
        }
        public override Currency Times(int factor) => new Dollar(this.amount * factor);
        public override Currency Add(int value) => new Dollar(this.amount + value);
        public override Currency Add(Currency currency)
        {
            Currency newCurrency = new Dollar();
            if (!(currency is Dollar))
            {
                newCurrency = ConvertTo<Dollar>(currency);
            }
            newCurrency = newCurrency.Add(this.amount);
            return newCurrency;
        }

        public override bool Equals(object obj)
        {
            if (obj is Currency otherCurrency && otherCurrency.GetType() != this.GetType())
            {
                obj = ConvertTo<Dollar>(otherCurrency);
            }
            else if (obj?.GetType() != this.GetType())
                return false;
            var currency = obj as Currency; 
            return currency?.GetHashCode() == this.GetHashCode();
        }

        protected bool Equals(Dollar dollar)
        {
            return dollar.amount == this.amount;
        }
    }
}*/
