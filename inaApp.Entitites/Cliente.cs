using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.Entitites
{
    [Table(name: "tbCliente")]
    public class Cliente
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        
        //[Column("name")]
        public string nomb { get; set; } = String.Empty;
        
        //[Column("apellido1")]
        public String apellido1 { get; set; } = String.Empty;
        
        //Column("apellido2")]
        public String apellido2 { get; set; } = String.Empty;
        
        //[Column("fechaNaci")]
        public DateTime fechNac {  get; set; }
        
        //[Column("estado")]
        public bool Estado { get; set; }

    }
}
