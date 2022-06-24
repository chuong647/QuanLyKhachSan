namespace QuanLyKhachSan
{
    partial class fDatPhong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnAddCustomerByRoom = new System.Windows.Forms.Button();
            this.btnDeleteCustomerByRoom = new System.Windows.Forms.Button();
            this.btnUpdateCustomerByRoom = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbRoomtype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDatPhong = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐẶT PHÒNG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 293);
            this.panel1.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnAddCustomerByRoom);
            this.panel10.Controls.Add(this.btnDeleteCustomerByRoom);
            this.panel10.Controls.Add(this.btnUpdateCustomerByRoom);
            this.panel10.Location = new System.Drawing.Point(6, 7);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(283, 38);
            this.panel10.TabIndex = 32;
            // 
            // btnAddCustomerByRoom
            // 
            this.btnAddCustomerByRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomerByRoom.Location = new System.Drawing.Point(2, 3);
            this.btnAddCustomerByRoom.Name = "btnAddCustomerByRoom";
            this.btnAddCustomerByRoom.Size = new System.Drawing.Size(89, 32);
            this.btnAddCustomerByRoom.TabIndex = 26;
            this.btnAddCustomerByRoom.Text = "THÊM";
            this.btnAddCustomerByRoom.UseVisualStyleBackColor = true;
            this.btnAddCustomerByRoom.Click += new System.EventHandler(this.btnAddCustomerByRoom_Click);
            // 
            // btnDeleteCustomerByRoom
            // 
            this.btnDeleteCustomerByRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomerByRoom.Location = new System.Drawing.Point(192, 3);
            this.btnDeleteCustomerByRoom.Name = "btnDeleteCustomerByRoom";
            this.btnDeleteCustomerByRoom.Size = new System.Drawing.Size(89, 32);
            this.btnDeleteCustomerByRoom.TabIndex = 28;
            this.btnDeleteCustomerByRoom.Text = "XOÁ";
            this.btnDeleteCustomerByRoom.UseVisualStyleBackColor = true;
            // 
            // btnUpdateCustomerByRoom
            // 
            this.btnUpdateCustomerByRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCustomerByRoom.Location = new System.Drawing.Point(97, 3);
            this.btnUpdateCustomerByRoom.Name = "btnUpdateCustomerByRoom";
            this.btnUpdateCustomerByRoom.Size = new System.Drawing.Size(89, 32);
            this.btnUpdateCustomerByRoom.TabIndex = 27;
            this.btnUpdateCustomerByRoom.Text = "SỬA";
            this.btnUpdateCustomerByRoom.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbRoom);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(8, 132);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(284, 27);
            this.panel5.TabIndex = 4;
            // 
            // cbRoom
            // 
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Location = new System.Drawing.Point(76, 3);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(121, 21);
            this.cbRoom.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Phòng";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbRoomtype);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(8, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(284, 27);
            this.panel4.TabIndex = 4;
            // 
            // cbRoomtype
            // 
            this.cbRoomtype.FormattingEnabled = true;
            this.cbRoomtype.Location = new System.Drawing.Point(75, 2);
            this.cbRoomtype.Name = "cbRoomtype";
            this.cbRoomtype.Size = new System.Drawing.Size(121, 21);
            this.cbRoomtype.TabIndex = 1;
            this.cbRoomtype.SelectedIndexChanged += new System.EventHandler(this.cbRoomtype_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại Phòng";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbCustomer);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(8, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 27);
            this.panel2.TabIndex = 2;
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(76, 3);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(179, 21);
            this.cbCustomer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Khách hàng";
            // 
            // dgvDatPhong
            // 
            this.dgvDatPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatPhong.Location = new System.Drawing.Point(313, 87);
            this.dgvDatPhong.Name = "dgvDatPhong";
            this.dgvDatPhong.Size = new System.Drawing.Size(622, 293);
            this.dgvDatPhong.TabIndex = 2;
            // 
            // fDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 450);
            this.Controls.Add(this.dgvDatPhong);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "fDatPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDatPhong";
            this.panel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbRoomtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDatPhong;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnAddCustomerByRoom;
        private System.Windows.Forms.Button btnDeleteCustomerByRoom;
        private System.Windows.Forms.Button btnUpdateCustomerByRoom;
    }
}