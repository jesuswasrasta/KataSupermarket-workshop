namespace KataSupermarket
{
    public class CashRegister
    {
        private int _total = 0;
        private int _apples;
        private int _pears;

        public void Scan(string product)
        {
            if (product.Equals("apple"))
            {
                _apples += 1;
            }
            if (product.Equals("pear"))
            {
                _pears += 1;    
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
            while (_pears >= 2)
            {
                _pears -= 2;
                _total += 45;
            }
            for (int i = 0; i < _apples; i++)
            {
                _total += 50;
            }
            for (int i = 0; i < _pears; i++)
            {
                _total += 30;
            }
            
            return _total;
        }
    }
}