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
    }
}