using NUnit.Framework;
using UnityEngine;

namespace Currencies.Tests
{
    public class CurrencyTests
    {
        [Test]
        public void MultiplyDollar()
        {
            var five = Currency.Dollar(5);
            Assert.AreEqual(Currency.Dollar(10), five.Times(2));
            Assert.AreEqual(Currency.Dollar(15), five.Times(3));
        }

        [Test]
        public void InstanceDoesntChangeAfterMultiply()
        {
            var five = Currency.Dollar(5);
            five.Times(3);
            Assert.AreEqual(Currency.Dollar(5), five);
        }

        [Test]
        public void ToStringFormat()
        {
            Assert.AreEqual("5 Dollar", Currency.Dollar(5).ToString());
        }

        [Test]
        public void MultiplySEK()
        {
            var five = Currency.SEK(5);
            Assert.AreEqual(Currency.SEK(10), five.Times(2));
            Assert.AreEqual(Currency.SEK(15), five.Times(3));
        }
        
        [Test]
        public void InheritedEqualsWorksAsIntended()
        {
            Assert.AreEqual(Currency.SEK(10), Currency.SEK(10));
        }
        
        [Test]
        public void InheritedOverloadedEqualsOperatorWorksAsIntended()
        {
            Assert.True(Currency.Dollar(10) != Currency.SEK(10));
        }

        [Test]
        public void MultiplyDoesntChangeType()
        {
            var product1 = Currency.SEK(5).Times(2);
            var product2 = Currency.Dollar(5).Times(2);
            Assert.AreNotEqual(product1, product2);
        }

        [Test]
        public void DollarCanBeConvertedToSEKExplicitly()
        {
            var amount = Currency.Dollar(10);
            var result = Currency.ConvertTo<SEK>(amount);
            Assert.AreEqual(Currency.SEK(100), result);
        }
        
        [Test]
        public void SEKCanBeConvertedToDollarExplicitly()
        {
            var amount = Currency.SEK(100);
            var result = Currency.ConvertTo<Dollar>(amount);
            Assert.AreEqual(Currency.Dollar(10), result);
        }
        [Test]
        public void SEKCanBeConvertedToDollarImplicitly()
        {
            var amount = Currency.SEK(100);
            Assert.AreEqual(Currency.Dollar(10), amount);
        }
        
        [Test]
        public void DollarCanBeConvertedToSEKImplicitly()
        {
            var amount = Currency.Dollar(10);
            Assert.True(Currency.SEK(100) == amount);
        }

        [Test]
        public void DollarCanBeAddedToSEKExplicitly()
        {
            var amount = Currency.SEK(30);
            var result = amount.Add(Currency.Dollar(2));
            Debug.Log(result);
            Assert.True(result.GetHashCode() == 50);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
       /* [UnityTest]
        public IEnumerator CurrencyTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }*/
    }
}
