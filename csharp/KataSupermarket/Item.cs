using System;

namespace KataSupermarket
{
    public record Item
    {
        public string ItemName { get; }

        public Item(string itemName)
        {
            ItemName = itemName;
        }
    }
}