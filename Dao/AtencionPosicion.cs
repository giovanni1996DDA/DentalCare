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
    
    public partial class AtencionPosicion
    {
        public System.Guid Id { get; set; }
        public int Numero { get; set; }
        public decimal Cantidad { get; set; }
        public System.Guid Consumible { get; set; }
    
        public virtual AtencionCabecera AtencionCabecera { get; set; }
        public virtual Consumible Consumible1 { get; set; }
    }
}
