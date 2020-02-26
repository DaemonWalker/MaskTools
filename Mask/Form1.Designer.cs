namespace Mask
{
    partial class Form1
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
            this.dgvShops = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtThreadNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShops)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvShops
            // 
            this.dgvShops.AllowUserToAddRows = false;
            this.dgvShops.AllowUserToDeleteRows = false;
            this.dgvShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShops.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.serviceName,
            this.serviceAddress});
            this.dgvShops.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvShops.Location = new System.Drawing.Point(0, 0);
            this.dgvShops.Name = "dgvShops";
            this.dgvShops.ReadOnly = true;
            this.dgvShops.RowTemplate.Height = 21;
            this.dgvShops.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShops.Size = new System.Drawing.Size(881, 366);
            this.dgvShops.TabIndex = 0;
            this.dgvShops.SelectionChanged += new System.EventHandler(this.dgvShops_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // serviceName
            // 
            this.serviceName.DataPropertyName = "serviceName";
            this.serviceName.HeaderText = "药店名称";
            this.serviceName.Name = "serviceName";
            this.serviceName.ReadOnly = true;
            // 
            // serviceAddress
            // 
            this.serviceAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serviceAddress.DataPropertyName = "serviceAddress";
            this.serviceAddress.HeaderText = "药店地址";
            this.serviceAddress.Name = "serviceAddress";
            this.serviceAddress.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvResult);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 342);
            this.panel1.TabIndex = 1;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 173);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(881, 169);
            this.dgvResult.TabIndex = 13;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ShopName";
            this.Column1.HeaderText = "药店名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Time";
            this.Column2.HeaderText = "时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Result";
            this.Column3.HeaderText = "结果";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtFilter);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.txtTel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtThreadNum);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 173);
            this.panel2.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.label6.Location = new System.Drawing.Point(20, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "店铺信息过滤";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.txtFilter.Location = new System.Drawing.Point(149, 16);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(670, 26);
            this.txtFilter.TabIndex = 11;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.txtName.Location = new System.Drawing.Point(149, 55);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 26);
            this.txtName.TabIndex = 0;
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.txtTel.Location = new System.Drawing.Point(149, 92);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(240, 26);
            this.txtTel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.label5.Location = new System.Drawing.Point(655, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 96);
            this.label5.TabIndex = 9;
            this.label5.Text = "地址信息";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.txtID.Location = new System.Drawing.Point(149, 129);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(240, 26);
            this.txtID.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.button1.Location = new System.Drawing.Point(434, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 63);
            this.button1.TabIndex = 8;
            this.button1.Text = "开抢";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.label1.Location = new System.Drawing.Point(96, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "姓名";
            // 
            // txtThreadNum
            // 
            this.txtThreadNum.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.txtThreadNum.Location = new System.Drawing.Point(559, 55);
            this.txtThreadNum.Name = "txtThreadNum";
            this.txtThreadNum.Size = new System.Drawing.Size(65, 26);
            this.txtThreadNum.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.label2.Location = new System.Drawing.Point(77, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "手机号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.label4.Location = new System.Drawing.Point(430, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "抢口罩线程数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.label3.Location = new System.Drawing.Point(58, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "身份证号";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 708);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvShops);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShops)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShops;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtThreadNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceAddress;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

