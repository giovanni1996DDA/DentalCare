using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.EventHandlers.Turnos;

namespace UI.NonProfessional.TurnosForms
{
    public partial class ModifyTurnoForm : Form
    {
        ModifyTurnosEventHandler _eventHandler;
        DgvTurnosEventHandler _dgvEventHandler;
        public ModifyTurnoForm()
        {
            InitializeComponent();

            _eventHandler = new ModifyTurnosEventHandler(this);
            _dgvEventHandler = new DgvTurnosEventHandler(dgvTurnos);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            btnSearchTurno.Click += _eventHandler.HandleSearchTurno;
            dgvTurnos.CellDoubleClick += _eventHandler.HandleDgvTurnosCellDoubleClick;
            dgvTurnos.CellFormatting += _dgvEventHandler.HandleOnDgvTurnosCellFormatting;
            btnSave.Click += _eventHandler.HandleOnSaveChanges;
            btnEliminar.Click += _eventHandler.HandleOnDelete;
        }
    }
}
