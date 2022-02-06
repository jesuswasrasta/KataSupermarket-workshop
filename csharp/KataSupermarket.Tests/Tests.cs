using NUnit.Framework;

namespace KataSupermarket.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("apple", 1, ExpectedResult = 50, Description = "When I checkout an apple, the system charges 50 cents")]
        [TestCase("apple", 3, ExpectedResult = 150, Description = "When I checkout 3 apples, the system charges 150 cents")]
        [TestCase("apple", 3, ExpectedResult = 130, Description = "Offer: When I checkout 3 apples, the system charges 130 cents instead of 150")]
        
        [TestCase("pear", 1, ExpectedResult = 30, Description = "When I checkout 1 pear, the system charges 30 cents")]
        [TestCase("pear", 2, ExpectedResult = 60, Description = "When I checkout 2 pears, the system charges 60 cents")]
        [TestCase("pineapple", 1, ExpectedResult = 220, Description = "When I checkout 1 pineapple, the system charges 220 cents")]
        [TestCase("pineapple", 2, ExpectedResult = 440, Description = "When I checkout 2 pineapples, the system charges 440 cents")]
        [TestCase("banana", 1, ExpectedResult = 60, Description = "When I checkout 1 banana, the system charges 60 cents")]
        [TestCase("banana", 2, ExpectedResult = 120, Description = "When I checkout 2 bananas, the system charges 120 cents")]
        public int CheckoutTestCase(string product, int quantity)
        {
            var register = new CashRegister();

            for (int i = 0; i < quantity; i++)
            {
                register.Scan(product);    
            }

            return register.Checkout();
        }
    }
}