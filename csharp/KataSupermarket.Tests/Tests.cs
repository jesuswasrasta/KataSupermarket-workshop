using NUnit.Framework;

namespace KataSupermarket.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "When I checkout an apple, the system charges 50 cents")]
        public void OneAppleCosts50Cents()
        {
            //ASSERT
            var expected = 50;
            CashRegister register = new CashRegister();
            
            //ACT
            register.Scan("apple");
            var actual = register.checkout();
            
            //ASSERT
            Assert.AreEqual(expected, actual);
        }
    }
}