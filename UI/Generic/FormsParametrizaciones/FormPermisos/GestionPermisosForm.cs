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
using UI.EventHandlers.Parametrizaciones.Permisos;

namespace UI.Generic.FormsParametrizaciones.FormPermiso
{
    public partial class GestionPermisosForm : Form
    {
        public GestionPermisosEventHandler eventHandler;
        public DgvScreenEventHandler dgvScreenEventHandler;
        public Permiso previewingPermiso { get; set; }
        public GestionPermisosForm()
        {
            InitializeComponent();

            eventHandler = new GestionPermisosEventHandler(this);
            dgvScreenEventHandler = new DgvScreenEventHandler(this);

            InitializeHandlers();
        }
        private void InitializeHandlers()
        {
            this.Load += eventHandler.HandleOnLoad;
            btnSave.Click += eventHandler.HandleOnSaveChanges;
            btnAddScreen.Click += dgvScreenEventHandler.HandleAddItem;
            btnRemoveScreen.Click += dgvScreenEventHandler.HandleRemoveItem;
            btnSearch.Click += eventHandler.HandleOnVisualize;
            btnDelete.Click += eventHandler.HandleOnDelete;
        }

        private void GestionPermisosForm_Load(object sender, EventArgs e)
        {

        }
    }
}
