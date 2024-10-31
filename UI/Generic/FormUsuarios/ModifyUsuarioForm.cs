using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Generic.EventHandlers;

namespace UI.Generic.FormUsuarios
{
    public partial class ModifyUsuarioForm : Form
    {
        private ModifyUsuariosEventHandler _eventHandler;

        public ModifyUsuarioForm()
        {
            InitializeComponent();

            _eventHandler = new ModifyUsuariosEventHandler(this);

            InitializeHandlers();
        }
        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            this.KeyPreview = true;
            this.KeyDown += _eventHandler.HandleOnKeyDown;
            btnSave.Click += _eventHandler.HandleOnSaveChanges;
            dgvPermisos.CellFormatting += _eventHandler.HandleOnDgvPermisosCellFormatting;
            btnAddPermiso.Click += _eventHandler.HandleOnAddPermiso;
            btnRemovePermiso.Click += _eventHandler.HandleOnRemovePermiso;
            btnAddRole.Click += _eventHandler.HandleOnAddRol;
            btnRemoveRole.Click += _eventHandler.HandleOnRemoveRol;
            btnAddEspecialidad.Click += _eventHandler.HandleOnAddEspecialidad;
            btnRemoveEspecialidad.Click += _eventHandler.HandleOnRemoveEspecialidad;
            btnDelete.Click += _eventHandler.HandleOnDelete;
            btnResetPassword.Click += _eventHandler.HandleOnResetPassword;
        }
    }
}
