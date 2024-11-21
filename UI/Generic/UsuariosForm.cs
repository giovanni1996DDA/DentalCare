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
using UI.Enums;
using UI.EventHandlers.Pacientes;
using UI.Generic.EventHandlers;

namespace UI.Generic
{
    public partial class UsuariosForm : Form
    {
        private TabCtrlEventHandler _tabEventHandler;

        private UsuariosFormEventHandler _UsuariosFormEventHandler;
        public UsuariosForm()
        {
            InitializeComponent();

            PopulateTabControl();

            _UsuariosFormEventHandler = new UsuariosFormEventHandler(this);
            _tabEventHandler = new TabCtrlEventHandler(tbcUsuarios);

            InitializeHandlers();
        }
        private void InitializeHandlers()
        {
            this.Load += _UsuariosFormEventHandler.HandleOnLoad;
            tbcUsuarios.SelectedIndexChanged += _tabEventHandler.HandleOnTabChanged;
        }
        public void PopulateTabControl()
        {
            User loggedUser = SessionManagerFacade.GetLoggedUser();

            foreach (Permiso permiso in UserFacade.GetPermisos(loggedUser.Accesos))
            {
                if (permiso.Modulo != (int)SystemModulesEnum.Usuarios)
                    continue;

                Services.Domain.Screen protoScreen = new Services.Domain.Screen()
                {
                    Acceso = permiso.Id,
                };

                List<Services.Domain.Screen> screens = ScreenFacade.Get(protoScreen);

                foreach (var scr in screens)
                {
                    if (scr.ScreenName != null)
                        tbcUsuarios.TabPages.Add(new TabPage()
                        {
                            Name = scr.ScreenName,
                            Text = scr.OptionName
                        });
                }
            }
        }
    }
}
