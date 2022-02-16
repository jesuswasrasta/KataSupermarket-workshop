namespace KataSupermarket
{
    public class CashRegister
    {
        private int _apples;
        private int _pears;
        private int _pineapples;
        private int _bananas;

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
                _pineapples += 1;    
            }
            if (product.Equals("banana"))
            {
                _bananas += 1;    
            }
        }
        
        public int Checkout()
        {
            int total = 0;
            while (_apples >= 3)
            {
                _apples -= 3;
                total += 130;
            }
            while (_pears >= 2)
            {
                _pears -= 2;
                total += 45;
            }
            for (int i = 0; i < _apples; i++)
            {
                total += 50;
            }
            for (int i = 0; i < _pears; i++)
            {
                total += 30;
            }
            for (int i = 0; i < _pineapples; i++)
            {
                total += 220;
            }
            for (int i = 0; i < _bananas; i++)
            {
                total += 60;
            }
            
            return total;
        }
    }
}