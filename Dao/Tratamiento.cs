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
    
    public partial class Tratamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tratamiento()
        {
            this.AtencionCabecera = new HashSet<AtencionCabecera>();
        }
    
        public System.Guid Id { get; set; }
        public System.DateTime FechaFin { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.Guid TipoTratamiento { get; set; }
        public System.Guid UsuCreacion { get; set; }
        public System.Guid Paciente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtencionCabecera> AtencionCabecera { get; set; }
        public virtual Paciente Paciente1 { get; set; }
        public virtual TipoTratamiento TipoTratamiento1 { get; set; }
    }
}