//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuarioEspecialidad
    {
        public System.Guid Usuario { get; set; }
        public System.Guid Especialidad { get; set; }
    
        public virtual Especialidad Especialidad1 { get; set; }
    }
}