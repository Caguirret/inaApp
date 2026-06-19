using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.DTOs.Cliente
{
    public class ClienteResponseDTO
    {
        public int IdClient { get; set; }
        public string TipoIdentificacion { get; set; } = string.Empty;

        public String NumeroIdentificacion { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string PrimerApellido { get; set; } = string.Empty;

        public string? SegundoApellido { get; set; }

        public string Correo { get; set; } = string.Empty;

        public string NumTelefono { get; set; } = string.Empty;

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
