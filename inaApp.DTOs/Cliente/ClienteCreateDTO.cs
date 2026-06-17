using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.DTOs.Cliente
{
    public class ClienteCreateDTO
    {

        [Required]
        public String TipoIdentificacion { get; set; } = String.Empty;

        [Required]
        [MaxLength(20)]
        public string NumeroIdentificacion { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public String Nombre { get; set; } = String.Empty;

        [Required]
        [MaxLength(50)]
        public String PrimerApellido { get; set; } = String.Empty;

        [MaxLength(50)]
        public String? SegundoApellido { get; set; } = String.Empty;

        [EmailAddress]
        [MaxLength(150)]
        public String Correo { get; set; } = String.Empty;

        [Phone]
        [MaxLength(12)]
        public String NumTelefono { get; set; } = string.Empty;
    }
}
