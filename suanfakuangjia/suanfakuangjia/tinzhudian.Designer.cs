namespace suanfakuangjia
{
    partial class tinzhudian
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tinzhudian));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.eXIT = new System.Windows.Forms.ToolStripButton();
            this.circumcircle = new System.Windows.Forms.ToolStripButton();
            this.connect = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circumcircle,
            this.connect,
            this.eXIT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(642, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // eXIT
            // 
            this.eXIT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eXIT.Image = ((System.Drawing.Image)(resources.GetObject("eXIT.Image")));
            this.eXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eXIT.Name = "eXIT";
            this.eXIT.Size = new System.Drawing.Size(23, 22);
            this.eXIT.Text = "exit";
            this.eXIT.Click += new System.EventHandler(this.eXIT_Click);
            // 
            // circumcircle
            // 
            this.circumcircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.circumcircle.Image = ((System.Drawing.Image)(resources.GetObject("circumcircle.Image")));
            this.circumcircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circumcircle.Name = "circumcircle";
            this.circumcircle.Size = new System.Drawing.Size(23, 22);
            this.circumcircle.Text = "circumcircle";
            this.circumcircle.Click += new System.EventHandler(this.circumcircle_Click);
            // 
            // connect
            // 
            this.connect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connect.Image = ((System.Drawing.Image)(resources.GetObject("connect.Image")));
            this.connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(23, 22);
            this.connect.Text = "connect";
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label1,
            this.Label2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(642, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Label1
            // 
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 17);
            // 
            // Label2
            // 
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 438);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton eXIT;
        private System.Windows.Forms.ToolStripButton circumcircle;
        private System.Windows.Forms.ToolStripButton connect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Label1;
        private System.Windows.Forms.ToolStripStatusLabel Label2;
    }
}

