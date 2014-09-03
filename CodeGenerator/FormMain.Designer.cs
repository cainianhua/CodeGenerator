namespace CodeGenerator
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDbServer = new System.Windows.Forms.TextBox();
			this.dbComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.TableId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SingularName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ModifiedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnT1GenerateAll = new System.Windows.Forms.Button();
			this.btnT1GenerateSQL = new System.Windows.Forms.Button();
			this.connectButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtNamespace = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
			this.menuStrip1.Size = new System.Drawing.Size(727, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.connectToolStripMenuItem.Text = "Connect...";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutXToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutXToolStripMenuItem
			// 
			this.aboutXToolStripMenuItem.Name = "aboutXToolStripMenuItem";
			this.aboutXToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.aboutXToolStripMenuItem.Text = "About X";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 518);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(727, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.AutoSize = false;
			this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(300, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.AutoSize = false;
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(250, 16);
			this.toolStripProgressBar1.Visible = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(727, 494);
			this.panel1.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(727, 494);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtDbServer);
			this.groupBox1.Controls.Add(this.dbComboBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 2);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(721, 74);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(23, 17);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(80, 17);
			this.radioButton1.TabIndex = 7;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "SQL Server";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(121, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Database Name:";
			// 
			// txtDbServer
			// 
			this.txtDbServer.Location = new System.Drawing.Point(229, 16);
			this.txtDbServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtDbServer.Name = "txtDbServer";
			this.txtDbServer.Size = new System.Drawing.Size(483, 20);
			this.txtDbServer.TabIndex = 1;
			this.txtDbServer.Text = "(local)";
			// 
			// dbComboBox
			// 
			this.dbComboBox.FormattingEnabled = true;
			this.dbComboBox.Location = new System.Drawing.Point(229, 42);
			this.dbComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dbComboBox.Name = "dbComboBox";
			this.dbComboBox.Size = new System.Drawing.Size(483, 21);
			this.dbComboBox.TabIndex = 2;
			this.dbComboBox.SelectedIndexChanged += new System.EventHandler(this.dbComboBox_SelectedIndexChanged);
			this.dbComboBox.Click += new System.EventHandler(this.dbComboBox_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(121, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Server Name:";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 140);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(721, 352);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dataGridView1);
			this.tabPage1.Controls.Add(this.flowLayoutPanel1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
			this.tabPage1.Size = new System.Drawing.Size(713, 326);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "User Tables / Views";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.TableId,
            this.TableName,
            this.SingularName,
            this.CreatedDate,
            this.ModifiedDate});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(1, 1);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(711, 296);
			this.dataGridView1.TabIndex = 1;
			// 
			// Selected
			// 
			this.Selected.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Selected.Frozen = true;
			this.Selected.HeaderText = "Selected";
			this.Selected.Name = "Selected";
			this.Selected.Width = 50;
			// 
			// TableId
			// 
			this.TableId.DataPropertyName = "TableId";
			this.TableId.HeaderText = "Table Id";
			this.TableId.Name = "TableId";
			this.TableId.Visible = false;
			// 
			// TableName
			// 
			this.TableName.DataPropertyName = "Name";
			this.TableName.HeaderText = "Table Name";
			this.TableName.MinimumWidth = 100;
			this.TableName.Name = "TableName";
			this.TableName.ReadOnly = true;
			this.TableName.Width = 200;
			// 
			// SingularName
			// 
			this.SingularName.DataPropertyName = "NameS";
			this.SingularName.HeaderText = "Singular Name";
			this.SingularName.MinimumWidth = 100;
			this.SingularName.Name = "SingularName";
			this.SingularName.ReadOnly = true;
			this.SingularName.Width = 200;
			// 
			// CreatedDate
			// 
			this.CreatedDate.DataPropertyName = "CreatedDate";
			this.CreatedDate.HeaderText = "Created Date";
			this.CreatedDate.MinimumWidth = 50;
			this.CreatedDate.Name = "CreatedDate";
			// 
			// ModifiedDate
			// 
			this.ModifiedDate.DataPropertyName = "ModifiedDate";
			this.ModifiedDate.HeaderText = "Modified Date";
			this.ModifiedDate.MinimumWidth = 50;
			this.ModifiedDate.Name = "ModifiedDate";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnT1GenerateAll);
			this.flowLayoutPanel1.Controls.Add(this.btnT1GenerateSQL);
			this.flowLayoutPanel1.Controls.Add(this.connectButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 297);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(711, 28);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// btnT1GenerateAll
			// 
			this.btnT1GenerateAll.Enabled = false;
			this.btnT1GenerateAll.Location = new System.Drawing.Point(608, 2);
			this.btnT1GenerateAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnT1GenerateAll.Name = "btnT1GenerateAll";
			this.btnT1GenerateAll.Size = new System.Drawing.Size(100, 24);
			this.btnT1GenerateAll.TabIndex = 5;
			this.btnT1GenerateAll.Text = "Generate All";
			this.btnT1GenerateAll.UseVisualStyleBackColor = true;
			this.btnT1GenerateAll.Click += new System.EventHandler(this.btnT1GenerateAll_Click);
			// 
			// btnT1GenerateSQL
			// 
			this.btnT1GenerateSQL.Enabled = false;
			this.btnT1GenerateSQL.Location = new System.Drawing.Point(503, 2);
			this.btnT1GenerateSQL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnT1GenerateSQL.Name = "btnT1GenerateSQL";
			this.btnT1GenerateSQL.Size = new System.Drawing.Size(99, 24);
			this.btnT1GenerateSQL.TabIndex = 4;
			this.btnT1GenerateSQL.Text = "Generate SQL";
			this.btnT1GenerateSQL.UseVisualStyleBackColor = true;
			this.btnT1GenerateSQL.Visible = false;
			this.btnT1GenerateSQL.Click += new System.EventHandler(this.btnT1GenerateSQL_Click);
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(439, 2);
			this.connectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(58, 24);
			this.connectButton.TabIndex = 0;
			this.connectButton.Text = "Query";
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.queryButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtNamespace);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 81);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(721, 54);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Builder Properties";
			// 
			// txtNamespace
			// 
			this.txtNamespace.Location = new System.Drawing.Point(122, 22);
			this.txtNamespace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtNamespace.Name = "txtNamespace";
			this.txtNamespace.Size = new System.Drawing.Size(590, 20);
			this.txtNamespace.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Namespace Prefix:";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(727, 540);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new System.Drawing.Size(600, 578);
			this.Name = "FormMain";
			this.Text = "Code Generator";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutXToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Button btnT1GenerateSQL;
		private System.Windows.Forms.Button btnT1GenerateAll;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDbServer;
		private System.Windows.Forms.ComboBox dbComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtNamespace;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
		private System.Windows.Forms.DataGridViewTextBoxColumn TableId;
		private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
		private System.Windows.Forms.DataGridViewTextBoxColumn SingularName;
		private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedDate;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
	}
}