using NUnit.Framework;
using UnityEngine;

namespace Currencies.Tests
{
    #region BasicTests

    public class BasicTests
    {
        [Test]
        public void InstanceDoesntChangeAfterMultiply()
        {
            var five = Money.Dollar(5);
            five.Multiply(3);
            Assert.AreEqual(Money.Dollar(5), five);
        }

        [Test]
        public void ToStringFormat()
        {
            Assert.AreEqual("5 Dollar", Money.Dollar(5).ToString());
        }

        [Test]
        public void InheritedEqualsWorksAsIntended()
        {
            Assert.AreEqual(Money.SEK(10), Money.SEK(10));
        }

        [Test]
        public void InheritedOverloadedEqualsOperatorWorksAsIntended()
        {
            Assert.True(Money.Dollar(10) != Money.SEK(10));
        }

        [Test]
        public void MultiplyDoesntChangeType()
        {
            var product1 = Money.SEK(5).Multiply(2);
            var product2 = Money.Dollar(5).Multiply(2);
            Assert.AreNotEqual(product1, product2);
        }
    }

    #endregion

    #region Convert

    public class Convert
    {
        [Test]
        public void InstanceConvertWorks()
        {
            var amount = Money.Dollar(20);
            Money.Convert(ref amount, Currencies.SEK);
            Debug.Log(amount);
            Assert.IsTrue(amount ==
                          Money.SEK(Money.ExchangeRates[Currencies.Dollar] / Money.ExchangeRates[Currencies.SEK] * 20));
        }

        [Test]
        public void SekCanBeConvertedToDollarThenBack()
        {
            var amount = Money.SEK(83.33f);
            var result = Money.Convert(amount, Currencies.Dollar);
            var result2 = Money.Convert(result, Currencies.SEK);
            Assert.AreEqual(amount, result2);
        }

        [Test]
        public void DollarCanBeConvertedToSekExplicitly()
        {
            var amount = Money.Dollar(10);
            var result = Money.Convert(amount, Currencies.SEK);
            Assert.AreEqual(Money.SEK(83.33f), result);
        }

        [Test]
        public void DollarCanBeConvertedToSekImplicitly()
        {
            var amount = Money.Dollar(10);
            Debug.Log(Money.Convert(amount, Currencies.SEK));
            Assert.True(Money.SEK(Money.ExchangeRates[Currencies.Dollar] / Money.ExchangeRates[Currencies.SEK] * 10) ==
                        amount);
        }

        [Test]
        public void DollarCanBeAddedToSekExplicitly()
        {
            var amount = Money.SEK(30);
            var result = amount.Add(Money.Dollar(2));
            Debug.Log(result);
            Assert.True(result ==
                        Money.SEK(30 + Money.ExchangeRates[Currencies.Dollar] / Money.ExchangeRates[Currencies.SEK] *
                            2));
        }

        [Test]
        public void DollarCanBeAddedToSekImplicitly()
        {
            var amount = Money.SEK(30) + Money.Dollar(2);
            Debug.Log(amount);
            Assert.True(amount ==
                        Money.SEK(30 + Money.ExchangeRates[Currencies.Dollar] / Money.ExchangeRates[Currencies.SEK] *
                            2));
        }
    }

    #endregion

    #region MathOperators

    public class MathOperatorsWithSameCurrency
    {
        [Test]
        public void MultiplyMethod()
        {
            var five = Money.Dollar(5);
            Assert.AreEqual(Money.Dollar(10), five.Multiply(2));
            Assert.AreEqual(Money.Dollar(15), five.Multiply(3));
        }

        [Test]
        public void DollarCanBeSubtracted()
        {
            var amount = Money.Dollar(20) - Money.Dollar(5);
            Debug.Log(amount);
            Assert.True(amount == Money.Dollar(15));
        }

        [Test]
        public void DollarCanBeAdded()
        {
            var amount = Money.Dollar(20).Add(Money.Dollar(5));
            Debug.Log(amount);
            Assert.True(amount == Money.Dollar(25));
        }

        [Test]
        public void DollarCanBeMultipliedWithOperator()
        {
            var amount = Money.Dollar(20);
            amount *= 4;
            Debug.Log(amount);
            Assert.True(amount == Money.Dollar(80));
        }

        [Test]
        public void DollarCanBeDividedWithOperator()
        {
            var amount = Money.Dollar(20);
            amount /= 4;
            Debug.Log(amount);
            Assert.True(amount == Money.Dollar(5));
        }
    }

    #endregion

    #region ComparisonOperators

    public class ComparisonOperators
    {
        [Test]
        public void IsLessThanOperator()
        {
            var amount = Money.Dollar(16);
            var result = amount < Money.Dollar(17);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsLessThanWithDifferentCurrencies()
        {
            var amount = Money.Dollar(16);
            var result = amount < Money.Euro(16);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsGreaterThanOperator()
        {
            var amount = Money.Dollar(20);
            var result = amount > Money.Dollar(16);
            Assert.IsTrue(result);
        }

        [Test]
        public void MoneyEqualsMethod()
        {
            var amount = Money.Dollar(20);
            var equal = amount.Equals(Money.Dollar(20));
            Assert.IsTrue(equal);
        }

        [Test]
        public void FloatingPointTolerance()
        {
            var amount1 = Money.Dollar(20);
            var amount2 = Money.Dollar(19.95f);
            Debug.Log(amount2.ToString());
            Assert.AreEqual(amount2, amount1);
        }
    }

    #endregion

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        /*[UnityTest]
        public IEnumerator CurrencyTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }*/
}
