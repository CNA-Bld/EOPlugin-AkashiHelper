using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codeplex.Data;
using ElectronicObserver.Observer;
using ElectronicObserver.Utility;

namespace AkashiHelper
{
    public class AkashiHelper : ElectronicObserver.Window.Plugins.DialogPlugin
    {
		private const string PLUGIN_SETTINGS = @"Settings\AkashiHelper.json";
		private static string JSON_PATH = @"Data\slotitem.json";
		private static Uri JSON_URL = new Uri("https://kcwikizh.github.io/kcdata/slotitem/all.json");

		public Settings settings;
	    public dynamic json;
		public List<int> ImprovableEquipments = new List<int>();
		public bool isKCDBReady { get; private set; } = false;

		public override string Version { get { return "<BUILD_VERSION>"; } }

		public AkashiHelper()
		{
			settings = LoadSettings();
			LoadData();
			APIObserver.Instance["api_start2/getData"].ResponseReceived += OnResponseReceived;
		}

	    private void OnResponseReceived(string apiname, dynamic data)
	    {
		    isKCDBReady = true;
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

	    public void LoadData()
	    {
			if (!Directory.Exists("Data"))
				Directory.CreateDirectory("Data");
			if (File.Exists(JSON_PATH))
			{
				json = DynamicJson.Parse(File.ReadAllText(JSON_PATH));

				ImprovableEquipments.Clear();
				foreach (var equipment in json)
				{
					if (equipment["improvement"] != null)
						ImprovableEquipments.Add((int)equipment["id"]);
				}
			}
		}
		
	    public void UpdateData(Action action)
	    {
			WebClient client = new WebClient();
			client.Encoding = Encoding.UTF8;
			client.DownloadFileCompleted += (sender, e) =>
			{
				if (e.Error != null)
				{
					ErrorReporter.SendErrorReport(e.Error, "Error when updating data.");
					return;
				}

				LoadData();
				MessageBox.Show(json == null ? "Failed?" : "Updated.");

				action();
			};
			client.DownloadFileAsync(JSON_URL, JSON_PATH);
		}
		
    }
}
