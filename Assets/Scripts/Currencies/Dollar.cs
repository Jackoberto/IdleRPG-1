namespace Currencies
{
    public class Dollar : Currency
    {
        public Dollar(int amount) : base(amount){}

        public override Currency Times(int factor) => new Dollar(this.amount * factor);
    }
}
