namespace Currencies
{
    public class Dollar : Currency
    {
        internal Dollar(int amount) : base(amount){}
        public override Currency Times(int factor) => new Dollar(this.amount * factor);
    }
}
