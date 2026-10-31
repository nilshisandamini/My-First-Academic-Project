namespace MRMS
{
    partial class Device
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblbrand = new System.Windows.Forms.Label();
            this.lblimei = new System.Windows.Forms.Label();
            this.lbldevice = new System.Windows.Forms.Label();
            this.lblproblem = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbproblem = new System.Windows.Forms.ComboBox();
            this.cmbbrand = new System.Windows.Forms.ComboBox();
            this.txtimei = new System.Windows.Forms.TextBox();
            this.txtdevice = new System.Windows.Forms.TextBox();
            this.btnback = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbcustomer = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblbrand);
            this.panel1.Controls.Add(this.lblimei);
            this.panel1.Controls.Add(this.lbldevice);
            this.panel1.Controls.Add(this.lblproblem);
            this.panel1.Location = new System.Drawing.Point(-7, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 482);
            this.panel1.TabIndex = 12;
            // 
            // lblbrand
            // 
            this.lblbrand.AutoSize = true;
            this.lblbrand.BackColor = System.Drawing.Color.Transparent;
            this.lblbrand.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbrand.Location = new System.Drawing.Point(90, 85);
            this.lblbrand.Name = "lblbrand";
            this.lblbrand.Size = new System.Drawing.Size(91, 30);
            this.lblbrand.TabIndex = 1;
            this.lblbrand.Text = "Brand";
            // 
            // lblimei
            // 
            this.lblimei.AutoSize = true;
            this.lblimei.BackColor = System.Drawing.Color.Transparent;
            this.lblimei.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimei.Location = new System.Drawing.Point(90, 163);
            this.lblimei.Name = "lblimei";
            this.lblimei.Size = new System.Drawing.Size(188, 30);
            this.lblimei.TabIndex = 2;
            this.lblimei.Text = "IMEI Number";
            // 
            // lbldevice
            // 
            this.lbldevice.AutoSize = true;
            this.lbldevice.BackColor = System.Drawing.Color.Transparent;
            this.lbldevice.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldevice.Location = new System.Drawing.Point(90, 241);
            this.lbldevice.Name = "lbldevice";
            this.lbldevice.Size = new System.Drawing.Size(169, 30);
            this.lbldevice.TabIndex = 3;
            this.lbldevice.Text = "Device Name";
            // 
            // lblproblem
            // 
            this.lblproblem.AutoSize = true;
            this.lblproblem.BackColor = System.Drawing.Color.Transparent;
            this.lblproblem.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproblem.Location = new System.Drawing.Point(90, 319);
            this.lblproblem.Name = "lblproblem";
            this.lblproblem.Size = new System.Drawing.Size(201, 30);
            this.lblproblem.TabIndex = 4;
            this.lblproblem.Text = "Problem Status";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.cmbcustomer);
            this.panel3.Controls.Add(this.cmbproblem);
            this.panel3.Controls.Add(this.cmbbrand);
            this.panel3.Controls.Add(this.txtimei);
            this.panel3.Controls.Add(this.txtdevice);
            this.panel3.Location = new System.Drawing.Point(449, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 482);
            this.panel3.TabIndex = 13;
            // 
            // cmbproblem
            // 
            this.cmbproblem.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbproblem.FormattingEnabled = true;
            this.cmbproblem.Location = new System.Drawing.Point(78, 315);
            this.cmbproblem.Name = "cmbproblem";
            this.cmbproblem.Size = new System.Drawing.Size(543, 34);
            this.cmbproblem.TabIndex = 10;
            // 
            // cmbbrand
            // 
            this.cmbbrand.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbbrand.FormattingEnabled = true;
            this.cmbbrand.Location = new System.Drawing.Point(78, 84);
            this.cmbbrand.Name = "cmbbrand";
            this.cmbbrand.Size = new System.Drawing.Size(543, 34);
            this.cmbbrand.TabIndex = 9;
            // 
            // txtimei
            // 
            this.txtimei.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtimei.Location = new System.Drawing.Point(78, 157);
            this.txtimei.Multiline = true;
            this.txtimei.Name = "txtimei";
            this.txtimei.Size = new System.Drawing.Size(543, 36);
            this.txtimei.TabIndex = 7;
            // 
            // txtdevice
            // 
            this.txtdevice.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdevice.Location = new System.Drawing.Point(78, 240);
            this.txtdevice.Multiline = true;
            this.txtdevice.Name = "txtdevice";
            this.txtdevice.Size = new System.Drawing.Size(543, 36);
            this.txtdevice.TabIndex = 8;
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(23, 770);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(196, 32);
            this.btnback.TabIndex = 16;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnclear.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(449, 488);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(305, 46);
            this.btnclear.TabIndex = 15;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnsave.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(114, 488);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(305, 46);
            this.btnsave.TabIndex = 14;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(114, 582);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(995, 182);
            this.dataGridView1.TabIndex = 17;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUpdate.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(804, 488);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(305, 46);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSearch.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(957, 537);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(142, 39);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(114, 537);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(837, 39);
            this.txtSearch.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customer Name";
            // 
            // cmbcustomer
            // 
            this.cmbcustomer.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcustomer.FormattingEnabled = true;
            this.cmbcustomer.Location = new System.Drawing.Point(78, 391);
            this.cmbcustomer.Name = "cmbcustomer";
            this.cmbcustomer.Size = new System.Drawing.Size(543, 34);
            this.cmbcustomer.TabIndex = 11;
            // 
            // Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1226, 818);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Device";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Device Registation";
            this.Load += new System.EventHandler(this.Device_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblbrand;
        private System.Windows.Forms.Label lblimei;
        private System.Windows.Forms.Label lbldevice;
        private System.Windows.Forms.Label lblproblem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtimei;
        private System.Windows.Forms.TextBox txtdevice;
        private System.Windows.Forms.ComboBox cmbbrand;
        private System.Windows.Forms.ComboBox cmbproblem;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbcustomer;
    }
}