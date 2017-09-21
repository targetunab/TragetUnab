using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace Telerik.Web.UI
{

    public class RadWindow2 : RadWindow
    {

        public RadWindow2() : base()
        {
            
            //this.Skin = "Vista"; Behaviors
            
            this.EnableEmbeddedSkins = true;
            this.Modal = true;
            this.VisibleStatusbar = false;
            this.VisibleOnPageLoad = false;
            this.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Close | WindowBehaviors.Reload;

            

     
        }
    }

}