using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace inaApp.DTOs.Cliente
{
    public class ClienteUpdateDTO
    {
        [Required]
        public int IdClient { get; set; }

        [Required]
        public string TipoIdentificacion { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string NumeroIdentificacion { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string PrimerApellido { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? SegundoApellido { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Phone]
        [MaxLength(12)]
        public string NumTelefono { get; set; } = string.Empty;

        public bool Estado { get; set; }
    }
}
