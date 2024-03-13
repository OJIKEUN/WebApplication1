namespace WebApplication1.Models;
using System.ComponentModel.DataAnnotations;


    public class StockBarang
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Barang harus diisi")]
        public string NamaBarang { get; set; }

        [Required(ErrorMessage = "Nilai In harus diisi")]
        public int In { get; set; }

        [Required(ErrorMessage = "Nilai Out harus diisi")]
        public int Out { get; set; }

        public int Balance { get; set; }

        public StockBarang()
        {
            // Hitung balance awal
            Balance = In - Out;
        }
    }

