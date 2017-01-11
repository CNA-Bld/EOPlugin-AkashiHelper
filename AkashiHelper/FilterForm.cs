using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectronicObserver.Data;

namespace AkashiHelper
{
	public partial class FilterForm : Form
	{
		private AkashiHelper plugin;
		private ToolForm toolForm;
		private List<int> improvableEquipments;

		public FilterForm(List<int> improvableEquipments, ToolForm toolForm, AkashiHelper plugin)
		{
			InitializeComponent();

			this.plugin = plugin;
			this.toolForm = toolForm;
			this.improvableEquipments = improvableEquipments;
		}

		private void FilterForm_Load(object sender, EventArgs e)
		{
			checkedListBox.DisplayMember = "Name";
			foreach (int i in improvableEquipments)
			{
				checkedListBox.Items.Add(KCDatabase.Instance.MasterEquipments[i], !plugin.settings.filteredEquipmentIds.Contains(i));
			}
		}

		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox.Items.Count; i++)
			{
				checkedListBox.SetItemChecked(i, true);
			}
		}

		private void buttonUnselectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox.Items.Count; i++)
			{
				checkedListBox.SetItemChecked(i, false);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			plugin.settings.filteredEquipmentIds =
				Enumerable.Range(0, checkedListBox.Items.Count)
					.Where(i => !checkedListBox.GetItemChecked(i))
					.Select(i => checkedListBox.Items[i])
					.Cast<EquipmentDataMaster>()
					.Select(i => i.EquipmentID)
					.ToList();
			plugin.SaveSettings();
			toolForm.RefreshData();
			Close();
		}
	}
}
