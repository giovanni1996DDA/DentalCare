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

namespace UI.Perofessional.Turnos
{
    public partial class AtenderTurnoForm : Form
    {
        private AtenderTurnoEventHandler _eventHandler;
        private DgvTurnosEventHandler _dgvEventHandler;

        public AtenderTurnoForm()
        {
            InitializeComponent();

            _eventHandler = new AtenderTurnoEventHandler(this);
            _dgvEventHandler = new DgvTurnosEventHandler(dgvTurnos);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            dgvTurnos.CellFormatting += _dgvEventHandler.HandleOnDgvTurnosCellFormatting;
            btnAtender.Click += _eventHandler.HandleOnSaveChanges;
        }
    }
}
