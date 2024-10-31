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
using UI.NonProfessional.EventHandlers;

namespace UI.NonProfessional.TurnosForms
{
    public partial class FindProfesionalPopUp : Form
    {
        FindProfesionalPopUpEventHandler _eventHandler;
        public User SelectedProfessional { get; set; }
        public FindProfesionalPopUp(List<User> users)
        {
            InitializeComponent();

            _eventHandler = new FindProfesionalPopUpEventHandler(this, users);

            InitializeHandlers();
        }
        private void InitializeHandlers()
        {
            Load += _eventHandler.HandleOnLoad;
            btnCancel.Click += _eventHandler.HandleOnExit;
            btnSelect.Click += _eventHandler.HandleOnCreate;
        }
    }
}
