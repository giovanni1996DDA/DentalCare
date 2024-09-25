using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class EspecialidadService
    {
        private static readonly EspecialidadService _instance = new EspecialidadService();
        private EspecialidadService()
        {
        }
        public static EspecialidadService Instance
        {
            get
            {
                return _instance;
            }
        }

        public Especialidad GetOne(Especialidad esp) 
        {
            //Agregar logica para especialidad
            return new Especialidad();
        }

    }
}
