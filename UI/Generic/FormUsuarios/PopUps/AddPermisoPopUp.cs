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

namespace UI.Generic.FormUsuarios.PopUps
{
    public partial class AddPermisoPopUp : Form
    {
        public bool Canceled { get; set; }
        public Permiso? selectedPermiso { get; set; }

        private AddPermisoPopupEventHandler _addPermisoPopUpEventHandler;
        public AddPermisoPopUp()
        {
            InitializeComponent();

            _addPermisoPopUpEventHandler = new AddPermisoPopupEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _addPermisoPopUpEventHandler.HandleOnLoad;
            btnAdd.Click += _addPermisoPopUpEventHandler.HandleOnAdd;
            btnCancel.Click += _addPermisoPopUpEventHandler.HandleOnExit;
        }
    }
}
