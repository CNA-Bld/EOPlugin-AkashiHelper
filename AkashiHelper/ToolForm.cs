﻿using System;
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
		private bool ready;
		private AkashiHelper plugin;

		public ToolForm(AkashiHelper plugin)
		{
			InitializeComponent();
			this.plugin = plugin;
		}

		private void AlertAndClose()
		{
			MessageBox.Show("KCDatabase is not ready yet. Please start the game first.");
			Close();
		}

		private void ToolForm_Load(object sender, EventArgs e)
		{
			if (!plugin.isKCDBReady)
			{
				AlertAndClose();
				return;
			}

			DayOfWeek today = (DateTime.UtcNow + new TimeSpan(9, 0, 0)).DayOfWeek;
			var weekDays = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
				.Select(dow => new { Value = (int) dow, Text = dow == today ? dow.ToString() + " (Today)" : dow.ToString() })
				.ToList();
			weekDays.Add(new { Value = -1, Text = "All" });
			comboBoxWeekday.DataSource = weekDays;
			comboBoxWeekday.DisplayMember = "Text";
			comboBoxWeekday.ValueMember = "Value";
			comboBoxWeekday.Refresh();
			comboBoxWeekday.SelectedValue = (int) today;

			dataGridView.Columns.Add("Icon", "");
			dataGridView.Columns.Add("Equipment", "装備");
			dataGridView.Columns.Add("Progress", "改修値");
			dataGridView.Columns.Add("ModdingMaterial", "改修");
			dataGridView.Columns.Add("DevelopmentMaterial", "開発");
			dataGridView.Columns.Add("EquipmentNeeded", "消費装備");
			dataGridView.Columns.Add("Ship", "二番艦");
			dataGridView.Columns.Add("Refresh", "⇒");

			checkBoxFilterByAvailability.Checked = plugin.settings.filterByAvailability;

			ready = plugin.json != null;
			RefreshData();
		}


		private void updateData()
		{
			ready = false;
			buttonUpdate.Enabled = false;
			buttonUpdate.Text = "Updating...";
			plugin.UpdateData(OnUpdated);	
		}

		private void OnUpdated()
		{
			buttonUpdate.Enabled = true;
			buttonUpdate.Text = "Update Data";
			ready = plugin.json != null;
			RefreshData();
		}

		public void RefreshData()
		{
			if (!ready)
				return;

			dataGridView.Rows.Clear();
			var selectedDay = (int) comboBoxWeekday.SelectedValue;

			Dictionary<int, List<DataGridViewRow>> dictionary = new Dictionary<int, List<DataGridViewRow>>();

			foreach (var equipment in plugin.json)
			{
				if (plugin.settings.filteredEquipmentIds.Contains((int) equipment.id))
					continue;

				var holdingEquipments = KCDatabase.Instance.Equipments.Values.Where(i => i.EquipmentID == (int) equipment.id).ToList();
				
				if (plugin.settings.filterByAvailability)
					if (holdingEquipments.Count == 0)
						continue;

				var tooltipString = string.Join("\n", holdingEquipments.GroupBy(i => i.Level).OrderBy(g => g.Key).Select(group => string.Format("★{0} ×{1}", group.Key, group.Count())));

				var improvements = equipment.improvement;
				if (improvements == null)
					continue;

				int equipmentType = (int) equipment.type[3];
				var image = ElectronicObserver.Resource.ResourceManager.Instance.Equipments.Images[equipmentType];

				foreach (var improvement in improvements)
				{
					dynamic thisDay = true;
					if (selectedDay != -1)
					{
						thisDay = improvement.day[selectedDay];
						if (thisDay.Equals(false))
							continue;
					}

					var upgrade = improvement.upgrade;

					var dataGridViewRow = new DataGridViewRow();
					dataGridViewRow.Cells.Add(new DataGridViewImageCell()
					{
						Value = image
					});

					DataGridViewCell nameCell = textToCell(equipment.name);
					nameCell.ToolTipText = tooltipString;
					dataGridViewRow.Cells.Add(nameCell);

					dataGridViewRow.Cells.Add(textToCell(upgrade == null ? "初期\n★6" : "初期\n★6\n★max"));

					List<string> modKitStrings = new List<string>();
					List<string> devKitStrings = new List<string>();
					foreach (var temp in improvement.consume.useitem)
						foreach (var thisItem in temp)
							if ((int) thisItem.id == 4)
								modKitStrings.Add(generateKitUsage(thisItem));
							else if ((int)thisItem.id == 3)
								devKitStrings.Add(generateKitUsage(thisItem));
					if (upgrade != null)
						foreach (var thisItem in upgrade.consume.useitem)
							if ((int)thisItem.id == 4)
								modKitStrings.Add(generateKitUsage(thisItem));
							else if ((int)thisItem.id == 3)
								devKitStrings.Add(generateKitUsage(thisItem));
					dataGridViewRow.Cells.Add(textToCell(string.Join("\n", modKitStrings)));
					dataGridViewRow.Cells.Add(textToCell(string.Join("\n", devKitStrings)));

					List<string> slotitemStrings = new List<string>();
					List<int> slotitemIds = new List<int>();
					foreach (var thisStep in improvement.consume.slotitem)
					{
						slotitemStrings.Add(generateSlotItemUsage(thisStep));
						if (thisStep != null)
							slotitemIds.Add((int) thisStep.id);
					}
					if (upgrade != null)
					{
						var thisStep = upgrade.consume.slotitem;
						slotitemStrings.Add(generateSlotItemUsage(thisStep));
						if (thisStep != null)
							slotitemIds.Add((int)thisStep.id);
					}
					var slotItemCell = textToCell(string.Join("\n", slotitemStrings));
					slotItemCell.ToolTipText = string.Join("\n", slotitemIds.Distinct().Select(generateSlotItemCount));
					dataGridViewRow.Cells.Add(slotItemCell);

					var shipString = string.Join("\n", generateShipStrings(thisDay));
					var shipCell = textToCell(shipString);
					shipCell.ToolTipText = string.Join("\n", 
						Enum.GetValues(typeof(DayOfWeek))
							.Cast<DayOfWeek>()
							.Where(d => !improvement.day[(int) d].Equals(false))
							.Select(d => string.Format("{0} ({1})", d.ToString(),
													   string.Join(", ", generateShipStrings(improvement.day[(int) d])))));
					dataGridViewRow.Cells.Add(shipCell);

					if (upgrade != null)
						dataGridViewRow.Cells.Add(textToCell(getEquipmentName(upgrade.id)));
					else
						dataGridViewRow.Cells.Add(textToCell(""));

					if (!dictionary.ContainsKey(equipmentType))
					{
						dictionary[equipmentType] = new List<DataGridViewRow>();
					}
					dictionary[equipmentType].Add(dataGridViewRow);
				}
			}

			dataGridView.Rows.AddRange(dictionary.Keys.OrderBy(i => i).SelectMany(i => dictionary[i]).ToArray());

			foreach (DataGridViewColumn column in dataGridView.Columns)
			{
				column.Width = 200;
			}
			dataGridView.AutoResizeColumns();
		}

		private string getEquipmentName(dynamic id)
		{
			try
			{
				return KCDatabase.Instance.MasterEquipments[(int)id].Name;
			}
			catch (NullReferenceException)
			{
				AlertAndClose();
				return null;
			}
		}

		private string getShipName(dynamic id)
		{
			try
			{
				return KCDatabase.Instance.MasterShips[(int)id].Name;
			}
			catch (NullReferenceException)
			{
				AlertAndClose();
				return null;
			}
		}

		private string generateKitUsage(dynamic data)
		{
			return string.Format("{0}/{1}", data.amount[0], data.amount[1]);
		}

		private string generateSlotItemUsage(dynamic data)
		{
			return data == null ? "-" : string.Format("{0}× {1}", data.amount, getEquipmentName(data.id));
		}

		private string generateSlotItemCount(int id)
		{
			var items = KCDatabase.Instance.Equipments.Values.Where(i => i.EquipmentID == id).Where(i => i.Level == 0);
			return string.Format("{0} ×{1} +{2} Locked", getEquipmentName(id), items.Count(i => !i.IsLocked), items.Count(i => i.IsLocked));
		}

		private List<string> generateShipStrings(dynamic data)
		{
			if (data.Equals(true))
				return new List<string>(new[] {"-"});
			List<string> shipStrings = new List<string>();
			foreach (var temp in data)
				shipStrings.Add(getShipName(temp.ship_id));
			return shipStrings;
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
				new FilterForm(this, plugin).Show();
		}

		private void checkBoxFilterByAvailability_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = plugin.settings.filterByAvailability != checkBoxFilterByAvailability.Checked;
			if (flag)
			{
				plugin.settings.filterByAvailability = checkBoxFilterByAvailability.Checked;
				RefreshData();
			}
		}

		private void ToolForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			plugin.SaveSettings();
		}
	}
}
