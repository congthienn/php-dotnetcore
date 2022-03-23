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
    [Table("Roles")]
    [Index(nameof(Role.Name),IsUnique = true)]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Unicode(true)]
        public string Name { get; set; }
        [Column("Create_at")]
        public DateTime TimeCreate { get; set; } = DateTime.UtcNow;
        public int Quantity { get; set; } = 0;
    }
    public class RoleDTO
    {
        [Required]
        public string Name { get; set; }
    }
}