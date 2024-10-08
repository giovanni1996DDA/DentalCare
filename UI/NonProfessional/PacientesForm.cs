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

namespace UI.NonProfessional
{
    public partial class PacientesForm : Form
    {
        private PacientesTabCtrlEventHandler _tabEventHandler;
        public PacientesForm()
        {
            InitializeComponent();

            _tabEventHandler = new PacientesTabCtrlEventHandler(TabCtrlPacientes);

            InitializeTabControls();

            TabCtrlPacientes.SelectedIndex = 0;

            _tabEventHandler.LoadFormInTab(TabCtrlPacientes.SelectedTab);
        }

        private void InitializeTabControls()
        {

            TabCtrlPacientes.SelectedIndexChanged += _tabEventHandler.OnTabChanged;
        }
    }
}
