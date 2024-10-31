using Dao;
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
    public partial class AddEspecialidadesPopUp : Form
    {
        public bool Canceled { get; set; }
        public Especialidad? selectedEspecialidad { get; set; }

        private AddEspecialidadesPopUpEventHandler _addEspecialidadesPopUpEventHandler;
        public AddEspecialidadesPopUp()
        {
            InitializeComponent();

            _addEspecialidadesPopUpEventHandler = new AddEspecialidadesPopUpEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _addEspecialidadesPopUpEventHandler.HandleOnLoad;
            btnAdd.Click += _addEspecialidadesPopUpEventHandler.HandleOnAdd;
            btnCancel.Click += _addEspecialidadesPopUpEventHandler.HandleOnExit;
        }
    }
}
