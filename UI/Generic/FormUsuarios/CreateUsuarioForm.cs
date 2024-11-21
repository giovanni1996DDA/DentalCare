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
    public partial class CreateUsuarioForm : Form
    {
        private CreateUsuariosEventHandler _eventHandler;
        private TextBoxEventHandler _textBoxEventHandler;

        public CreateUsuarioForm()
        {
            InitializeComponent();

            _eventHandler = new CreateUsuariosEventHandler(this);
            _textBoxEventHandler = new TextBoxEventHandler();

            InitializeHandlers();
        }
        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            btnCreate.Click += _eventHandler.HandleOnCreate;
            dgvPermisos.CellFormatting += _eventHandler.HandleOnDgvPermisosCellFormatting;
            btnAddPermiso.Click += _eventHandler.HandleOnAddPermiso;
            btnRemovePermiso.Click += _eventHandler.HandleOnRemovePermiso;
            btnAddRole.Click += _eventHandler.HandleOnAddRol;
            btnRemoveRole.Click += _eventHandler.HandleOnRemoveRol;
            btnAddEspecialidad.Click += _eventHandler.HandleOnAddEspecialidad;
            btnRemoveEspecialidad.Click += _eventHandler.HandleOnRemoveEspecialidad;
            txtPassword.Enter += _textBoxEventHandler.HandleOnEnter;
            txtPassword.Leave += _textBoxEventHandler.HandleOnLeave;
        }
    }
}
