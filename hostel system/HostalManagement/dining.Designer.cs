namespace HostalManagement
{
    partial class dining
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
            this.textBoxSearchDiningAreaID = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxFloorID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDiningAreaID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearchDiningAreaID
            // 
            this.textBoxSearchDiningAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchDiningAreaID.Location = new System.Drawing.Point(1068, 338);
            this.textBoxSearchDiningAreaID.Name = "textBoxSearchDiningAreaID";
            this.textBoxSearchDiningAreaID.Size = new System.Drawing.Size(270, 30);
            this.textBoxSearchDiningAreaID.TabIndex = 40;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1478, 304);
            this.dataGridView1.TabIndex = 39;
            // 
            // textBoxFloorID
            // 
            this.textBoxFloorID.Location = new System.Drawing.Point(46, 475);
            this.textBoxFloorID.Name = "textBoxFloorID";
            this.textBoxFloorID.Size = new System.Drawing.Size(192, 26);
            this.textBoxFloorID.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Floor";
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(46, 558);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(192, 26);
            this.textBoxLocation.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Location";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(46, 643);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(192, 26);
            this.textBoxName.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 620);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Name";
            // 
            // textBoxDiningAreaID
            // 
            this.textBoxDiningAreaID.Location = new System.Drawing.Point(46, 394);
            this.textBoxDiningAreaID.Name = "textBoxDiningAreaID";
            this.textBoxDiningAreaID.Size = new System.Drawing.Size(192, 26);
            this.textBoxDiningAreaID.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Dining Area ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1168, 620);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 78);
            this.button3.TabIndex = 29;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(968, 620);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 78);
            this.button2.TabIndex = 28;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1365, 338);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 30);
            this.button4.TabIndex = 30;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(749, 620);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 78);
            this.button1.TabIndex = 27;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::HostalManagement.Properties.Resources.icons8_home_60;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(1384, 620);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 78);
            this.button5.TabIndex = 57;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1478, 727);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBoxSearchDiningAreaID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxFloorID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDiningAreaID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "dining";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dining Hall";
            this.Load += new System.EventHandler(this.dining_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearchDiningAreaID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxFloorID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDiningAreaID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
    }
}