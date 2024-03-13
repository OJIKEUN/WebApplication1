namespace WebApplication1.Models
{
    public class Barang
    {
        public int Id { get; set; }
        public string NamaBarang { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int Balance => _balance;

        private int _balance;

        public Barang()
        {
            _balance = 0;
        }

        public void UpdateBalance()
        {
            _balance += In - Out;
        }
    }
}
