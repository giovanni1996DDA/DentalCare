using Dao;
using Logic.Exceptions;
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
using UI.NonProfessional.EventHandlers;
using UI.Perofessional;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.NonProfessional
{
    public partial class NonProfessionalLayoutForm : MaterialForm
    {
        private MainTabCtrlEventHandler _tabEventHandler;
        public NonProfessionalLayoutForm()
        {
            InitializeComponent();


            User currentUser = SessionManagerFacade.GetLoggedUser();
            this.Text += $"Bienvenido {currentUser.Nombre}";
        }

        public NonProfessionalLayoutForm(List<TabPage> tabs)
        {
            InitializeComponent();

            InitializeTabControls(tabs);

            User currentUser = SessionManagerFacade.GetLoggedUser();
            this.Text += $"Bienvenido {currentUser.Nombre}";


        }
        private void NonProfessionalLayoutForm_Load(object sender, EventArgs e)
        {

        }
        private void InitializeTabControls(List<TabPage> tabs)
        {

            TabPage dummy = new TabPage("Dummy");

            TabCtrlMain.TabPages.Add(dummy);

            foreach (TabPage tab in tabs)
            {
                TabCtrlMain.TabPages.Add(tab);
            }

            _tabEventHandler = new MainTabCtrlEventHandler(TabCtrlMain);

            TabCtrlMain.SelectedIndexChanged += _tabEventHandler.OnTabChanged;
        }
    }
}
