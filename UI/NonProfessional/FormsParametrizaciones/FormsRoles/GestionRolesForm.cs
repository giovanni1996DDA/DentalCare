using Services.Domain;
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
        public GestionRolesEventHandler eventHandler;
        public DgvRolEventHandler dgvRolEventHandler;
        public DgvPermisoEventHandler dgvPermisoEventHandler;

        public Rol previewingRole { get; set; }
        public GestionRolesForm()
        {
            InitializeComponent();

            eventHandler = new GestionRolesEventHandler(this);
            dgvRolEventHandler = new DgvRolEventHandler(this);
            dgvPermisoEventHandler = new DgvPermisoEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += eventHandler.HandleOnLoad;
            txtDescripcion.TextChanged += eventHandler.HandleOnDescriptionChanged;
            btnSave.Click += eventHandler.HandleOnSaveChanges;
            btnSearch.Click += eventHandler.HandleOnVisualize;
            dgvRol.CellDoubleClick += dgvRolEventHandler.HandleDoubleClick;
            btnAddRole.Click += dgvRolEventHandler.HandleAddItem;
            btnRemoveRole.Click += dgvRolEventHandler.HandleRemoveItem;
            btnAddPermiso.Click += dgvPermisoEventHandler.HandleAddItem;
            btnRemovePermiso.Click += dgvPermisoEventHandler.HandleRemoveItem;
            btnDelete.Click += eventHandler.HandleOnDelete;
        }
    }
}
