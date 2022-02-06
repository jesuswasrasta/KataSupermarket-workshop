using NUnit.Framework;

namespace KataSupermarket.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "When I checkout 3 apples, the system charges 150 cents")]
        public void ThreeApplesCosts150Cents()
        {
            //ASSERT
            var expected = 150;
            CashRegister register = new CashRegister();

            //ACT
            register.Scan("apple");
            register.Scan("apple");
            register.Scan("apple");
            var actual = register.Checkout();

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestCase("apple", 1, 50, Description = "When I checkout an apple, the system charges 50 cents")]
        [TestCase("pear", 1, 30, Description = "When I checkout 1 pear, the system charges 30 cents")]
        [TestCase("pineapple", 1, 220, Description = "When I checkout 1 pineapple, the system charges 220 cents")]
        [TestCase("banana", 1, 60, Description = "When I checkout 1 banana, the system charges 60 cents")]
        public void CheckoutTestCase(string product, int quantity, int expected)
        {
            var register = new CashRegister();
            
            register.Scan(product);
            var actual = register.Checkout();
            
            Assert.AreEqual(expected, actual);
        }
    }
}