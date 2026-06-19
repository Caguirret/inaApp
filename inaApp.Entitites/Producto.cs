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
    [Table(name:"tbProducto")]
    public class Producto
    {

        /*
        Un producto tiene una sola categoiria
        Una categoria tiene muchos productos
        Clase categoria = muchos productos 
        Clase productos = 1 categoria de tipo Categoria.cs

         */

        //propiedades: son las variables o las caracteristicas de un objeto, ejemplo su ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre {  get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage ="El precio debe ser mayor que cero.")]
        public decimal Precio {  get; set; }

        [Required(ErrorMessage = "El Stock es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock no puede ser negativo o 0.")]
        public int Stock {  get; set; }


        [StringLength(500, ErrorMessage = "La descripcion no puede superar los 500 caracteres.")]
        public string? Descripcion { get; set;}

        [Column(name:"estado")]
        public bool Estado {  get; set; }

        public DateTime FechaCreacion { get; set; }

        //Categoria relacion con Productos 
        public int? IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        public Categoria? Categoria { get; set; }
       
    }
}
