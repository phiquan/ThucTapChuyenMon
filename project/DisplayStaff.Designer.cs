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
            this.btnCreateBill = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSeeRevenue = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Location = new System.Drawing.Point(667, 181);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(110, 41);
            this.btnCreateBill.TabIndex = 0;
            this.btnCreateBill.Text = "In Bill";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(667, 240);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 47);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnSeeRevenue
            // 
            this.btnSeeRevenue.Location = new System.Drawing.Point(667, 117);
            this.btnSeeRevenue.Name = "btnSeeRevenue";
            this.btnSeeRevenue.Size = new System.Drawing.Size(110, 43);
            this.btnSeeRevenue.TabIndex = 2;
            this.btnSeeRevenue.Text = "Xem Doanh Thu";
            this.btnSeeRevenue.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(416, 426);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // DisplayStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnSeeRevenue);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCreateBill);
            this.Name = "DisplayStaff";
            this.Text = "DisplayStaff";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSeeRevenue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}