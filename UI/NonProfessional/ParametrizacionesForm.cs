using Services.Domain;
using Services.Facade;
using Services.Logic.Exceptions;
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
using UI.NonProfessional.EventHandlers.Pacientes;
using UI.NonProfessional.EventHandlers.Parametrizaciones;

namespace UI.NonProfessional
{
    public partial class ParametrizacionesForm: Form
    {
        private TabCtrlEventHandler _tabEventHandler;
        private ParametrizacionesFormEventHandler _ParametrizacionesFormEventHandler;
        public ParametrizacionesForm()
        {
            InitializeComponent();

            PopulateTabControl();

            _ParametrizacionesFormEventHandler = new ParametrizacionesFormEventHandler(this);
            _tabEventHandler = new TabCtrlEventHandler(tabCtrlParametrizaciones);

            InitializeHandlers();

        }

        private void InitializeHandlers()
        {
            this.Load += _ParametrizacionesFormEventHandler.HandleOnLoad;
            tabCtrlParametrizaciones.SelectedIndexChanged += _tabEventHandler.HandleOnTabChanged;
        }
        private void PopulateTabControl()
        {
            User loggedUser = SessionManagerFacade.GetLoggedUser();


            //Si tiene algun permiso de roles, mmuestro la pantalla de roles
            if (UserFacade.GetPermisos(loggedUser.Accesos).Any(p => p.Modulo.HasValue && p.Modulo == (int)SystemModulesEnum.Roles))
            {
                tabCtrlParametrizaciones.TabPages.Add(new TabPage()
                {
                    Name = "GestionRoles",
                    Text = "Roles"
                });
                tabCtrlParametrizaciones.TabPages.Add(new TabPage()
                {
                    Name = "GestionPermisos",
                    Text = "Permisos"
                });
            }
            try
            {

                foreach (Permiso permiso in UserFacade.GetPermisos(loggedUser.Accesos))
                {
                    if (permiso.Modulo != (int)SystemModulesEnum.Roles)
                        continue;

                    Services.Domain.Screen protoScreen = new Services.Domain.Screen()
                    {
                        Acceso = permiso.Id,
                    };

                    List<Services.Domain.Screen> screens = ScreenFacade.Get(protoScreen);

                    foreach (var scr in screens)
                    {
                        if (scr.ScreenName != null)
                            tabCtrlParametrizaciones.TabPages.Add(new TabPage()
                            {
                                Name = scr.ScreenName,
                                Text = scr.OptionName
                            });
                    }
                }
            }
            catch (NoScreensFoundException ex)
            {
                if (tabCtrlParametrizaciones.TabPages.Count == 0)
                {
                    MessageBox.Show("No existen permisos para este módulo.", "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
