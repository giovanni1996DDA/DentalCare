using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Perofessional
{
    public partial class ProfessionalLayoutForm : MaterialForm
    {
        public ProfessionalLayoutForm()
        {
            InitializeComponent();

            User currentUser = SessionManagerFacade.GetLoggedUser();
            this.Text += $"Bienvenido {currentUser.Nombre}";
        }
        private void ProfessionalLayoutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
