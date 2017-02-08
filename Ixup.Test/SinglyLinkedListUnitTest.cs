using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixup.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ixup.Test
{
    [TestClass]
    public class SinglyLinkedListUnitTest
    {
        [TestMethod]
        public void SinglyLinkedListTest()
        {
            // Arrange
            var linkedList = new SinglyLinkedList();

            for (var i = 11; i > 1; i--)
            {
                linkedList.Insert(i);
            }

            // Act
            SinglyLinkedListNode x = linkedList.NodeFromTail(5);

            // Assert
            Assert.AreEqual(7, x.Value);
        }
    }
}
