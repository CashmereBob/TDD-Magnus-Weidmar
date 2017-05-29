using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Test
{
    [TestFixture]
    class CalculatorTest
    {
        Calculator sut;

        [SetUp]
        public void Setup()
        {
            sut = new StringCalculator.Calculator();
        }

        [Test]
        public void CalculateEmptyInput()
        {
            var result = sut.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalculateOneInput()
        {
            var result = sut.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void CalculateTwoInput()
        {
            var result = sut.Add("1, 2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void CalculateUnknownAmountOfNumbersInput()
        {
            var result = sut.Add("1, 2, 3, 4,5,6,0,2,3,5,6");

            Assert.AreEqual(37, result);
        }

        [Test]
        public void CalculateWithNewLineInput()
        {
            var result = sut.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void CalculateWithCustomDelimeterInput()
        {
            var result = sut.Add("//;\n1\n2;3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void CalculateNegativesInInput()
        {
            
            var e = Assert.Throws<NegativeNumberException>(() => {

                sut.Add("1,2,-5,3,4,-3");
            });

            Assert.AreEqual("Negatives not allowed: -5 -3", e.Message);
        }
        [Test]
        public void CalculateWithBigNumberInput()
        {
            var result = sut.Add("2,1001");

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CalculateWithMultiTokenCustomDelimeterInput()
        {
            var result = sut.Add("//[Hej]\n1\n2Hej3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void CalculateWithMultiCustomDelimeterInput()
        {
            var result = sut.Add("//[:][;][,]\n1\n1:1;1,1");

            Assert.AreEqual(5, result);
        }

        public void CalculateWithMultiCustomMultiTokenDelimeterInput()
        {
            var result = sut.Add("//[Hej][;][Hopp]\n1\n1;1 Hopp1Hej1");

            Assert.AreEqual(5, result);
        }
    }
}

