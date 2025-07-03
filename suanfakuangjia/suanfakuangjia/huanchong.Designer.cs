namespace suanfakuangjia
{
    partial class huanchong
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.空间分布量测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tIN相关算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEM相关算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.网络分析算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本统计量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缓冲区分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 492);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "绘制点";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(603, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "点的缓冲区";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(603, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "绘制折线或多边形";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(603, 305);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 47);
            this.button4.TabIndex = 4;
            this.button4.Text = "线的左侧缓冲区";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(603, 368);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(173, 48);
            this.button5.TabIndex = 5;
            this.button5.Text = "线的右侧缓冲区";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(258, 582);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 38);
            this.button6.TabIndex = 6;
            this.button6.Text = "清屏";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(603, 433);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(173, 45);
            this.button7.TabIndex = 7;
            this.button7.Text = "多边形外侧缓冲区";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(603, 500);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(173, 45);
            this.button8.TabIndex = 8;
            this.button8.Text = "多边形内侧缓冲区";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(782, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "请沿顺时针方向绘制多边形";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(774, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 28);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "请输入缓冲区阈值：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.空间分布量测ToolStripMenuItem,
            this.tIN相关算法ToolStripMenuItem,
            this.dEM相关算法ToolStripMenuItem,
            this.网络分析算法ToolStripMenuItem,
            this.基本统计量ToolStripMenuItem,
            this.缓冲区分析ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1049, 32);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 空间分布量测ToolStripMenuItem
            // 
            this.空间分布量测ToolStripMenuItem.Name = "空间分布量测ToolStripMenuItem";
            this.空间分布量测ToolStripMenuItem.Size = new System.Drawing.Size(130, 28);
            this.空间分布量测ToolStripMenuItem.Text = "空间分布量测";
            this.空间分布量测ToolStripMenuItem.Click += new System.EventHandler(this.空间分布量测ToolStripMenuItem_Click);
            // 
            // tIN相关算法ToolStripMenuItem
            // 
            this.tIN相关算法ToolStripMenuItem.Name = "tIN相关算法ToolStripMenuItem";
            this.tIN相关算法ToolStripMenuItem.Size = new System.Drawing.Size(124, 28);
            this.tIN相关算法ToolStripMenuItem.Text = "TIN相关算法";
            this.tIN相关算法ToolStripMenuItem.Click += new System.EventHandler(this.tIN相关算法ToolStripMenuItem_Click);
            // 
            // dEM相关算法ToolStripMenuItem
            // 
            this.dEM相关算法ToolStripMenuItem.Name = "dEM相关算法ToolStripMenuItem";
            this.dEM相关算法ToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.dEM相关算法ToolStripMenuItem.Text = "DEM相关算法";
            this.dEM相关算法ToolStripMenuItem.Click += new System.EventHandler(this.dEM相关算法ToolStripMenuItem_Click);
            // 
            // 网络分析算法ToolStripMenuItem
            // 
            this.网络分析算法ToolStripMenuItem.Name = "网络分析算法ToolStripMenuItem";
            this.网络分析算法ToolStripMenuItem.Size = new System.Drawing.Size(130, 28);
            this.网络分析算法ToolStripMenuItem.Text = "网络分析算法";
            this.网络分析算法ToolStripMenuItem.Click += new System.EventHandler(this.网络分析算法ToolStripMenuItem_Click);
            // 
            // 基本统计量ToolStripMenuItem
            // 
            this.基本统计量ToolStripMenuItem.Name = "基本统计量ToolStripMenuItem";
            this.基本统计量ToolStripMenuItem.Size = new System.Drawing.Size(112, 28);
            this.基本统计量ToolStripMenuItem.Text = "基本统计量";
            this.基本统计量ToolStripMenuItem.Click += new System.EventHandler(this.基本统计量ToolStripMenuItem_Click);
            // 
            // 缓冲区分析ToolStripMenuItem
            // 
            this.缓冲区分析ToolStripMenuItem.Name = "缓冲区分析ToolStripMenuItem";
            this.缓冲区分析ToolStripMenuItem.Size = new System.Drawing.Size(112, 28);
            this.缓冲区分析ToolStripMenuItem.Text = "缓冲区分析";
            this.缓冲区分析ToolStripMenuItem.Click += new System.EventHandler(this.缓冲区分析ToolStripMenuItem_Click);
            // 
            // huanchong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 632);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "huanchong";
            this.Text = "huanchong";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 空间分布量测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tIN相关算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEM相关算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网络分析算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本统计量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缓冲区分析ToolStripMenuItem;
    }
}