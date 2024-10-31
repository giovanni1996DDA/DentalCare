using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.NonProfessional.EventHandlers.Turnos;

namespace UI.NonProfessional.EventHandlers.TurnosForms
{
    public partial class CreateTurnoForm : Form
    {
        CrearTurnoEventHandler _eventHandler;
        public CreateTurnoForm()
        {
            InitializeComponent();

            _eventHandler = new CrearTurnoEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            cbxEspecialidad.SelectedValueChanged += _eventHandler.HandleOnEspecialidadValueChange;
            btnSearchProf.Click += _eventHandler.handleSearchProf;
            btnSearchPac.Click += _eventHandler.handleSearchPac;
            btnSave.Click += _eventHandler.HandleOnSaveChanges;
        }
    }
}
