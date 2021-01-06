namespace DOAN_PTUD_DRUGSTORE_MANAGER_NHOM9
{
    partial class frmDrugManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMedList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoPriceDes = new System.Windows.Forms.RadioButton();
            this.rdoPriceIncr = new System.Windows.Forms.RadioButton();
            this.rdoInStock = new System.Windows.Forms.RadioButton();
            this.rdoMedName = new System.Windows.Forms.RadioButton();
            this.txtMedID = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtMedName = new System.Windows.Forms.TextBox();
            this.txtInStock = new System.Windows.Forms.TextBox();
            this.txtDescribe = new System.Windows.Forms.TextBox();
            this.txtEXP = new System.Windows.Forms.TextBox();
            this.lblMedID = new System.Windows.Forms.Label();
            this.lblMedName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblInStock = new System.Windows.Forms.Label();
            this.lblEXP = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblDescribe = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THUỐC";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMedList);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 412);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH THUỐC";
            // 
            // dgvMedList
            // 
            this.dgvMedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedList.Location = new System.Drawing.Point(6, 19);
            this.dgvMedList.Name = "dgvMedList";
            this.dgvMedList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedList.Size = new System.Drawing.Size(592, 377);
            this.dgvMedList.TabIndex = 0;
            this.dgvMedList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvMedList_RowStateChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoPriceDes);
            this.groupBox2.Controls.Add(this.rdoPriceIncr);
            this.groupBox2.Controls.Add(this.rdoInStock);
            this.groupBox2.Controls.Add(this.rdoMedName);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(646, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SẮP XẾP";
            // 
            // rdoPriceDes
            // 
            this.rdoPriceDes.AutoSize = true;
            this.rdoPriceDes.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPriceDes.Location = new System.Drawing.Point(152, 60);
            this.rdoPriceDes.Name = "rdoPriceDes";
            this.rdoPriceDes.Size = new System.Drawing.Size(115, 21);
            this.rdoPriceDes.TabIndex = 0;
            this.rdoPriceDes.TabStop = true;
            this.rdoPriceDes.Text = "Đơn giá (giảm)";
            this.rdoPriceDes.UseVisualStyleBackColor = true;
            this.rdoPriceDes.CheckedChanged += new System.EventHandler(this.rdoPriceDes_CheckedChanged);
            // 
            // rdoPriceIncr
            // 
            this.rdoPriceIncr.AutoSize = true;
            this.rdoPriceIncr.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPriceIncr.Location = new System.Drawing.Point(22, 60);
            this.rdoPriceIncr.Name = "rdoPriceIncr";
            this.rdoPriceIncr.Size = new System.Drawing.Size(112, 21);
            this.rdoPriceIncr.TabIndex = 0;
            this.rdoPriceIncr.TabStop = true;
            this.rdoPriceIncr.Text = "Đơn giá (tăng)";
            this.rdoPriceIncr.UseVisualStyleBackColor = true;
            this.rdoPriceIncr.CheckedChanged += new System.EventHandler(this.rdoPriceIncr_CheckedChanged);
            // 
            // rdoInStock
            // 
            this.rdoInStock.AutoSize = true;
            this.rdoInStock.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInStock.Location = new System.Drawing.Point(152, 20);
            this.rdoInStock.Name = "rdoInStock";
            this.rdoInStock.Size = new System.Drawing.Size(78, 21);
            this.rdoInStock.TabIndex = 0;
            this.rdoInStock.TabStop = true;
            this.rdoInStock.Text = "Số lượng";
            this.rdoInStock.UseVisualStyleBackColor = true;
            this.rdoInStock.CheckedChanged += new System.EventHandler(this.rdoInStock_CheckedChanged);
            // 
            // rdoMedName
            // 
            this.rdoMedName.AutoSize = true;
            this.rdoMedName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMedName.Location = new System.Drawing.Point(22, 20);
            this.rdoMedName.Name = "rdoMedName";
            this.rdoMedName.Size = new System.Drawing.Size(124, 21);
            this.rdoMedName.TabIndex = 0;
            this.rdoMedName.TabStop = true;
            this.rdoMedName.Text = "Tên thuốc (A-Z)";
            this.rdoMedName.UseVisualStyleBackColor = true;
            this.rdoMedName.CheckedChanged += new System.EventHandler(this.rdoMedName_CheckedChanged);
            // 
            // txtMedID
            // 
            this.txtMedID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedID.Location = new System.Drawing.Point(122, 61);
            this.txtMedID.Name = "txtMedID";
            this.txtMedID.Size = new System.Drawing.Size(334, 25);
            this.txtMedID.TabIndex = 3;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(122, 184);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(334, 25);
            this.txtPrice.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(122, 143);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(334, 25);
            this.txtQuantity.TabIndex = 3;
            // 
            // txtMedName
            // 
            this.txtMedName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedName.Location = new System.Drawing.Point(122, 102);
            this.txtMedName.Name = "txtMedName";
            this.txtMedName.Size = new System.Drawing.Size(334, 25);
            this.txtMedName.TabIndex = 3;
            // 
            // txtInStock
            // 
            this.txtInStock.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInStock.Location = new System.Drawing.Point(122, 225);
            this.txtInStock.Name = "txtInStock";
            this.txtInStock.Size = new System.Drawing.Size(334, 25);
            this.txtInStock.TabIndex = 3;
            // 
            // txtDescribe
            // 
            this.txtDescribe.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescribe.Location = new System.Drawing.Point(122, 389);
            this.txtDescribe.Multiline = true;
            this.txtDescribe.Name = "txtDescribe";
            this.txtDescribe.Size = new System.Drawing.Size(334, 47);
            this.txtDescribe.TabIndex = 3;
            // 
            // txtEXP
            // 
            this.txtEXP.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEXP.Location = new System.Drawing.Point(122, 266);
            this.txtEXP.Name = "txtEXP";
            this.txtEXP.Size = new System.Drawing.Size(334, 25);
            this.txtEXP.TabIndex = 3;
            // 
            // lblMedID
            // 
            this.lblMedID.AutoSize = true;
            this.lblMedID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedID.Location = new System.Drawing.Point(46, 65);
            this.lblMedID.Name = "lblMedID";
            this.lblMedID.Size = new System.Drawing.Size(67, 17);
            this.lblMedID.TabIndex = 4;
            this.lblMedID.Text = "Mã thuốc:";
            // 
            // lblMedName
            // 
            this.lblMedName.AutoSize = true;
            this.lblMedName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedName.Location = new System.Drawing.Point(43, 106);
            this.lblMedName.Name = "lblMedName";
            this.lblMedName.Size = new System.Drawing.Size(70, 17);
            this.lblMedName.TabIndex = 4;
            this.lblMedName.Text = "Tên thuốc:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(37, 147);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(76, 17);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Đơn vị tính:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(57, 188);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(56, 17);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá gốc:";
            // 
            // lblInStock
            // 
            this.lblInStock.AutoSize = true;
            this.lblInStock.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInStock.Location = new System.Drawing.Point(28, 229);
            this.lblInStock.Name = "lblInStock";
            this.lblInStock.Size = new System.Drawing.Size(85, 17);
            this.lblInStock.TabIndex = 4;
            this.lblInStock.Text = "Số lượng tồn:";
            // 
            // lblEXP
            // 
            this.lblEXP.AutoSize = true;
            this.lblEXP.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEXP.Location = new System.Drawing.Point(27, 270);
            this.lblEXP.Name = "lblEXP";
            this.lblEXP.Size = new System.Drawing.Size(86, 17);
            this.lblEXP.TabIndex = 4;
            this.lblEXP.Text = "Hạn sử dụng:";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(20, 352);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(93, 17);
            this.lblSupplier.TabIndex = 4;
            this.lblSupplier.Text = "Nhà cung cấp:";
            // 
            // lblDescribe
            // 
            this.lblDescribe.AutoSize = true;
            this.lblDescribe.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescribe.Location = new System.Drawing.Point(67, 393);
            this.lblDescribe.Name = "lblDescribe";
            this.lblDescribe.Size = new System.Drawing.Size(46, 17);
            this.lblDescribe.TabIndex = 4;
            this.lblDescribe.Text = "Mô tả:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboCategory);
            this.groupBox3.Controls.Add(this.cboSupplier);
            this.groupBox3.Controls.Add(this.txtMedID);
            this.groupBox3.Controls.Add(this.lblDescribe);
            this.groupBox3.Controls.Add(this.txtPrice);
            this.groupBox3.Controls.Add(this.lblPrice);
            this.groupBox3.Controls.Add(this.lblCategory);
            this.groupBox3.Controls.Add(this.txtInStock);
            this.groupBox3.Controls.Add(this.lblSupplier);
            this.groupBox3.Controls.Add(this.txtDescribe);
            this.groupBox3.Controls.Add(this.lblQuantity);
            this.groupBox3.Controls.Add(this.txtQuantity);
            this.groupBox3.Controls.Add(this.lblEXP);
            this.groupBox3.Controls.Add(this.lblMedName);
            this.groupBox3.Controls.Add(this.txtMedName);
            this.groupBox3.Controls.Add(this.lblInStock);
            this.groupBox3.Controls.Add(this.txtEXP);
            this.groupBox3.Controls.Add(this.lblMedID);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(646, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(503, 467);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "THÔNG TIN CHI TIẾT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(190, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nhập tt";
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(122, 307);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(334, 25);
            this.cboCategory.TabIndex = 5;
            // 
            // cboSupplier
            // 
            this.cboSupplier.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(122, 348);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(334, 25);
            this.cboSupplier.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(40, 311);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(73, 17);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Loại thuốc:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Controls.Add(this.btnUpdate);
            this.groupBox4.Controls.Add(this.btnNew);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 482);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(604, 125);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CHỨC NĂNG";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(450, 41);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 41);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(343, 41);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 41);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(236, 41);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 41);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(129, 41);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 41);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(22, 41);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 41);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Thêm";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmDrugManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1204, 661);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmDrugManager";
            this.Text = "frmDrugManager";
            this.Load += new System.EventHandler(this.frmDrugManager_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMedList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoPriceDes;
        private System.Windows.Forms.RadioButton rdoPriceIncr;
        private System.Windows.Forms.RadioButton rdoInStock;
        private System.Windows.Forms.RadioButton rdoMedName;
        private System.Windows.Forms.TextBox txtInStock;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtMedName;
        private System.Windows.Forms.TextBox txtMedID;
        private System.Windows.Forms.TextBox txtDescribe;
        private System.Windows.Forms.TextBox txtEXP;
        private System.Windows.Forms.Label lblMedID;
        private System.Windows.Forms.Label lblMedName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblInStock;
        private System.Windows.Forms.Label lblEXP;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblDescribe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label label2;
    }
}