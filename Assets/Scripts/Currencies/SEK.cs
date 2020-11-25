namespace Currencies
{
    public class SEK : Currency
    {
        internal SEK(int amount) : base(amount)
        {
            exchangeRate = 0.1f;
        }
        
        public SEK()
        {
            exchangeRate = 0.1f;
        }
        public override Currency Times(int factor) => new SEK(this.amount * factor);
        public override Currency Add(int value) => new SEK(this.amount + value);
        
        public override Currency Add(Currency currency)
        {
            Currency newCurrency = new SEK();
            if (!(currency is SEK))
            {
                newCurrency = ConvertTo<SEK>(currency);
            }
            newCurrency = newCurrency.Add(this.amount);
            return newCurrency;
        }

        public override bool Equals(object obj)
        {
            if (obj is Currency otherCurrency && otherCurrency.GetType() != this.GetType())
            {
                obj = ConvertTo<SEK>(otherCurrency);
            }
            else if (obj?.GetType() != this.GetType())
                return false;
            var currency = obj as Currency; 
            return currency?.GetHashCode() == this.GetHashCode();
        }

        protected bool Equals(SEK sek)
        {
            return sek.amount == this.amount;
        }
    }
}
