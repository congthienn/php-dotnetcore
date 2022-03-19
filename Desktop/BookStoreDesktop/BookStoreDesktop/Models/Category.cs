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
    [Table("Categories")]
    [Index(nameof(Category.Name), IsUnique = true)]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(250),Unicode(false)]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
        [Column("Create_at")]
        [DataType(DataType.Date)]
        public DateTime TimeCreate { get; set; } = DateTime.Now;
        public List<Book>? Books { get; set; }
    }
    public class CategoryDTO
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
