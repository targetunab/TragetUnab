using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using AjaxControlToolkit;

namespace WebControls
{

    public class NumericBox2 : Telerik.Web.UI.RadNumericTextBox
    {

        public bool Lock
        {
            get { return Convert.ToBoolean(ViewState["Lock"]); }
            set { ViewState["Lock"] = value; }
        }


        private RequiredFieldValidator _Validator;
        public NumericBox2() : base()
        {

            this.Skin = "";
            this.EnableEmbeddedSkins = false;

            this.Width = Unit.Pixel(100);

            this.NumberFormat.DecimalDigits = 0;
            this.Style.Add("text-align", "right");

            this.MaxLength = 12;
            this.CssClass = "TextBox2";
        }

        protected override System.Web.UI.ControlCollection CreateControlCollection()
        {
            return new ControlCollection(this);
        }

        public string DisabledCssClass
        {
            get { return Convert.ToString(ViewState["DisabledCssClass"]); }
            set { ViewState["DisabledCssClass"] = value; }
        }

        private void RegisterIncludeScript(string ScriptName)
        {
            Type rstype = this.GetType();
            string rsname = Page.ClientScript.GetWebResourceUrl(rstype, ScriptName);
            if (!Page.ClientScript.IsClientScriptIncludeRegistered(rstype, ScriptName))
            {
                Page.ClientScript.RegisterClientScriptInclude(rstype, ScriptName, rsname);
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
        }

        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);
        }


        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            this.Attributes.Add("onfocus", "onfocusTexBox(" + this.ClientID + ", true)");
            this.Attributes.Add("onfocusout", "onfocusTexBox(" + this.ClientID + ", false)");
            

            this.EnsureChildControls();


            if (this.ReadOnly | this.Lock)
            {
                //writer.Write(string.Format("<span{0}>{1}</span>", (!string.IsNullOrEmpty(this.DisabledCssClass) ? " class='" + 
                //    this.DisabledCssClass + "'" : ""), Strings.FormatNumber(this.Value, this.NumberFormat.DecimalDigits)));
                //String.Format("{0:N0}", Int32.Parse(str));
                writer.Write(string.Format("<span{0}>{1}</span>", (!string.IsNullOrEmpty(this.DisabledCssClass) ? " class='" +
                    this.DisabledCssClass + "'" : ""), this.Value.ToString()));

                this.Visible = false;
                this.Style.Add("display", "none");

                base.Render(writer);
            }
            else
            {
                base.Render(writer);
            }

            if ((_Validator != null))
            {
                _Validator.RenderControl(writer);
            }

        }

        #region " Validator "

        /// <summary>
        /// Obtiene la instancia del control RequeredFieldValidator.
        /// </summary>
        [Browsable(true)]
        [Description("Obtiene la instancia del control RequeredFieldValidator.")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public RequiredFieldValidator RequiredValidator
        {
            get
            {
                if (_Validator == null)
                {
                    this.RequiredField = true;
                    AddRequiredFieldValidator();
                }
                return _Validator;
            }
        }

        public bool RequiredField
        {
            get
            {
                object o = ViewState["RequiredField"];
                return ((o != null) ? Convert.ToBoolean(o) : false);
            }
            set { ViewState["RequiredField"] = value; }
        }

        public string ValidationMessage
        {
            get
            {
                object o = ViewState["ValidationMessage"];
                return ((o != null) ? Convert.ToString(o) : "");
            }
            set { ViewState["ValidationMessage"] = value; }
        }

        public ValidatorDisplay ValidationDisplayMode
        {
            get
            {
                object o = ViewState["ValidationDisplayMode"];
                return ((o == null) ? ValidatorDisplay.Dynamic : (ValidatorDisplay)o);
            }
            set { ViewState["ValidationDisplayMode"] = value; }
        }

        private void AddRequiredFieldValidator()
        {
            _Validator = new RequiredFieldValidator();

            var _with1 = _Validator;

            _with1.ID = this.ID + "_validator";
            _with1.ControlToValidate = this.ID;
            _with1.EnableClientScript = true;
            _with1.Display = this.ValidationDisplayMode;

            if (!string.IsNullOrEmpty(this.ValidationText))
            {
                _with1.Text = this.ValidationText;
            }
            else
            {
                _with1.Text = "&nbsp;*";
            }

            _with1.ErrorMessage = this.ValidationMessage;

            if (this.ValidationGroup != string.Empty)
            {
                _with1.ValidationGroup = this.ValidationGroup;
            }


            base.Controls.Add(_Validator);

        }

        #endregion

    }


}
