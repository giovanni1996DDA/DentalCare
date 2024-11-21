using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.Generic.EventHandlers
{
    internal class IdiomasEventHandler : EventHandler
    {
        private MaterialComboBox cbxIdiomas;
        public IdiomasEventHandler(Form form)
        {
            _form = form;


            cbxIdiomas = (MaterialComboBox)FormHelpers.FindControl(_form, "cbxIdiomas");
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            FormHelpers.TranslateControls(_form);

            try
            {
                List<LanguageItem> laguages = LanguageFacade.GetLanguages();

                cbxIdiomas.DisplayMember = "DisplayName";
                cbxIdiomas.ValueMember = "Value";
                cbxIdiomas.DataSource = laguages;

                cbxIdiomas.SelectedValue = LanguageFacade.GetCurrentLanguage();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            if (cbxIdiomas.SelectedValue.ToString() == LanguageFacade.GetCurrentLanguage()) return;

            LanguageFacade.SetCurrentLanguage(cbxIdiomas.SelectedValue.ToString());

            //FormHelpers.TranslateControls(_form);
        }

        public override void HandleOnShowPassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnVisualize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
