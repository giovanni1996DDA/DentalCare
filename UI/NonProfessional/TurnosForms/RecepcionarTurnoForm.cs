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
    public partial class RecepcionarTurnoForm : Form
    {
        private RecepcionarTurnoEventHandler _eventHandler;
        private DgvTurnosEventHandler _dgvEventHandler;

        public RecepcionarTurnoForm()
        {
            InitializeComponent();

            _eventHandler = new RecepcionarTurnoEventHandler(this);
            _dgvEventHandler = new DgvTurnosEventHandler(dgvTurnos);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            dgvTurnos.CellFormatting += _dgvEventHandler.HandleOnDgvTurnosCellFormatting;
            btnRecepcionar.Click += _eventHandler.HandleOnSaveChanges;
        }
    }
}
