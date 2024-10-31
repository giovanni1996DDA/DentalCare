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
using UI.NonProfessional.EventHandlers.Parametrizaciones.Roles;

namespace UI.NonProfessional.FormsParametrizaciones.FormsRoles
{
    public partial class AddRolePopup : Form
    {
        public bool Canceled { get; set; }
        public Rol selectedRol { get; set; }

        private AddRolePopUpEventHandler _addRolePopUpEventHandler;
        public AddRolePopup()
        {
            InitializeComponent();

            _addRolePopUpEventHandler = new AddRolePopUpEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _addRolePopUpEventHandler.HandleOnLoad;
            btnAdd.Click += _addRolePopUpEventHandler.HandleOnAdd;
            btnCancel.Click += _addRolePopUpEventHandler.HandleOnExit;
        }
    }
}
