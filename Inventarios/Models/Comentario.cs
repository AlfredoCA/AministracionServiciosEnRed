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
    
    public partial class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Creador { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual KnowledgeItem KnowledgeItem { get; set; }
    }
}
