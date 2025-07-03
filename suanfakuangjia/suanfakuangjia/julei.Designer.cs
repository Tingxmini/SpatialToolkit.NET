namespace suanfakuangjia
{
    partial class julei
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
            this.label27 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button20 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(57, 100);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(107, 18);
            this.label27.TabIndex = 67;
            this.label27.Text = "请输入K值：";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(201, 97);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(62, 28);
            this.textBox6.TabIndex = 66;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.MistyRose;
            this.button20.Location = new System.Drawing.Point(167, 158);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(96, 35);
            this.button20.TabIndex = 65;
            this.button20.Text = "确定";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // julei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(398, 219);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button20);
            this.Name = "julei";
            this.Text = "julei";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button20;
    }
}