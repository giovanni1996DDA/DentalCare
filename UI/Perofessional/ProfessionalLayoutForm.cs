using MaterialSkin;
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Perofessional_layout
{
    public partial class ProfessionalLayoutForm : MaterialForm
    {
        private static ProfessionalLayoutForm _Instance = new ProfessionalLayoutForm();

        public static ProfessionalLayoutForm Instance
        {
            get
            {
                return _Instance;
            }
        }
        private ProfessionalLayoutForm()
        {
            InitializeComponent();

            //User currentUser = SessionManagerFacade.GetLoggedUser();
            //this.Text += $"{ currentUser.Nombre }";

            this.Text += "pito";
        }
            private void ProfessionalLayoutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
