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
    
    public partial class Turno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Turno()
        {
            this.AtencionCabecera = new HashSet<AtencionCabecera>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid Profesional { get; set; }
        public System.Guid Especialidad { get; set; }
        public System.DateTime FechaHora { get; set; }
        public System.Guid Paciente { get; set; }
        public int Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtencionCabecera> AtencionCabecera { get; set; }
        public virtual Paciente Paciente1 { get; set; }
    }
}
