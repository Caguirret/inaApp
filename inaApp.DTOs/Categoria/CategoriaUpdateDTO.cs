using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace inaApp.DTOs.Categoria
{
    public class CategoriaUpdateDTO
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}
