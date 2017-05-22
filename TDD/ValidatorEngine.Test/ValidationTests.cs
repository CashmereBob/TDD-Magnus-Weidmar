using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorEngine.Test
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void TrueForValidAdress()
        {
            var sut = new Validator();

            bool isValid = sut.ValidateEmailAdress("weidmar@gmail.com");
            
            Assert.IsTrue(isValid);
        }

        [Test]
        public void FalseForInvalidAdress()
        {
            var sut = new Validator().ValidateEmailAdress("Hepp");

            Assert.IsFalse(sut);
        }
    }
}
