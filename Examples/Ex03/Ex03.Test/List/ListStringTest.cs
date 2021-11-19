using Ex03.List;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.Test.List
{          
    [TestFixture]
    public class ListStringTest
    {
        [Test]
        public void ListString_ManageItems()
        {
            ListString list = new ListString();
            Assert.AreEqual(0, list.Count);

            list.Add("Item1");
            Assert.AreEqual(1, list.Count);

            Assert.AreEqual("Item1", list.Get(0));

            list.Remove(0);
            Assert.AreEqual(0, list.Count);
        }
    }
}
