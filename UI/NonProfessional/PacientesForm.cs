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

namespace UI.NonProfessional
{
    public partial class PacientesForm : Form
    {
        private PacientesTabCtrlEventHandler _tabEventHandler;
        public PacientesForm()
        {
            InitializeComponent();

            InitializeTabControls();
        }

        private void InitializeTabControls()
        {
            _tabEventHandler = new PacientesTabCtrlEventHandler(TabCtrlPacientes);

            TabCtrlPacientes.SelectedIndexChanged += _tabEventHandler.OnTabChanged;
        }
    }
}
