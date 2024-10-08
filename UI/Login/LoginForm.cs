using Dao;
using Logic;
using Logic.Exceptions;
using MaterialSkin;
using MaterialSkin.Controls;
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
using UI.NonProfessional;
using UI.Perofessional;
using Screen = Services.Domain.Screen;

namespace UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            //MaterialSkinManager mngr = MaterialSkinManager.Instance;
            //mngr.AddFormToManage(this);
            //mngr.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //CenterSpecificControls(this);   
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUname.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Complete los campos obligatorios", "Error de consistencia.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (txtUname.Text == "")
                {
                    txtUname.Focus();
                    return;
                }

                if (txtPassword.Text == "")
                {
                    txtPassword.Focus();
                    return;
                }
            }

            User user = new User()
            {
                UserName = txtUname.Text,
                Password = txtPassword.Text,
            };

            try
            {
                Form nextForm = null;

                UserFacade.Login(user);

                User loggedUser = SessionManagerFacade.GetLoggedUser();

                List<TabPage> tabs = new List<TabPage>();

                //RECODATORIO
                //VOY A VERIFICAR QUE PANTALLAS TIENE EN BASE A SUS ROLES.
                //EN BASE A ESO DEFINO QUE OPCIONES CARGA EL SIGUIENTE FORM
                //ACORDATE PELOTUDO

                foreach (Rol rol in UserFacade.GetRoles(loggedUser.Accesos))
                {

                    Screen scr = new Screen()
                    {
                        rol = rol.Id,
                    };

                    scr = ScreenFacade.GetOne(scr);

                    if (scr.ScreenName != null)
                        tabs.Add(new TabPage() { Name = scr.ScreenName,
                                                 Text = scr.OptionName});
                }

                if (tabs.Count == 0) 
                {
                    MessageBox.Show("El usuario no posee ningún permiso para ver menús.", 
                                    "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Especialidad especialidad = EspecialidadService.Instance.GetOne(user);

                if (especialidad != null)
                    nextForm = new ProfessionalLayoutForm();
                else
                    nextForm = new NonProfessionalLayoutForm(tabs);

                this.Hide();

                nextForm.ShowDialog();
            }
            catch (NoUsersFoundException ex)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Password = !txtPassword.Password;
            txtPassword.Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CenterControl(Control control)
        {
            // Centro horizontalmente el control dentro del formulario
            int centerX = (this.ClientSize.Width - control.Width) / 2;
            control.Left = centerX;
        }

        private void CenterSpecificControls(Control parent)
        {
            // Recorrer todos los controles del formulario
            foreach (Control control in parent.Controls)
            {
                // Verificar si el nombre del control comienza con lbl, btn, txt o img
                if (control.Name.StartsWith("lbl") || control.Name.StartsWith("btn") ||
                    control.Name.StartsWith("txt") || control.Name.StartsWith("img"))
                {
                    CenterControl(control); // Centrar el control
                }

                // Si el control tiene hijos, recorrerlos también (para Paneles, GroupBoxes, etc.)
                if (control.HasChildren)
                {
                    CenterSpecificControls(control);
                }
            }
        }
    }
}
