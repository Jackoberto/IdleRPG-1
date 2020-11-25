using System;
using UnityEngine;

namespace Currencies
{
    public class Currency
    {
        public static bool operator ==(Currency left, Currency right) => Equals(left, right);
        
        public static bool operator !=(Currency left, Currency right) => !Equals(left, right);
        
        public static Currency operator +(Currency left, Currency right) => left.Add(right);
        public static Currency operator -(Currency left, Currency right) => left.Add(right);

        private readonly int amount;

        private readonly Currencies type;

        private readonly float exchangeRate;

        private static float EuroExchangeRate = 2.0f;

        private static float DollarExchangeRate = 1.0f;

        private static float SEKExchangeRate = 0.1f;

        private Currency(int amount, Currencies type, float exchangeRate)
        { 
            this.amount = amount;
            this.type = type;
            this.exchangeRate = exchangeRate;
        }

        private Currency(){}

        public Currency Times(int factor) => GenericCurrency(Mathf.RoundToInt(factor * this.amount), type);

        public Currency Add(Currency currency)
        {
            Currency newCurrency = new Currency();
            if (this.type != currency.type)
            {
                newCurrency = Convert(currency, this.type);
            }

            newCurrency = GenericCurrency(newCurrency.amount + this.amount, type);

            return newCurrency;
        }

        public override string ToString() => $"{this.amount} {type}";

        public static Currency Convert(Currency convertFrom, Currencies convertTo)
        {
            switch (convertTo)
            {
                case Currencies.Dollar:
                {
                    return Dollar(Mathf.RoundToInt(convertFrom.exchangeRate / DollarExchangeRate * convertFrom.amount));
                }
                case Currencies.SEK:
                {
                    return SEK(Mathf.RoundToInt(convertFrom.exchangeRate / SEKExchangeRate * convertFrom.amount));
                }
                case Currencies.Euro:
                {
                    return Euro(Mathf.RoundToInt(convertFrom.exchangeRate / EuroExchangeRate * convertFrom.amount));  
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(convertTo), convertTo, null);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj?.GetType() != this.GetType())
                return false;
            if (obj is Currency currency && currency.type != this.type)
            {
                obj = Convert(currency, type);
            }
            var result = obj as Currency; 
            return result?.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode() => amount;

        private static Currency GenericCurrency(int amount, Currencies type)
        {
            switch (type)
            {
                case Currencies.Dollar:
                    return Dollar(amount);
                case Currencies.SEK:
                    return SEK(amount);
                case Currencies.Euro:
                    return Euro(amount);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static Currency Dollar(int amount) => new Currency(amount, Currencies.Dollar, DollarExchangeRate);

        public static Currency SEK(int amount) => new Currency(amount, Currencies.SEK, SEKExchangeRate);
        
        public static Currency Euro(int amount) => new Currency(amount, Currencies.Euro, EuroExchangeRate);
    }

    public enum Currencies : int
    {
        Dollar = 0,
        SEK = 1,
        Euro = 2
    }
}