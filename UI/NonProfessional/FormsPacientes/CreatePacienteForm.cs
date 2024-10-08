using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.NonProfessional.EventHandlers;
using UI.NonProfessional.EventHandlers.Pacientes;
using static MaterialSkin.MaterialItemCollection;

namespace UI.NonProfessional.FormsPacientes
{
    public partial class CreatePacienteForm : Form
    {
        private CreatePacientesEventHandler _eventHandler;
        public CreatePacienteForm()
        {
            InitializeComponent();

            _eventHandler = new CreatePacientesEventHandler(this);

            InitializeHandlers();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void InitializeHandlers()
        {
            btnCreate.Click += _eventHandler.HandleOnCreate;
        }
    }
}
