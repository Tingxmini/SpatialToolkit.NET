namespace suanfakuangjia
{
    partial class qiumian
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
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Blat = new System.Windows.Forms.TextBox();
            this.Blon = new System.Windows.Forms.TextBox();
            this.Alat = new System.Windows.Forms.TextBox();
            this.Alon = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(240, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 18);
            this.label14.TabIndex = 49;
            this.label14.Text = "纬度";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(240, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 18);
            this.label13.TabIndex = 48;
            this.label13.Text = "纬度";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 47;
            this.label12.Text = "B点 经度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(53, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 46;
            this.label11.Text = "A点 经度";
            // 
            // Blat
            // 
            this.Blat.Location = new System.Drawing.Point(294, 166);
            this.Blat.Name = "Blat";
            this.Blat.Size = new System.Drawing.Size(76, 28);
            this.Blat.TabIndex = 45;
            // 
            // Blon
            // 
            this.Blon.Location = new System.Drawing.Point(145, 166);
            this.Blon.Name = "Blon";
            this.Blon.Size = new System.Drawing.Size(78, 28);
            this.Blon.TabIndex = 44;
            // 
            // Alat
            // 
            this.Alat.Location = new System.Drawing.Point(294, 120);
            this.Alat.Name = "Alat";
            this.Alat.Size = new System.Drawing.Size(76, 28);
            this.Alat.TabIndex = 43;
            // 
            // Alon
            // 
            this.Alon.Location = new System.Drawing.Point(146, 120);
            this.Alon.Name = "Alon";
            this.Alon.Size = new System.Drawing.Size(77, 28);
            this.Alon.TabIndex = 42;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.MistyRose;
            this.button16.Location = new System.Drawing.Point(146, 238);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(117, 36);
            this.button16.TabIndex = 41;
            this.button16.Text = "确定";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 18);
            this.label1.TabIndex = 50;
            this.label1.Text = "请输入两点经纬度：";
            // 
            // qiumian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(419, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Blat);
            this.Controls.Add(this.Blon);
            this.Controls.Add(this.Alat);
            this.Controls.Add(this.Alon);
            this.Controls.Add(this.button16);
            this.Name = "qiumian";
            this.Text = "qiumian";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Blat;
        private System.Windows.Forms.TextBox Blon;
        private System.Windows.Forms.TextBox Alat;
        private System.Windows.Forms.TextBox Alon;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label1;
    }
}