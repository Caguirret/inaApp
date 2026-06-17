using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.DTOs.Producto
{
    public class ProductoUpdateDTO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El Id es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El Stock es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock no puede ser negativo o 0.")]
        public int Stock { get; set; }


        [StringLength(500, ErrorMessage = "La descripcion no puede superar los 500 caracteres.")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

    }
}
