using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    [Table("Producto", Schema = "dbo")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int idProducto { get; set; }
        
        [Required] 
        public string nombre { get; set; }

        [Required]
        public string estado { get; set; }

        [Required]
        public int stock { get; set; }

    }
}
