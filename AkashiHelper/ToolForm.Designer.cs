namespace AkashiHelper
{
	partial class ToolForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxWeekday = new System.Windows.Forms.ComboBox();
			this.buttonFilter = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.linkLabelKCWiki = new System.Windows.Forms.LinkLabel();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 4;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.Controls.Add(this.comboBoxWeekday, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.buttonFilter, 2, 0);
			this.tableLayoutPanel.Controls.Add(this.buttonUpdate, 3, 0);
			this.tableLayoutPanel.Controls.Add(this.dataGridView, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.linkLabelKCWiki, 0, 2);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(584, 361);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// comboBoxWeekday
			// 
			this.comboBoxWeekday.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxWeekday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxWeekday.FormattingEnabled = true;
			this.comboBoxWeekday.Location = new System.Drawing.Point(3, 3);
			this.comboBoxWeekday.Name = "comboBoxWeekday";
			this.comboBoxWeekday.Size = new System.Drawing.Size(121, 21);
			this.comboBoxWeekday.TabIndex = 0;
			this.comboBoxWeekday.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeekday_SelectedIndexChanged);
			// 
			// buttonFilter
			// 
			this.buttonFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonFilter.Location = new System.Drawing.Point(422, 3);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new System.Drawing.Size(75, 23);
			this.buttonFilter.TabIndex = 1;
			this.buttonFilter.Text = "Filter...";
			this.buttonFilter.UseVisualStyleBackColor = true;
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.AutoSize = true;
			this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonUpdate.Location = new System.Drawing.Point(503, 3);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(78, 23);
			this.buttonUpdate.TabIndex = 2;
			this.buttonUpdate.Text = "Update Data";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableLayoutPanel.SetColumnSpan(this.dataGridView, 4);
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(3, 32);
			this.dataGridView.MultiSelect = false;
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(578, 313);
			this.dataGridView.TabIndex = 3;
			// 
			// linkLabelKCWiki
			// 
			this.linkLabelKCWiki.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.linkLabelKCWiki, 4);
			this.linkLabelKCWiki.Location = new System.Drawing.Point(3, 348);
			this.linkLabelKCWiki.Name = "linkLabelKCWiki";
			this.linkLabelKCWiki.Size = new System.Drawing.Size(135, 13);
			this.linkLabelKCWiki.TabIndex = 4;
			this.linkLabelKCWiki.TabStop = true;
			this.linkLabelKCWiki.Text = "Data from kcwikizh/kcdata";
			this.linkLabelKCWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelKCWiki_LinkClicked);
			// 
			// ToolForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "ToolForm";
			this.Text = "AkashiHelper";
			this.Load += new System.EventHandler(this.ToolForm_Load);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.ComboBox comboBoxWeekday;
		private System.Windows.Forms.Button buttonFilter;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.LinkLabel linkLabelKCWiki;
	}
}