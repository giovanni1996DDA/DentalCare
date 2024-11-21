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
using Screen = Services.Domain.Screen;

namespace UI.Generic.FormsParametrizaciones.FormPermisos
{
    public partial class AddScreenPopup : Form
    {
        public bool Canceled { get; set; }
        public Screen selectedScreen { get; set; }

        private AddScreenPopupEventHandler _addScreenPopUpEventHandler;
        public AddScreenPopup()
        {
            InitializeComponent();

            _addScreenPopUpEventHandler = new AddScreenPopupEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _addScreenPopUpEventHandler.HandleOnLoad;
            btnAdd.Click += _addScreenPopUpEventHandler.HandleOnAdd;
            btnCancel.Click += _addScreenPopUpEventHandler.HandleOnExit;
        }
    }
}
