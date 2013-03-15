namespace Weavver.Testing
{
     partial class TestingHarness
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
               this.components = new System.ComponentModel.Container();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
               this.dataGridView1 = new System.Windows.Forms.DataGridView();
               this.timerRefreshDataGridView = new System.Windows.Forms.Timer(this.components);
               this.RunAllTests = new System.Windows.Forms.LinkLabel();
               this.webBrowser1 = new System.Windows.Forms.WebBrowser();
               this.tbSearch = new System.Windows.Forms.TextBox();
               this.groupBox1 = new System.Windows.Forms.GroupBox();
               this.FailedCount = new System.Windows.Forms.Label();
               this.PassedCount = new System.Windows.Forms.Label();
               this.label2 = new System.Windows.Forms.Label();
               this.label1 = new System.Windows.Forms.Label();
               this.groupBox2 = new System.Windows.Forms.GroupBox();
               this.checkBox1 = new System.Windows.Forms.CheckBox();
               this.checkBox2 = new System.Windows.Forms.CheckBox();
               this.splitContainer1 = new System.Windows.Forms.SplitContainer();
               this.bSkipCleanUp = new System.Windows.Forms.CheckBox();
               this.RunAutomatically = new System.Windows.Forms.CheckBox();
               this.IsStagingTest = new System.Windows.Forms.DataGridViewCheckBoxColumn();
               this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.LastRan = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
               ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
               this.groupBox1.SuspendLayout();
               this.groupBox2.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
               this.splitContainer1.Panel1.SuspendLayout();
               this.splitContainer1.Panel2.SuspendLayout();
               this.splitContainer1.SuspendLayout();
               this.SuspendLayout();
               // 
               // dataGridView1
               // 
               this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
               dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
               dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
               dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
               dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
               dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
               dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
               this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
               this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
               this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsStagingTest,
            this.Path,
            this.Column6,
            this.LastRan,
            this.Status});
               dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
               dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
               dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
               dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
               dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
               dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
               this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
               this.dataGridView1.Location = new System.Drawing.Point(2, 29);
               this.dataGridView1.Name = "dataGridView1";
               dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
               dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
               dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
               dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
               dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
               dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
               this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
               dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Ivory;
               dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
               this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
               this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
               this.dataGridView1.Size = new System.Drawing.Size(741, 397);
               this.dataGridView1.TabIndex = 0;
               this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
               this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
               this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
               this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
               // 
               // timerRefreshDataGridView
               // 
               this.timerRefreshDataGridView.Enabled = true;
               this.timerRefreshDataGridView.Interval = 1000;
               this.timerRefreshDataGridView.Tick += new System.EventHandler(this.timerRefreshDataGridView_Tick);
               // 
               // RunAllTests
               // 
               this.RunAllTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
               this.RunAllTests.AutoSize = true;
               this.RunAllTests.Location = new System.Drawing.Point(756, 30);
               this.RunAllTests.Name = "RunAllTests";
               this.RunAllTests.Size = new System.Drawing.Size(70, 13);
               this.RunAllTests.TabIndex = 1;
               this.RunAllTests.TabStop = true;
               this.RunAllTests.Text = "Run All Tests";
               this.RunAllTests.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RunAllTests_LinkClicked);
               // 
               // webBrowser1
               // 
               this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
               this.webBrowser1.Location = new System.Drawing.Point(0, 0);
               this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
               this.webBrowser1.Name = "webBrowser1";
               this.webBrowser1.Size = new System.Drawing.Size(961, 159);
               this.webBrowser1.TabIndex = 2;
               // 
               // tbSearch
               // 
               this.tbSearch.Location = new System.Drawing.Point(3, 6);
               this.tbSearch.Name = "tbSearch";
               this.tbSearch.Size = new System.Drawing.Size(361, 20);
               this.tbSearch.TabIndex = 0;
               this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
               // 
               // groupBox1
               // 
               this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.groupBox1.Controls.Add(this.FailedCount);
               this.groupBox1.Controls.Add(this.PassedCount);
               this.groupBox1.Controls.Add(this.label2);
               this.groupBox1.Controls.Add(this.label1);
               this.groupBox1.Location = new System.Drawing.Point(749, 324);
               this.groupBox1.Name = "groupBox1";
               this.groupBox1.Size = new System.Drawing.Size(200, 93);
               this.groupBox1.TabIndex = 6;
               this.groupBox1.TabStop = false;
               this.groupBox1.Text = "Stats";
               // 
               // FailedCount
               // 
               this.FailedCount.AutoSize = true;
               this.FailedCount.Location = new System.Drawing.Point(123, 53);
               this.FailedCount.Name = "FailedCount";
               this.FailedCount.Size = new System.Drawing.Size(13, 13);
               this.FailedCount.TabIndex = 3;
               this.FailedCount.Text = "0";
               // 
               // PassedCount
               // 
               this.PassedCount.AutoSize = true;
               this.PassedCount.Location = new System.Drawing.Point(123, 31);
               this.PassedCount.Name = "PassedCount";
               this.PassedCount.Size = new System.Drawing.Size(13, 13);
               this.PassedCount.TabIndex = 2;
               this.PassedCount.Text = "0";
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Location = new System.Drawing.Point(26, 53);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(38, 13);
               this.label2.TabIndex = 1;
               this.label2.Text = "Failed:";
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(26, 31);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(45, 13);
               this.label1.TabIndex = 0;
               this.label1.Text = "Passed:";
               // 
               // groupBox2
               // 
               this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
               this.groupBox2.Controls.Add(this.checkBox1);
               this.groupBox2.Controls.Add(this.checkBox2);
               this.groupBox2.Location = new System.Drawing.Point(749, 58);
               this.groupBox2.Name = "groupBox2";
               this.groupBox2.Size = new System.Drawing.Size(200, 71);
               this.groupBox2.TabIndex = 7;
               this.groupBox2.TabStop = false;
               this.groupBox2.Text = "Include in Test Set";
               // 
               // checkBox1
               // 
               this.checkBox1.AutoSize = true;
               this.checkBox1.Checked = true;
               this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
               this.checkBox1.Location = new System.Drawing.Point(15, 42);
               this.checkBox1.Name = "checkBox1";
               this.checkBox1.Size = new System.Drawing.Size(106, 17);
               this.checkBox1.TabIndex = 8;
               this.checkBox1.Text = "Production Tests";
               this.checkBox1.UseVisualStyleBackColor = true;
               // 
               // checkBox2
               // 
               this.checkBox2.AutoSize = true;
               this.checkBox2.Checked = true;
               this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
               this.checkBox2.Location = new System.Drawing.Point(15, 19);
               this.checkBox2.Name = "checkBox2";
               this.checkBox2.Size = new System.Drawing.Size(91, 17);
               this.checkBox2.TabIndex = 9;
               this.checkBox2.Text = "Staging Tests";
               this.checkBox2.UseVisualStyleBackColor = true;
               // 
               // splitContainer1
               // 
               this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
               this.splitContainer1.Location = new System.Drawing.Point(0, 0);
               this.splitContainer1.Name = "splitContainer1";
               this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
               // 
               // splitContainer1.Panel1
               // 
               this.splitContainer1.Panel1.Controls.Add(this.bSkipCleanUp);
               this.splitContainer1.Panel1.Controls.Add(this.RunAutomatically);
               this.splitContainer1.Panel1.Controls.Add(this.tbSearch);
               this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
               this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
               this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
               this.splitContainer1.Panel1.Controls.Add(this.RunAllTests);
               // 
               // splitContainer1.Panel2
               // 
               this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
               this.splitContainer1.Size = new System.Drawing.Size(961, 592);
               this.splitContainer1.SplitterDistance = 429;
               this.splitContainer1.TabIndex = 8;
               // 
               // bSkipCleanUp
               // 
               this.bSkipCleanUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
               this.bSkipCleanUp.AutoSize = true;
               this.bSkipCleanUp.Location = new System.Drawing.Point(759, 170);
               this.bSkipCleanUp.Name = "bSkipCleanUp";
               this.bSkipCleanUp.Size = new System.Drawing.Size(118, 17);
               this.bSkipCleanUp.TabIndex = 9;
               this.bSkipCleanUp.Text = "Skip Test Clean Up";
               this.bSkipCleanUp.UseVisualStyleBackColor = true;
               // 
               // RunAutomatically
               // 
               this.RunAutomatically.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
               this.RunAutomatically.AutoSize = true;
               this.RunAutomatically.Location = new System.Drawing.Point(759, 147);
               this.RunAutomatically.Name = "RunAutomatically";
               this.RunAutomatically.Size = new System.Drawing.Size(103, 17);
               this.RunAutomatically.TabIndex = 8;
               this.RunAutomatically.Text = "Automatic Mode";
               this.RunAutomatically.UseVisualStyleBackColor = true;
               this.RunAutomatically.CheckedChanged += new System.EventHandler(this.RunAutomatically_CheckedChanged);
               // 
               // IsStagingTest
               // 
               this.IsStagingTest.DataPropertyName = "IsStagingTest";
               this.IsStagingTest.FalseValue = "false";
               this.IsStagingTest.HeaderText = "IsStagingTest";
               this.IsStagingTest.Name = "IsStagingTest";
               this.IsStagingTest.ReadOnly = true;
               this.IsStagingTest.TrueValue = "true";
               this.IsStagingTest.Width = 80;
               // 
               // Path
               // 
               this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
               this.Path.DataPropertyName = "Path";
               this.Path.HeaderText = "Path";
               this.Path.Name = "Path";
               this.Path.ReadOnly = true;
               // 
               // Column6
               // 
               this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
               this.Column6.DataPropertyName = "RunTime";
               dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
               this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
               this.Column6.HeaderText = "Run Time";
               this.Column6.Name = "Column6";
               this.Column6.ReadOnly = true;
               this.Column6.Width = 78;
               // 
               // LastRan
               // 
               this.LastRan.DataPropertyName = "LastRun";
               this.LastRan.HeaderText = "Last Run";
               this.LastRan.Name = "LastRan";
               this.LastRan.ReadOnly = true;
               this.LastRan.Width = 80;
               // 
               // Status
               // 
               this.Status.DataPropertyName = "Status";
               dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
               this.Status.DefaultCellStyle = dataGridViewCellStyle3;
               this.Status.HeaderText = "Status";
               this.Status.Name = "Status";
               this.Status.ReadOnly = true;
               this.Status.Width = 80;
               // 
               // TestingHarness
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(961, 592);
               this.Controls.Add(this.splitContainer1);
               this.Name = "TestingHarness";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Weavver Moksha - Release & Testing Harness";
               this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
               this.Load += new System.EventHandler(this.TestingHarness_Load);
               ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
               this.groupBox1.ResumeLayout(false);
               this.groupBox1.PerformLayout();
               this.groupBox2.ResumeLayout(false);
               this.groupBox2.PerformLayout();
               this.splitContainer1.Panel1.ResumeLayout(false);
               this.splitContainer1.Panel1.PerformLayout();
               this.splitContainer1.Panel2.ResumeLayout(false);
               ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
               this.splitContainer1.ResumeLayout(false);
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.DataGridView dataGridView1;
          private System.Windows.Forms.Timer timerRefreshDataGridView;
          private System.Windows.Forms.LinkLabel RunAllTests;
          private System.Windows.Forms.WebBrowser webBrowser1;
          private System.Windows.Forms.TextBox tbSearch;
          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.GroupBox groupBox2;
          private System.Windows.Forms.Label PassedCount;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Label FailedCount;
          private System.Windows.Forms.CheckBox checkBox1;
          private System.Windows.Forms.CheckBox checkBox2;
          private System.Windows.Forms.SplitContainer splitContainer1;
          private System.Windows.Forms.CheckBox RunAutomatically;
          private System.Windows.Forms.CheckBox bSkipCleanUp;
          private System.Windows.Forms.DataGridViewCheckBoxColumn IsStagingTest;
          private System.Windows.Forms.DataGridViewTextBoxColumn Path;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
          private System.Windows.Forms.DataGridViewTextBoxColumn LastRan;
          private System.Windows.Forms.DataGridViewTextBoxColumn Status;

     }
}