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
            var actual = register.Checkout();
            
            //ASSERT
            Assert.AreEqual(expected, actual);
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

        [Test(Description = "When I checkout 1 pear, the system charges 30 cents")]
        public void OnePearCosts30Cents()
        {
            const int expected = 30;
            var register = new CashRegister();
            
            register.Scan("pear");
            var actual = register.Checkout();
            
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "When I checkout 1 pineapple, the system charges 220 cents")]
        public void OnePineappleCosts220Cents()
        {
            const int expected = 220;
            var register = new CashRegister();
            
            register.Scan("pineapple");
            var actual = register.Checkout();
            
            Assert.AreEqual(expected, actual);
        }
    }
}