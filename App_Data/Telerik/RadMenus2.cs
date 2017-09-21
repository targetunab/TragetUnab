using Telerik.Web.UI;

namespace Telerik.Web.UI
{

    public class RadMenu2 : RadMenu
    {

        public RadMenu2() : base()
        {
            this.Skin = "Web20";
            this.Attributes.Add("z-index", "2900"); 
        }
    }
}