namespace AkashiHelper
{
	partial class FilterForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSelectAll = new System.Windows.Forms.Button();
			this.buttonUnselectAll = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.checkedListBox = new System.Windows.Forms.CheckedListBox();
			this.label = new System.Windows.Forms.Label();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 5;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.Controls.Add(this.buttonSelectAll, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.buttonUnselectAll, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.buttonSave, 3, 2);
			this.tableLayoutPanel.Controls.Add(this.buttonCancel, 4, 2);
			this.tableLayoutPanel.Controls.Add(this.checkedListBox, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.label, 0, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(284, 261);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// buttonSelectAll
			// 
			this.buttonSelectAll.AutoSize = true;
			this.buttonSelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSelectAll.Location = new System.Drawing.Point(3, 235);
			this.buttonSelectAll.Name = "buttonSelectAll";
			this.buttonSelectAll.Size = new System.Drawing.Size(61, 23);
			this.buttonSelectAll.TabIndex = 5;
			this.buttonSelectAll.Text = "Select All";
			this.buttonSelectAll.UseVisualStyleBackColor = true;
			this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
			// 
			// buttonUnselectAll
			// 
			this.buttonUnselectAll.AutoSize = true;
			this.buttonUnselectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonUnselectAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonUnselectAll.Location = new System.Drawing.Point(70, 235);
			this.buttonUnselectAll.Name = "buttonUnselectAll";
			this.buttonUnselectAll.Size = new System.Drawing.Size(73, 23);
			this.buttonUnselectAll.TabIndex = 1;
			this.buttonUnselectAll.Text = "Unselect All";
			this.buttonUnselectAll.UseVisualStyleBackColor = true;
			this.buttonUnselectAll.Click += new System.EventHandler(this.buttonUnselectAll_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.AutoSize = true;
			this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSave.Location = new System.Drawing.Point(183, 235);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(42, 23);
			this.buttonSave.TabIndex = 2;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.AutoSize = true;
			this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonCancel.Location = new System.Drawing.Point(231, 235);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(50, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// checkedListBox
			// 
			this.checkedListBox.CheckOnClick = true;
			this.tableLayoutPanel.SetColumnSpan(this.checkedListBox, 5);
			this.checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkedListBox.FormattingEnabled = true;
			this.checkedListBox.Location = new System.Drawing.Point(3, 16);
			this.checkedListBox.MultiColumn = true;
			this.checkedListBox.Name = "checkedListBox";
			this.checkedListBox.Size = new System.Drawing.Size(278, 213);
			this.checkedListBox.TabIndex = 4;
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.label, 5);
			this.label.Location = new System.Drawing.Point(3, 0);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(152, 13);
			this.label.TabIndex = 6;
			this.label.Text = "Display only these equipments:";
			// 
			// FilterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "FilterForm";
			this.Text = "Filter";
			this.Load += new System.EventHandler(this.FilterForm_Load);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Button buttonUnselectAll;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.CheckedListBox checkedListBox;
		private System.Windows.Forms.Button buttonSelectAll;
		private System.Windows.Forms.Label label;
	}
}