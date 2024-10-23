using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helpers
{
    public static class FormHelpers
    {
        public static void ClearControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
                    continue;
                }

                if (ctrl is MaterialTextBox)
                {
                    ((MaterialTextBox)ctrl).Clear();
                    continue;
                }

                if (ctrl is ComboBox)
                {
                    ComboBox cb = ctrl as ComboBox;
                    cb.SelectedIndex = cb.Items.Count > 0 ? 0 : cb.SelectedIndex;
                    continue;
                }

                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                    continue;
                }

                if (ctrl is RadioButton)
                {
                    ((RadioButton)ctrl).Checked = false;
                    continue;
                }

                if (ctrl.HasChildren)
                {
                    ClearControls(ctrl);
                }
            }
        }

        public static Control FindControl(Control parent, string controlName)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.Name == controlName)
                {
                    return child;
                }

                Control foundControl = FindControl(child, controlName);

                if (foundControl != null)
                {
                    return foundControl;
                }
            }
            return null;
        }

        public static DateTime ParseFecha(string fechaNacimientoText)
        {
            DateTime fechaNacimiento;

            DateTime.TryParseExact(fechaNacimientoText,
                                                    new[] { "ddMMyyyy", "dd/MM/yyyy" },
                                                    CultureInfo.InvariantCulture,
                                                    DateTimeStyles.None,
                                                    out fechaNacimiento);

            return fechaNacimiento;
        }

        public static void RefreshControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                
                ctrl.Invalidate();  
                ctrl.Update();      
                ctrl.Refresh();     

                if (ctrl.HasChildren)
                {
                    RefreshControls(ctrl);
                }
            }
        }
        public static void LoadFormInTab(TabPage tabPage)
        {
            Form formToLoad = null;

            try
            {
                // Construir el nombre del formulario a partir del nombre de la pestaña
                //string formName = $"UI.NonProfessional.{tabPage.Name}Form";
                string formName = FindFormByName($"{tabPage.Name}Form");
                Type formType = Type.GetType($"{formName}");

                if (formType != null)
                {
                    formToLoad = (Form)Activator.CreateInstance(formType);
                    formToLoad.TopLevel = false;
                    formToLoad.FormBorderStyle = FormBorderStyle.None;
                    formToLoad.Dock = DockStyle.Fill;
                    tabPage.Controls.Add(formToLoad);
                    formToLoad.Show();
                }
                else
                {
                    MessageBox.Show($"Formulario {formName} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}");
            }
        }

        private static string FindFormByName(string formName)
        {
            // Obtener todos los ensamblados cargados en el dominio de la aplicación
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Recorrer cada ensamblado y buscar el tipo que coincide con el nombre completo del formulario
            foreach (var assembly in assemblies)
            {
                if (assembly.IsDynamic)
                    continue;

                try
                {
                    var formType = assembly.GetTypes().FirstOrDefault(t =>
                        t.FullName != null && t.FullName.EndsWith(formName) && typeof(Form).IsAssignableFrom(t));

                    if (formType != null)
                    {
                        return formType.FullName;
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    // Manejar excepción si es necesario
                    Console.WriteLine(ex);
                }
            }

            // Si no encuentra el formulario, devolver null
            return null;
        }
    }
}
