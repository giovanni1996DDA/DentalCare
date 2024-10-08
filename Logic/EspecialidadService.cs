using Dao;
using Logic.Exceptions;
using Services.Domain;
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
            return new Especialidad();
        }
        public Especialidad GetOne(User user)
        {
            using (DentalCareDBEntities context = new DentalCareDBEntities())
            {
                var especialida = context.Especialidad.FirstOrDefault();
                Console.WriteLine(especialida?.Nombre);

                // Buscar la especialidad asociada al usuario en la tabla UsuarioEspecialidad
                Especialidad especialidad= context.UsuarioEspecialidad
                                            .Where(ue => ue.Usuario == user.Id)  // Filtrar por el usuario pasado como parámetro
                                            .Select(ue => ue.Especialidad1)  // Seleccionar la especialidad asociada
                                            .FirstOrDefault();  // Obtener la primera o default (null si no encuentra)

                //if (especialidad == null)
                //{
                //    throw new NoEspecialidadFoundException();
                //}

                return especialidad;
            }
        }

        public Especialidad FillSpec(User user)
        {
            //Agregar logica para especialidad
            return new Especialidad();
        }

    }
}
