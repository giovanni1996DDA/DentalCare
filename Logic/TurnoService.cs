using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TurnoService
    {
        private static TurnoService _instance = new TurnoService();

        public static TurnoService Instance
        {
            get
            {
                return _instance;
            }
        }
        private TurnoService()
        {
        }

        public void Create(Turno protoTurno)
        {
            // Validar el turnoPrototipo para asegurar que los datos esenciales están completos
            if (protoTurno == null) throw new ArgumentNullException(nameof(protoTurno));
            if (protoTurno.Profesional == Guid.Empty) throw new ArgumentException("El profesional es obligatorio.");
            if (protoTurno.Paciente == Guid.Empty) throw new ArgumentException("El paciente es obligatorio.");

            using (var context = new DentalCareDBEntities())
            {
                protoTurno.Id = protoTurno.Id == Guid.Empty ? Guid.NewGuid() : protoTurno.Id;

                context.Turno.Add(protoTurno);

                context.SaveChanges();
            }
        }
    }
}
