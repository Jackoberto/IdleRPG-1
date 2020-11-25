using NUnit.Framework;
using UnityEngine;

namespace Currencies.Tests
{
    public class CurrencyTests
    {
        [Test]
        public void MultiplyDollar()
        {
            var five = Money.Dollar(5);
            Assert.AreEqual(Money.Dollar(10), five.Multiply(2));
            Assert.AreEqual(Money.Dollar(15), five.Multiply(3));
        }

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
        public void MultiplySEK()
        {
            var five = Money.SEK(5);
            Assert.AreEqual(Money.SEK(10), five.Multiply(2));
            Assert.AreEqual(Money.SEK(15), five.Multiply(3));
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

        [Test]
        public void DollarCanBeConvertedToSEKExplicitly()
        {
            var amount = Money.Dollar(10);
            var result = Money.Convert(amount, Currencies.SEK);
            Assert.AreEqual(Money.SEK(100), result);
        }
        
        [Test]
        public void SEKCanBeConvertedToDollarExplicitly()
        {
            var amount = Money.SEK(100);
            var result = Money.Convert(amount, Currencies.Dollar);
            Assert.AreEqual(Money.Dollar(10), result);
        }
        [Test]
        public void SEKCanBeConvertedToDollarImplicitly()
        {
            var amount = Money.SEK(100);
            Assert.AreEqual(Money.Dollar(10), amount);
        }
        
        [Test]
        public void DollarCanBeConvertedToSEKImplicitly()
        {
            var amount = Money.Dollar(10);
            Assert.True(Money.SEK(100) == amount);
        }

        [Test]
        public void DollarCanBeAddedToSEKExplicitly()
        {
            var amount = Money.SEK(30);
            var result = amount.Add(Money.Dollar(2));
            Debug.Log(result);
            Assert.True(result == Money.SEK(50));
        }
        
        [Test]
        public void DollarCanBeAddedToSEKImplicitly()
        {
            var amount = Money.SEK(30) + Money.Dollar(2);
            Debug.Log(amount);
            Assert.True(amount == Money.SEK(50));
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
        
        [Test]
        public void IsLessThanOperator()
        {
            var amount = Money.Dollar(20);
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
        public void InstanceConvertWorks()
        {
            var amount = Money.Dollar(20);
            Money.Convert(ref amount,Currencies.SEK);
            Debug.Log(amount);
            Assert.IsTrue(amount == Money.SEK(200));
        }
        
        [Test]
        public void MoneyEqualsMethod()
        {
            var amount = Money.Dollar(20);
            var equal = amount.Equals(Money.Dollar(20));
            Assert.IsTrue(equal);
        }

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
}
