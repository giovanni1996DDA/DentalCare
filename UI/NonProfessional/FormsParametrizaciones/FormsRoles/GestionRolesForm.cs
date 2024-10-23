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
using UI.NonProfessional.EventHandlers.Parametrizaciones.Roles;

namespace UI.NonProfessional.FormsParametrizaciones.FormsRoles
{
    public partial class GestionRolesForm : Form
    {
        private GestionRolesEventHandler _eventHandler;
        private DgvRolEventHandler _dgvRolEventHandler;
        public GestionRolesForm()
        {
            InitializeComponent();

            _eventHandler = new GestionRolesEventHandler(this);
            _dgvRolEventHandler = new DgvRolEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            btnSave.Click += _eventHandler.HandleSaveChanges;
            btnSearch.Click += _eventHandler.HandleVisualize;
            dgvRol.CellDoubleClick += _dgvRolEventHandler.HandleDoubleClick;
        }
    }
}
