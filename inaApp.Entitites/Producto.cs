using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace inaApp.Entitites

    //niveles de acceso
    //public: cualquier clase puede acceder a esta clase
    //private: solo las clases dentro del mismo archivo pueden acceder a esta clase
    //internal: solo las clases dentro del mismo proyecto pueden acceder a esta clase
    //protected solo permite acceder a los objetos dentro de la misma capa atraves de la herencia 
{
    public class Producto
    {

        //propiedades: son las variables o las caracteristicas de un objeto, ejemplo su ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }
        public string name {  get; set; } = string.Empty;
        public decimal price {  get; set; }
        
        public string description { get; set;} = string.Empty;
        public bool state {  get; set; }
       
    }
}
