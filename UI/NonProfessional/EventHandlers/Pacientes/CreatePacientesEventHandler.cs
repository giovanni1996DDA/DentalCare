using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.NonProfessional.EventHandlers.Pacientes
{
    public class CreatePacientesEventHandler
    {
        private readonly Form _form;
        public CreatePacientesEventHandler(Form form)
        {
            _form = form;
        }
        public void HandleOnCreate(object sender, EventArgs e)
        {
            MessageBox.Show("Creando paciente");
        }
    }
}
