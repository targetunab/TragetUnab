using System.IO;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System;

namespace Telerik.Web.UI
{

    public class RadPanelBar2 : RadPanelBar
    {
        public RadPanelBar2() : base()
        {
            this.Skin = "Office2007";
            this.EnableEmbeddedSkins = true;           
            this.Width = Unit.Percentage(100);
        }

    }

   
}
