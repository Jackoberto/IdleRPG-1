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
        
        public static Money operator -(Money left, Money right) => left.Subtract(right);

        public static Money operator *(Money left, int right) => left.Multiply(right);
        
        public static Money operator /(Money left, int right) => left.Divide(right);
        
        public static bool operator <(Money left, Money right) => !left.IsGreaterThan(right);

        public static bool operator >(Money left, Money right) => left.IsGreaterThan(right);

        private readonly int amount;

        private readonly Currencies currency;

        private readonly float exchangeRate;

        private static Dictionary<Currencies, float> ExchangeRates => new Dictionary<Currencies, float> {{Currencies.Dollar, 1.0f}, {Currencies.SEK, 0.1f}, {Currencies.Euro, 2.0f}};

        private Money(int amount, Currencies currency, float exchangeRate)
        { 
            this.amount = amount;
            this.currency = currency;
            this.exchangeRate = exchangeRate;
        }
        
        private static Money GenericCurrency(int amount, Currencies type)
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

        public static Money Dollar(int amount) => new Money(amount, Currencies.Dollar, ExchangeRates[Currencies.Dollar]);

        public static Money SEK(int amount) => new Money(amount, Currencies.SEK, ExchangeRates[Currencies.SEK]);
        
        public static Money Euro(int amount) => new Money(amount, Currencies.Euro, ExchangeRates[Currencies.Euro]);
        
        public static Money Convert(Money convertFrom, Currencies convertTo)
        {
            switch (convertTo)
            {
                case Currencies.Dollar:
                    return Dollar(Mathf.RoundToInt(convertFrom.exchangeRate / ExchangeRates[convertTo] * convertFrom.amount));
                case Currencies.SEK:
                    return SEK(Mathf.RoundToInt(convertFrom.exchangeRate / ExchangeRates[convertTo] * convertFrom.amount));
                case Currencies.Euro:
                    return Euro(Mathf.RoundToInt(convertFrom.exchangeRate / ExchangeRates[convertTo] * convertFrom.amount));
                default:
                    throw new ArgumentOutOfRangeException(nameof(convertTo), convertTo, null);
            }
        }
        
        public static void Convert(ref Money money, Currencies convertTo) => money = Convert(money, convertTo);

        public Money Multiply(int factor) => GenericCurrency(Mathf.RoundToInt(factor * this.amount), currency);
        
        public Money Divide(int denominator) => GenericCurrency(Mathf.RoundToInt((float)this.amount / denominator), currency);

        public Money Add(Money money)
        {
            if (this.currency != money.currency) {
                money = Convert(money, this.currency);
            }
            return GenericCurrency(money.amount + this.amount, currency);
        }
        
        public Money Subtract(Money money)
        {
            if (this.currency != money.currency) {
                money = Convert(money, this.currency);
            }
            return GenericCurrency(this.amount - money.amount, currency);
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
            if (money.currency != currency) {
                return Convert(money, currency).amount == amount;
            }
            return money.amount == amount;
        }
        
        public bool Equals(Money money)
        {
            if (money.currency != currency) {
                return Convert(money, currency).amount == amount;
            }
            return money.amount == amount;
        }

        public override int GetHashCode() => Mathf.RoundToInt(amount * exchangeRate);
        
        public override string ToString() => $"{this.amount} {currency}";
    }

    public enum Currencies
    {
        Dollar = 0,
        SEK = 1,
        Euro = 2
    }
}