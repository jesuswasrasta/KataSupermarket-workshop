namespace KataSupermarket
{
    public class CashRegister
    {
        private int _total = 0;
        private int _apples;

        public void Scan(string product)
        {
            if (product.Equals("apple"))
            {
                _apples += 1;
            }
            if (product.Equals("pear"))
            {
                _total += 30;    
            }
            if (product.Equals("pineapple"))
            {
                _total += 220;    
            }
            if (product.Equals("banana"))
            {
                _total += 60;    
            }
        }
        
        public int Checkout()
        {
            while (_apples >= 3)
            {
                _apples -= 3;
                _total += 130;
            }
            for (int i = 0; i < _apples; i++)
            {
                _total += 50;
            }
            
            return _total;
        }
    }
}