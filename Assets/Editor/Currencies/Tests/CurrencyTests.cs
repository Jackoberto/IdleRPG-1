using NUnit.Framework;

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
