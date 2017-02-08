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
    public class ExtensionsUnitTest
    {
        [TestMethod]
        public void ReverseWordsTest()
        {
            // Arrange
            string sentence = "I don't care if the sun don't shine.";

            // Act
            string result = sentence.ReverseWords();

            // Assert
            Assert.AreEqual("I t'nod erac fi eht nus t'nod .enihs", result);
        }
    }
}
