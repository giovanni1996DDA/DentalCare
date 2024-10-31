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
using UI.Generic.EventHandlers;
using UI.NonProfessional.EventHandlers.Parametrizaciones.Roles;

namespace UI.Generic.FormUsuarios.PopUps
{
    public partial class AddRolesPopUp : Form
    {
        public bool Canceled { get; set; }
        public Rol? selectedRol { get; set; }

        private AddRolesPopUpEventHandler _addRolesPopUpEventHandler;
        public AddRolesPopUp()
        {
            InitializeComponent();

            _addRolesPopUpEventHandler = new AddRolesPopUpEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _addRolesPopUpEventHandler.HandleOnLoad;
            btnAdd.Click += _addRolesPopUpEventHandler.HandleOnAdd;
            btnCancel.Click += _addRolesPopUpEventHandler.HandleOnExit;
        }
    }
}
