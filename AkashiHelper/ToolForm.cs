using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codeplex.Data;
using ElectronicObserver.Data;
using ElectronicObserver.Utility;

namespace AkashiHelper
{
	public partial class ToolForm : Form
	{
		private bool ready = false;
		private static string JSON_PATH = @"Data\slotitem.json";
		private static Uri JSON_URL = new Uri("https://kcwikizh.github.io/kcdata/slotitem/all.json");
		private dynamic json;
		private AkashiHelper plugin;
		private List<int> ImprovableEquipments = new List<int>();

		public ToolForm(AkashiHelper plugin)
		{
			InitializeComponent();
			this.plugin = plugin;
		}

		private void ToolForm_Load(object sender, EventArgs e)
		{
			if (!isKCDBReady())
			{
				MessageBox.Show("KCDatabase is not ready yet. Please start the game first.");
				Close();
			}

			DayOfWeek today = (DateTime.UtcNow + new TimeSpan(9, 0, 0)).DayOfWeek;
			var weekDays = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
				.Select(dow => new { Value = dow, Text = dow == today ? dow.ToString() + " (Today)" : dow.ToString() })
				.ToList();
			comboBoxWeekday.DataSource = weekDays;
			comboBoxWeekday.DisplayMember = "Text";
			comboBoxWeekday.ValueMember = "Value";
			comboBoxWeekday.Refresh();
			comboBoxWeekday.SelectedValue = today;

			dataGridView.Columns.Add("Icon", "");
			dataGridView.Columns.Add("Equipment", "装備");
			dataGridView.Columns.Add("Progress", "改修値");
			dataGridView.Columns.Add("ModdingMaterial", "改修");
			dataGridView.Columns.Add("DevelopmentMaterial", "開発");
			dataGridView.Columns.Add("EquipmentNeeded", "消費装備");
			dataGridView.Columns.Add("Ship", "二番艦");
			dataGridView.Columns.Add("Refresh", "⇒");

			loadData();
			RefreshData();
		}

		private void loadData()
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

				ready = true;
			}
		}

		private void updateData()
		{
			ready = false;
			buttonUpdate.Enabled = false;
			buttonUpdate.Text = "Updating...";
			WebClient client = new WebClient();
			client.Encoding = Encoding.UTF8;
			client.DownloadFileCompleted += ClientOnDownloadFileCompleted;
			client.DownloadFileAsync(JSON_URL, JSON_PATH);
		}

		private void ClientOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
		{
			buttonUpdate.Enabled = true;
			buttonUpdate.Text = "Update Data";

			if (asyncCompletedEventArgs.Error != null)
			{
				ErrorReporter.SendErrorReport(asyncCompletedEventArgs.Error, "Error when updating data.");
				return;
			}

			loadData();
			if (ready)
			{
				MessageBox.Show("Updated.");
				RefreshData();
			}
			else
			{
				MessageBox.Show("Failed?");
			}
		}

		public void RefreshData()
		{
			if (!ready || !isKCDBReady())
				return;

			dataGridView.Rows.Clear();

			foreach (var equipment in json)
			{
				var improvements = equipment["improvement"];
				if (!plugin.settings.filteredEquipmentIds.Contains((int) equipment["id"]) && improvements != null)
				{
					foreach (var improvement in improvements)
					{
						var thisDay = improvement["day"][(int) comboBoxWeekday.SelectedValue];
						if (!thisDay.Equals(false))
						{
							var upgrade = improvement["upgrade"];

							var dataGridViewRow = new DataGridViewRow();
							dataGridViewRow.Cells.Add(new DataGridViewImageCell()
							{
								Value = ElectronicObserver.Resource.ResourceManager.Instance.Equipments.Images[(int) equipment["type"][3]]
							});
							dataGridViewRow.Cells.Add(textToCell(equipment["name"]));
							dataGridViewRow.Cells.Add(textToCell(upgrade == null ? "初期\n★6" : "初期\n★6\n★max"));

							List<string> modKitStrings = new List<string>();
							List<string> devKitStrings = new List<string>();
							foreach (var temp in improvement["consume"]["useitem"])
								foreach (var thisItem in temp)
									if ((int) thisItem["id"] == 4)
										modKitStrings.Add(generateKitUsage(thisItem["amount"]));
									else if ((int)thisItem["id"] == 3)
										devKitStrings.Add(generateKitUsage(thisItem["amount"]));
							if (upgrade != null)
								foreach (var thisItem in upgrade["consume"]["useitem"])
									if ((int)thisItem["id"] == 4)
										modKitStrings.Add(generateKitUsage(thisItem["amount"]));
									else if ((int)thisItem["id"] == 3)
										devKitStrings.Add(generateKitUsage(thisItem["amount"]));
							dataGridViewRow.Cells.Add(textToCell(string.Join("\n", modKitStrings)));
							dataGridViewRow.Cells.Add(textToCell(string.Join("\n", devKitStrings)));

							List<string> slotitemStrings = new List<string>();
							foreach (var thisStep in improvement["consume"]["slotitem"])
								slotitemStrings.Add(generateSlotItemUsage(thisStep));
							if (upgrade != null)
								slotitemStrings.Add(generateSlotItemUsage(upgrade["consume"]["slotitem"]));
							dataGridViewRow.Cells.Add(textToCell(string.Join("\n", slotitemStrings)));

							if (thisDay.Equals(true))
								dataGridViewRow.Cells.Add(textToCell("-"));
							else
							{
								List<string> shipStrings = new List<string>();
								foreach (var temp in thisDay)
									shipStrings.Add(getShipName(temp["ship_id"]));
								dataGridViewRow.Cells.Add(textToCell(string.Join("\n", shipStrings)));
							}

							if (upgrade != null)
								dataGridViewRow.Cells.Add(textToCell(getEquipmentName(upgrade["id"])));
							else
								dataGridViewRow.Cells.Add(textToCell(""));

							dataGridView.Rows.Add(dataGridViewRow);
						}
					}
				}
			}
		}

		private string getEquipmentName(dynamic id)
		{
			return KCDatabase.Instance.MasterEquipments[(int) id].Name;
		}

		private string getShipName(dynamic id)
		{
			return KCDatabase.Instance.MasterShips[(int) id].Name;
		}

		private string generateKitUsage(dynamic data)
		{
			return string.Format("{0}/{1}", data[0], data[1]);
		}

		private string generateSlotItemUsage(dynamic data)
		{
			return data == null ? "-" : string.Format("{0}× {1}", data["amount"], getEquipmentName(data["id"]));
		}

		private bool isKCDBReady()
		{
			return (KCDatabase.Instance.MasterEquipments[1] != null);
		}

		private DataGridViewTextBoxCell textToCell(string s)
		{
			return new DataGridViewTextBoxCell()
			{
				Value = s,
				Style = new DataGridViewCellStyle()
				{
					WrapMode = s.Contains("\n") ? DataGridViewTriState.True : DataGridViewTriState.False
				}
			};
		}

		private void listView_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void comboBoxWeekday_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ready)
				RefreshData();
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			updateData();
		}

		private void linkLabelKCWiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://kcwikizh.github.io/kcdata/");
		}

		private void buttonFilter_Click(object sender, EventArgs e)
		{
			if (ready)
				new FilterForm(ImprovableEquipments, this, plugin).Show();
		}
	}
}
