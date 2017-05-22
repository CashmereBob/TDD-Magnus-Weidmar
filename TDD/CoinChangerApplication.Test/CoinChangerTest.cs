using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangerApplication.Test
{
    [TestFixture]
    class CoinChangerTest
    {
        [Test]
        public void CorrectChangeWhenUsingOneCoinType()
        {
            //Arrange
            var coinTypes = new List<decimal> { 1.0m };
            var sut = new CoinChanger(coinTypes);

            //Act
            Dictionary<decimal, int> myChange = sut.MakeChange(14.0m);

            //Assert
            Assert.AreEqual(14, myChange[1m]);

        }

        [Test]
        public void CorrectChangeWhenUsingTwoCoinType()
        {
            //Arrange
            var coinTypes = new List<decimal> { 1.0m, 5.0m };
            var sut = new CoinChanger(coinTypes);

            //Act
            Dictionary<decimal, int> myChange = sut.MakeChange(14.0m);

            //Assert
            Assert.AreEqual(4, myChange[1m]);
            Assert.AreEqual(2, myChange[5m]);

        }

        [Test]
        public void CorrectChangeWhenUsingTwoCoinTypeShuffle()
        {
            //Arrange
            var coinTypes = new List<decimal> { 5.0m, 1.0m };
            var sut = new CoinChanger(coinTypes);

            //Act
            Dictionary<decimal, int> myChange = sut.MakeChange(59.0m);


            //Assert
            Assert.AreEqual(4, myChange[1m]);
            Assert.AreEqual(11, myChange[5m]);

        }

        [Test]
        public void CorrectChangeWhenUsingDecimalCoinTypes()
        {
            //Arrange
            var coinTypes = new List<decimal> { 0.25m, 0.50m, 5.0m, 1.0m};
            var sut = new CoinChanger(coinTypes);

            //Act
            Dictionary<decimal, int> myChange = sut.MakeChange(13.75m);

            //Assert
            Assert.AreEqual(3, myChange[1m]);
            Assert.AreEqual(2, myChange[5m]);
            Assert.AreEqual(1, myChange[0.25m]);
            Assert.AreEqual(1, myChange[0.5m]);

        }
    }
}
