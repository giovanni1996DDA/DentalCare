using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Patente : Acceso
    {
        /// <summary>
        /// Leaf de composite de permisos
        /// </summary>
        public TipoAcceso TipoAcceso { get; set; }

        public string DataKey { get; set; }
        /// <summary>
        /// Nunca tiene hijos, es un Leaf.
        /// </summary>
        public override bool HasChildren { 
            get 
            {
                return false;
            }
        }

        public Patente(TipoAcceso tipoAcceso = TipoAcceso.UI)
        {
            this.TipoAcceso = tipoAcceso;
        }

        /// 
        /// <param name="component"></param>
        public override void Add(Acceso component)
        {

            throw new Exception("No se puede agregar un elemento");

        }

        /// 
        /// <param name="component"></param>
        public override void Remove(Acceso component)
        {

            throw new Exception("No se puede quitar un elemento");

        }
    }

    public enum TipoAcceso
    {
        UI,
        Control,
        UseCases
    }
}
