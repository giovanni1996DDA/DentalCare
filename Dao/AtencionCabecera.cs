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
    
    public partial class AtencionCabecera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AtencionCabecera()
        {
            this.AtencionPosicion = new HashSet<AtencionPosicion>();
            this.Imagen = new HashSet<Imagen>();
        }
    
        public System.Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public System.Guid Turno { get; set; }
        public Nullable<System.Guid> Tratamiento { get; set; }
    
        public virtual Tratamiento Tratamiento1 { get; set; }
        public virtual Turno Turno1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtencionPosicion> AtencionPosicion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imagen> Imagen { get; set; }
    }
}
