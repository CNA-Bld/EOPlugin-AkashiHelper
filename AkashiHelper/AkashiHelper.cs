using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codeplex.Data;

namespace AkashiHelper
{
    public class AkashiHelper : ElectronicObserver.Window.Plugins.DialogPlugin
    {
		private const string PLUGIN_SETTINGS = @"Settings\AkashiHelper.json";
		public Settings settings;

		public AkashiHelper()
		{
			settings = LoadSettings();
		}

		public override string MenuTitle => "AkashiHelper";

	    public override Form GetToolWindow()
	    {
		    return new ToolForm(this);
	    }

	    private static Settings LoadSettings()
	    {
		    if (File.Exists(PLUGIN_SETTINGS))
			    return DynamicJson.Parse(File.ReadAllText(PLUGIN_SETTINGS)).Deserialize<Settings>();
		    else
				return new Settings();
	    }

	    public void SaveSettings()
	    {
		    if (settings == null)
				settings = new Settings();
			File.WriteAllText(PLUGIN_SETTINGS, DynamicJson.Serialize(settings));
	    }
    }
}
