namespace Currencies
{
    public class SEK : Currency
    {
        internal SEK(int amount) : base(amount) {}
        public override Currency Times(int factor) => new SEK(this.amount * factor);
    }
}