namespace KataSupermarket
{
    public class CashRegister
    {
        private int _total = 0;

        public void Scan(string product)
        {
            if (product.Equals("apple"))
            {
                _total += 50;    
            }
            if (product.Equals("pear"))
            {
                _total += 30;    
            }
        }
        
        public int Checkout()
        {
            return _total;
        }
    }
}