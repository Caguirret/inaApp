using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.DTOs.Producto
{
    public class ProductoResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
