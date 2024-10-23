using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Enums;
using UI.Helpers;

namespace UI.NonProfessional.EventHandlers.Parametrizaciones.Roles
{
    public class GestionRolesEventHandler : EventHandler
    {
        private DataGridView dgvRol;
        private MaterialTextBox txtRol;
        private DataGridView dgvPermiso;



        public GestionRolesEventHandler(Form form)
        {
            _form = form;

            dgvRol = (DataGridView)FormHelpers.FindControl(_form, "dgvRol");
            txtRol = (MaterialTextBox)FormHelpers.FindControl(_form, "txtRol");
            dgvPermiso = (DataGridView)FormHelpers.FindControl(_form, "dgvPermiso");
        }
        public override void HandleExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleSaveChanges(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleVisualize(object sender, EventArgs e)
        {
            if (dgvPermiso.Rows.Count > 0)
                dgvPermiso.DataSource = null;

            if (dgvRol.Rows.Count > 0)
                dgvRol.DataSource = null;

            try
            {
                Rol rol = AccesoFacade.GetOne(new Rol()
                {
                    Nombre = txtRol.Text
                });

                List<Rol> chidlrenRoles = new List<Rol>();
                List<Permiso> chidlrenPermiso = new List<Permiso>();

                foreach (Acceso acc in rol.Accesos) 
                {
                    if(acc is Rol)
                        chidlrenRoles.Add((Rol) acc);

                    if (acc is Permiso)
                        chidlrenPermiso.Add((Permiso)acc);
                }

                if (chidlrenRoles.Count > 0)
                    FillDgvRol(chidlrenRoles);

                if (chidlrenPermiso.Count > 0)
                    fillDgvPermiso(chidlrenPermiso);

            }
            catch (NoRolesFoundException ex)
            {
                MessageBox.Show(ex.Message,
                        "Error en la búsqueda de roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                        "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillDgvRol(List<Rol> datasource)
        {
            dgvRol.DataSource = datasource;

            dgvRol.Columns["Id"].Visible = false;
            dgvRol.Columns["HasChildren"].Visible = false;
        }

        private void fillDgvPermiso(List<Permiso> datasource)
        {


            dgvPermiso.DataSource = datasource;

            dgvPermiso.Columns["Id"].Visible = false;
            dgvPermiso.Columns["HasChildren"].Visible = false;
            dgvPermiso.Columns["Modulo"].Visible = false;
            dgvPermiso.Columns["TipoPermiso"].Visible = false;

            if (!dgvPermiso.Columns.Contains("ModuloNombre"))
            {
                dgvPermiso.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ModuloNombre",
                    HeaderText = "Módulo"
                });
            }

            if (!dgvPermiso.Columns.Contains("TipoPermisoNombre"))
            {
                dgvPermiso.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TipoPermisoNombre",
                    HeaderText = "Tipo de Permiso"
                });
            }

            foreach (DataGridViewRow row in dgvPermiso.Rows)
            {
                Permiso boundPermiso = row.DataBoundItem as Permiso;

                string moduloNombre = Enum.GetName(typeof(SystemModulesEnum), boundPermiso.Modulo.Value) ?? "Desconocido";

                row.Cells["ModuloNombre"].Value = moduloNombre;

                string TipoPermisoNombre = Enum.GetName(typeof(TiposPermisoEnum), boundPermiso.TipoPermiso.Value) ?? "Desconocido";

                row.Cells["TipoPermisoNombre"].Value = TipoPermisoNombre;
            }
        }
    }
}
