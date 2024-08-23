using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    public class UserService
    {
        #region Singleton
        private static readonly UserService instance = new UserService();
        public UserService Instance { 
            get
            {
                return instance;
            }
        }
        private UserService() { }
        #endregion
        /// <summary>
        /// Obtengo todas las patentes de los accesos
        /// </summary>
        /// <param name="accesos"></param>
        /// <returns></returns>
        public List<Patente> getPatentes(List<Acceso> accesos)
        {
            List<Patente> patentes = new List<Patente>();

            GetAllPatentes(accesos, patentes);

            return patentes;
        }
        /// <summary>
        /// Bucea entre todos los accesos que tiene, validando si es una familia de pantentes o una patente en si
        /// </summary>
        /// <param name="accesos"></param>
        /// <param name="patentesReturn"></param>
        private void GetAllPatentes(List<Acceso> accesos, List<Patente> patentesReturn)
        {
            foreach (var acceso in accesos)
            {
                //Si tiene hijos es una familia
                if (acceso.HasChildren)
                {
                    GetAllPatentes((acceso as Familia).Accesos, patentesReturn);
                    continue;
                }

                //Si no es una familia, valido si la patente ya fue agregada entonces continuo con el siguiente registro
                if (patentesReturn.Any(o => o.Id == acceso.Id))
                    continue;

                patentesReturn.Add(acceso as Patente);
            }
        }
        /// <summary>
        /// Obtengo todas las familias de los accesos
        /// </summary>
        /// <param name="accesos"></param>
        /// <returns></returns>
        public List<Familia> GetFamilias(List<Acceso> accesos)
        {

            List<Familia> familias = new List<Familia>();

            GetAllFamilias(accesos, familias);

            return familias;

        }
        /// <summary>
        /// Bucea entre todas las familias que tiene, validando si es una familia de falimlias o una familia en si
        /// </summary>
        /// <param name="accesos"></param>
        /// <param name="famililaReturn"></param>
        private void GetAllFamilias(List<Acceso> accesos, List<Familia> famililaReturn)
        {
            foreach (var acceso in accesos)
            {
                //Si no tiene hijos no me interesa
                if (!acceso.HasChildren)
                    continue;

                if (!famililaReturn.Any(o => o.Id == acceso.Id))
                    famililaReturn.Add(acceso as Familia);

                GetAllFamilias((acceso as Familia).Accesos, famililaReturn);
            }
        }
    }
}
