using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDesktop.Models
{
    public static class RandomId
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
    [Index(nameof(Book.Name),IsUnique = true)]
    public class Book
    {
        [Key]
        public string? Id { get; set; } = RandomId.RandomString(6);
        [Column(TypeName = "nvarchar(255)")]
        [Required,Unicode(false)]
        public string Name { get; set; }
        public string ImgPath { get; set; }
        [Range(1,10000000000)]
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        [Range(1,10000)]
        public int Quantity { get; set; }
        public int Sold { get; set; }
        [Required]
        [Unicode(false),MaxLength(255)]
        public string Author { get; set; }
        [Column("Create_at")]
        public DateTime TimeCreate { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
    }
    public class BookDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImgPath { get; set; }
        [Range(1, 10000000000)]
        public int Price { get; set; }
        [Range(1, 1000000)]
        public int Quantity { get; set; }
        [Required]
        public string Author { get; set; }
        public int CategoryId { get; set; }
    }
}
