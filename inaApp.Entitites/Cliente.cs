using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Entitites
{
    public class Cliente
    {
        public int Id {  get; set; }

        public string nomb { get; set; } = String.Empty;       

        public String apellido1 { get; set; } = String.Empty;

        public String apellido2 { get; set; } = String.Empty;

        public DateTime fechNac {  get; set; }

        public bool Estado { get; set; }

    }
}
