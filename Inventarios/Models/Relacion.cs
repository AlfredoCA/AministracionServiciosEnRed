//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventarios.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Relacion
    {
        public int IdArticulo1 { get; set; }
        public int IdArticulo2 { get; set; }
        public int IdRelacion { get; set; }
    
        public virtual Articulos Articulos1 { get; set; }
        public virtual Articulos Articulos2 { get; set; }
    }
}
