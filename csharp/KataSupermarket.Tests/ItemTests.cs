using NUnit.Framework;

namespace KataSupermarket.Tests
{
    public class ItemTests
    {
        [Test]
        public void BuildAnApple()
        {
            var expectedApple = new Item("apple");
            var actualApple = new Item("apple");

            Assert.AreEqual(expectedApple, actualApple);
        }   
        
        [Test]
        public void AppleAndOrangeAreNotTheSame()
        {
            var expectedOrange = new Item("orange");
            var actualApple = new Item("apple");

            Assert.AreNotEqual(expectedOrange, actualApple);
        }
    }
}