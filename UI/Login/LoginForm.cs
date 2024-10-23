using Dao;
using Logic;
using Logic.Exceptions;
using MaterialSkin;
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic;
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
using UI.Login.EventHandler;
using UI.NonProfessional;
using UI.NonProfessional.EventHandlers.Pacientes;
using UI.Perofessional;
using static MaterialSkin.MaterialItemCollection;
using Screen = Services.Domain.Screen;

namespace UI
{
    public partial class LoginForm : Form
    {
        private LoginEventHandler _eventHandler;
        public LoginForm()
        {
            InitializeComponent();

            _eventHandler = new LoginEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            btnLogin.Click += _eventHandler.HandleOnLogin;
            chkShowPassword.CheckedChanged += _eventHandler.HandleShowPassword;
            btnExit.Click += _eventHandler.HandleExit;
        }
    }
}
