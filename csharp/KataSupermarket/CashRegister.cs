namespace KataSupermarket
{
    public class CashRegister
    {
        private int _total;

        public void Scan(string product)
        {
            _total += 50;
        }
        
        public int Checkout()
        {
            return _total;
        }
    }
}