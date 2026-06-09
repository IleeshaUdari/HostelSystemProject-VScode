namespace HostalManagement
{
    partial class maintatinance
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
            this.textBoxSearchStaffID = new System.Windows.Forms.TextBox();
            this.dataGridViewMaintenance = new System.Windows.Forms.DataGridView();
            this.textBoxFloor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxContactNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStaffID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintenance)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearchStaffID
            // 
            this.textBoxSearchStaffID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchStaffID.Location = new System.Drawing.Point(1068, 341);
            this.textBoxSearchStaffID.Name = "textBoxSearchStaffID";
            this.textBoxSearchStaffID.Size = new System.Drawing.Size(270, 30);
            this.textBoxSearchStaffID.TabIndex = 54;
            // 
            // dataGridViewMaintenance
            // 
            this.dataGridViewMaintenance.AllowUserToAddRows = false;
            this.dataGridViewMaintenance.AllowUserToDeleteRows = false;
            this.dataGridViewMaintenance.AllowUserToResizeColumns = false;
            this.dataGridViewMaintenance.AllowUserToResizeRows = false;
            this.dataGridViewMaintenance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMaintenance.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaintenance.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewMaintenance.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMaintenance.Name = "dataGridViewMaintenance";
            this.dataGridViewMaintenance.RowHeadersWidth = 62;
            this.dataGridViewMaintenance.RowTemplate.Height = 28;
            this.dataGridViewMaintenance.Size = new System.Drawing.Size(1478, 304);
            this.dataGridViewMaintenance.TabIndex = 53;
            // 
            // textBoxFloor
            // 
            this.textBoxFloor.Location = new System.Drawing.Point(46, 646);
            this.textBoxFloor.Name = "textBoxFloor";
            this.textBoxFloor.Size = new System.Drawing.Size(192, 26);
            this.textBoxFloor.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 623);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Floor";
            // 
            // textBoxContactNo
            // 
            this.textBoxContactNo.Location = new System.Drawing.Point(46, 566);
            this.textBoxContactNo.Name = "textBoxContactNo";
            this.textBoxContactNo.Size = new System.Drawing.Size(192, 26);
            this.textBoxContactNo.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Contact No";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(46, 480);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(192, 26);
            this.textBoxName.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Name";
            // 
            // textBoxStaffID
            // 
            this.textBoxStaffID.Location = new System.Drawing.Point(46, 397);
            this.textBoxStaffID.Name = "textBoxStaffID";
            this.textBoxStaffID.Size = new System.Drawing.Size(192, 26);
            this.textBoxStaffID.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Staff ID";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1179, 637);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 78);
            this.button3.TabIndex = 43;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(979, 637);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 78);
            this.button2.TabIndex = 42;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1365, 341);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 30);
            this.button4.TabIndex = 44;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(760, 637);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 78);
            this.button1.TabIndex = 41;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::HostalManagement.Properties.Resources.icons8_home_60;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(1384, 637);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 78);
            this.button5.TabIndex = 58;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // maintatinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1478, 727);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBoxSearchStaffID);
            this.Controls.Add(this.dataGridViewMaintenance);
            this.Controls.Add(this.textBoxFloor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxContactNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxStaffID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "maintatinance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintatinance";
            this.Load += new System.EventHandler(this.maintatinance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintenance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearchStaffID;
        private System.Windows.Forms.DataGridView dataGridViewMaintenance;
        private System.Windows.Forms.TextBox textBoxFloor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxContactNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStaffID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
    }
}