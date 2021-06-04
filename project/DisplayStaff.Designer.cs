namespace project
{
    partial class DisplayStaff
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
            this.btnSeeRevenue = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCreateBill = new System.Windows.Forms.Button();
            this.lbNameStaff = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSeeRevenue
            // 
            this.btnSeeRevenue.Location = new System.Drawing.Point(360, 171);
            this.btnSeeRevenue.Name = "btnSeeRevenue";
            this.btnSeeRevenue.Size = new System.Drawing.Size(110, 73);
            this.btnSeeRevenue.TabIndex = 3;
            this.btnSeeRevenue.Text = "Xem Lại Bill";
            this.btnSeeRevenue.UseVisualStyleBackColor = true;
            this.btnSeeRevenue.Click += new System.EventHandler(this.btnSeeRevenue_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(603, 171);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 73);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Location = new System.Drawing.Point(96, 171);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(110, 73);
            this.btnCreateBill.TabIndex = 5;
            this.btnCreateBill.Text = "Tạo Bill";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // lbNameStaff
            // 
            this.lbNameStaff.AutoSize = true;
            this.lbNameStaff.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameStaff.Location = new System.Drawing.Point(34, 60);
            this.lbNameStaff.Name = "lbNameStaff";
            this.lbNameStaff.Size = new System.Drawing.Size(60, 22);
            this.lbNameStaff.TabIndex = 6;
            this.lbNameStaff.Text = "label1";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(34, 23);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(60, 22);
            this.lbDate.TabIndex = 7;
            this.lbDate.Text = "label1";
            // 
            // DisplayStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbNameStaff);
            this.Controls.Add(this.btnCreateBill);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSeeRevenue);
            this.Name = "DisplayStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisplayStaff";
            this.Load += new System.EventHandler(this.DisplayStaff_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeeRevenue;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.Label lbNameStaff;
        private System.Windows.Forms.Label lbDate;
    }
}