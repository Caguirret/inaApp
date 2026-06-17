using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.Entitites
{
    [Table("tbCategoria")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public bool Estado {  get; set; }

        //Relacion de 1 a muchos 
        public ICollection<Producto> Productos { get; set; }
        = new List<Producto>();
    }
}
