using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.NonProfessional.EventHandlers.Pacientes;

namespace UI.NonProfessional.FormsPacientes
{
    public partial class ModifyPacienteForm : Form
    {
        private ModifyPacientesEventHandler _eventHandler;
        public ModifyPacienteForm()
        {
            InitializeComponent();

            _eventHandler = new ModifyPacientesEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(_eventHandler.HandleOnKeyDown);
            btnSaveChanges.Click += _eventHandler.HandleSaveChanges;
        }
    }
}
