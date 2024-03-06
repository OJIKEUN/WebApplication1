using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Departemen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string ConsumableName { get; set; }

        [Required]
        public required string Brand { get; set; }

        [Required]
        public int Packaging { get; set; }

        [Required]
        public required string Unit { get; set; }

        [Required]
        public int MinimumStock { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }

        [Required]
        public int ReceivedQuantity { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime IncomingDate { get; set; }

        [Required]
        public int ConsumptionCost { get; set; }

        [NotMapped]
        public int CurrentStock
        {
            get
            {
                // Asumsikan Anda mendapatkan nilai stok saat ini dari beberapa sumber/logika lain.
                // Misalnya, ini bisa jadi penghitungan dari database atau logika bisnis yang kompleks.
                // Berikut ini hanyalah placeholder untuk logika tersebut.
                return (CalculateCurrentStock() + ReceivedQuantity) - ConsumptionCost;
            }
        }

        private int CalculateCurrentStock()
        {
            // Tempatkan logika untuk mendapatkan jumlah stok saat ini dari database atau sumber lain
            // Contoh:
            // int currentStock = ... (mengambil data dari database);
            // return currentStock;
            // Untuk demo, saya akan mengembalikan nilai statis.
            return 0; // Ganti dengan logika yang tepat.
        }
    }
}



/*using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Departemen
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public required string ConsumableName { get; set; }
		[Required]
		public required string Brand { get; set; }
		[Required]
		public int Packaging { get; set; }
		[Required]
		public required string Unit { get; set; }
		[Required]
		public int MinimumStock { get; set; }
		[Required]
		public DateTime ExpiredDate { get; set; }
		[Required]
		public int ReceivedQuantity { get; set; }
		[Required]
		public int Price { get; set;}
		[Required]
        public DateTime IncomingDate { get; set; }
		[Required]
		public int ConsumptionCost { get; set;}
		[Required]
		public int CurrentStock { get; set;}


    }
}
*/