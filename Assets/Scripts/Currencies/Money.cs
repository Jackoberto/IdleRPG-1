using System;
using System.Collections.Generic;
using UnityEngine;

namespace Currencies
{
    public readonly struct Money
    {
        public static bool operator ==(Money left, Money right) => left.Equals(right);
        
        public static bool operator !=(Money left, Money right) => !left.Equals(right);
        
        public static Money operator +(Money left, Money right) => left.Add(right);
        
        public static Money operator +(Money left, float right) => left.Add(right);
        
        public static Money operator -(Money left, Money right) => left.Subtract(right);
        
        public static Money operator -(Money left, float right) => left.Subtract(right);

        public static Money operator *(Money left, float right) => left.Multiply(right);
        
        public static Money operator /(Money left, float right) => left.Divide(right);
        
        public static bool operator <(Money left, Money right) => !left.IsGreaterThan(right);

        public static bool operator >(Money left, Money right) => left.IsGreaterThan(right);

        private readonly float amount;

        private readonly Currencies currency;
        
        public static Dictionary<Currencies, float> ExchangeRates => new Dictionary<Currencies, float> {{Currencies.Dollar, 1.0f}, {Currencies.SEK, 0.12f}, {Currencies.Euro, 1.2f}};

        private Money(float amount, Currencies currency)
        { 
            this.amount = amount;
            this.currency = currency;
        }
        
        private static Money Convert(float amount, Currencies type)
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

        public static Money Dollar(float amount) => new Money(amount, Currencies.Dollar);

        public static Money SEK(float amount) => new Money(amount, Currencies.SEK);
        
        public static Money Euro(float amount) => new Money(amount, Currencies.Euro);
        
        public static Money Convert(Money convertFrom, Currencies convertTo)
        {
            switch (convertTo)
            {
                case Currencies.Dollar:
                    return Dollar(ExchangeRates[convertFrom.currency] / ExchangeRates[convertTo] * convertFrom.amount);
                case Currencies.SEK:
                    return SEK(ExchangeRates[convertFrom.currency] / ExchangeRates[convertTo] * convertFrom.amount);
                case Currencies.Euro:
                    return Euro(ExchangeRates[convertFrom.currency] / ExchangeRates[convertTo] * convertFrom.amount);
                default:
                    throw new ArgumentOutOfRangeException(nameof(convertTo), convertTo, null);
            }
        }
        
        public static void Convert(ref Money money, Currencies convertTo) => money = Convert(money, convertTo);

        public Money Multiply(float factor) => Convert(factor * this.amount, currency);
        
        public Money Divide(float denominator) => Convert(this.amount / denominator, currency);

        public Money Add(Money money)
        {
            if (this.currency != money.currency) {
                money = Convert(money, this.currency);
            }
            return Convert(this.amount + money.amount, currency);
        }
        
        public Money Add(float money)
        {
            return Convert(this.amount + money, currency);
        }
        
        public Money Subtract(Money money)
        {
            if (this.currency != money.currency) {
                money = Convert(money, this.currency);
            }
            return Convert(this.amount - money.amount, currency);
        }
        
        public Money Subtract(float money)
        {
            return Convert(this.amount - money, currency);
        }
        
        private bool IsGreaterThan(Money money)
        {
            if (currency != money.currency) {
                money = Convert(money, currency);
            }
            return amount > money.amount;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Money money)) return false;
            return Math.Abs(Convert(money, Currencies.Dollar).amount - Convert(this, Currencies.Dollar).amount) <= 0.05f;
        }
        
        public bool Equals(Money money)
        {
            return Math.Abs(Convert(money, Currencies.Dollar).amount - Convert(this, Currencies.Dollar).amount) <= 0.05f;
        }

        public override int GetHashCode() => Mathf.RoundToInt(amount * ExchangeRates[currency]);
        
        public override string ToString() => $"{this.amount:0.##} {currency}";
    }

    public enum Currencies
    {
        Dollar = 0,
        SEK = 1,
        Euro = 2
    }
}