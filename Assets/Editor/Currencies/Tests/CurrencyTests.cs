﻿using NUnit.Framework;
using UnityEngine;

namespace Currencies.Tests
{
    public class CurrencyTests
    {
        [Test]
        public void MultiplyDollar()
        {
            var five = new Dollar(5);
            Assert.AreEqual(new Dollar(10), five.Times(2));
            Assert.AreEqual(new Dollar(15), five.Times(3));
        }

        [Test]
        public void InstanceDoesntChangeAfterMultiply()
        {
            var five = new Dollar(5);
            five.Times(3);
            Assert.AreEqual(new Dollar(5), five);
        }
        
        [Test]
        public void CantConvertDollarToSEK()
        {
            Assert.AreNotEqual(new SEK(5), new Dollar(5));
        }
        
        [Test]
        public void ToStringFormat()
        {
            Assert.AreEqual("5 Dollar", new Dollar(5).ToString());
        }

        [Test]
        public void MultiplySEK()
        {
            var five = new SEK(5);
            Assert.AreEqual(new SEK(10), five.Times(2));
            Assert.AreEqual(new SEK(15), five.Times(3));
        }
        
        [Test]
        public void InheritedEqualsWorksAsIntended()
        {
            Assert.AreEqual(new SEK(10), new SEK(10));
        }
        
        [Test]
        public void InheritedOverloadedEqualsOperatorWorksAsIntended()
        {
            Assert.True(new Dollar(10) != new SEK(10));
        }

        [Test]
        public void MultiplyDoesntChangeType()
        {
            var product1 = new SEK(5).Times(2);
            var product2 = new Dollar(5).Times(2);
            Debug.Log($"{product1} {product2}");
            Assert.AreNotEqual(product1, product2);
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
