using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace Telerik.Web.UI
{

    public class RadComboBox2 : RadComboBox
    {

        public RadComboBox2() : base()
        {
            this.Skin = "Vista";
            this.EnableEmbeddedSkins = true;

            this.Height = Unit.Pixel(160);
        }
    }

}
