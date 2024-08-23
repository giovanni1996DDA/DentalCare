using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    /// <summary>
    /// Representa una familia de permisos
    /// </summary>
    public class Familia : Acceso
    {
        private List<Acceso> accesos = new List<Acceso>();

        public string Descripcion { get; set; }

        public override bool HasChildren { 
            get 
            { 
                return accesos.Any();
            } 
        }

        public List<Acceso> Accesos
        {
            get
            {
                return accesos;
            }
        }

        public Familia(Acceso acceso = null)
        {
            if (acceso != null)
                //acceso no debe ser null
                accesos.Add(acceso);
        }

        /// 
        /// <param name="component"></param>
        public override void Add(Acceso component)
        {
            accesos.Add(component);
        }

        /// 
        /// <param name="component"></param>
        public override void Remove(Acceso component)
        {
            //Ver que no puedo quedarme sin hijos...

            //accesos.Remove(component);
            accesos.RemoveAll(o => o.Id == component.Id);//Linq -> lambda exp. se ve más adelante
        }
    }
}
