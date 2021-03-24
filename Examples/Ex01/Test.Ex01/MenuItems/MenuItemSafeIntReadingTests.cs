using System;
using System.Collections.Generic;
using System.Text;
using Ex01.MenuItems;
using NUnit.Framework;

namespace Test.Ex01.MenuItems
{
    [TestFixture]
    public class MenuItemSafeIntReadingTests
    {
        [TestCase(2, ExpectedResult = 4)]
        [TestCase(10, ExpectedResult = 100)]
        public int MenuItemSafeIntReading_Calc1(int value)
        {
            return MenuItemSafeIntReading.Calc(value);
        }

        [TestCase(3, 9)]
        [TestCase(4, 16)]
        public void MenuItemSafeIntReading_Calc2(int value, int result)
        {
            Assert.AreEqual(result, MenuItemSafeIntReading.Calc(value));   
        }
    }
}
