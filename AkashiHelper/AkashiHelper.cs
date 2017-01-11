using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkashiHelper
{
    public class AkashiHelper : ElectronicObserver.Window.Plugins.DialogPlugin
    {
	    public override string MenuTitle => "AkashiHelper";

	    public override Form GetToolWindow()
	    {
		    return new ToolForm();
	    }
    }
}
