using NUnit.Framework;
using System;
using System.Globalization;
using UnityEngine;

namespace Common.Tests
{
    public class TimePlayedTests : MonoBehaviour
    {
        /*[Test]
        public void TestConvertToInt()
        {
            Assert.NotZero(TimePlayed.ConvertToInt(DateTime.Parse("0050-11-23 15:20:30")));
        }
        
        [Test]
        public void TestConvertFromInt()
        {
            Assert.NotNull(TimePlayed.ConvertFromInt(1606145000));
        }*/

        [Test]
        public void TestInitialize()
        {
            Assert.IsTrue(TimePlayed.Initialize());
        }

        [ContextMenu("Save")] [Test]
        public void TestSave()
        {
            TimePlayed.SaveDestroyedTime();
        }
    }
}
