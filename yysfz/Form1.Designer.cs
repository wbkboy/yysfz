namespace yysfz
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbLog1 = new System.Windows.Forms.RichTextBox();
            this.btnGame1Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReg = new System.Windows.Forms.Label();
            this.btnGame2Start = new System.Windows.Forms.Button();
            this.panelC = new System.Windows.Forms.Panel();
            this.panelM = new System.Windows.Forms.Panel();
            this.panelC.SuspendLayout();
            this.panelM.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLog1
            // 
            this.rtbLog1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rtbLog1.Location = new System.Drawing.Point(12, 292);
            this.rtbLog1.Name = "rtbLog1";
            this.rtbLog1.Size = new System.Drawing.Size(399, 130);
            this.rtbLog1.TabIndex = 3;
            this.rtbLog1.Text = "";
            // 
            // btnGame1Start
            // 
            this.btnGame1Start.Location = new System.Drawing.Point(115, 223);
            this.btnGame1Start.Name = "btnGame1Start";
            this.btnGame1Start.Size = new System.Drawing.Size(75, 23);
            this.btnGame1Start.TabIndex = 6;
            this.btnGame1Start.Text = "开 始";
            this.btnGame1Start.UseVisualStyleBackColor = true;
            this.btnGame1Start.Click += new System.EventHandler(this.btnGame1Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "游戏1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(212, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "游戏2";
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Location = new System.Drawing.Point(12, 425);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(41, 12);
            this.lblReg.TabIndex = 9;
            this.lblReg.Text = "label3";
            // 
            // btnGame2Start
            // 
            this.btnGame2Start.Location = new System.Drawing.Point(115, 223);
            this.btnGame2Start.Name = "btnGame2Start";
            this.btnGame2Start.Size = new System.Drawing.Size(75, 23);
            this.btnGame2Start.TabIndex = 3;
            this.btnGame2Start.Text = "开 始";
            this.btnGame2Start.UseVisualStyleBackColor = true;
            this.btnGame2Start.Click += new System.EventHandler(this.btnGame2Start_Click);
            // 
            // panelC
            // 
            this.panelC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelC.Controls.Add(this.btnGame1Start);
            this.panelC.Location = new System.Drawing.Point(15, 35);
            this.panelC.Name = "panelC";
            this.panelC.Size = new System.Drawing.Size(195, 251);
            this.panelC.TabIndex = 4;
            this.panelC.Tag = "模拟器1";
            // 
            // panelM
            // 
            this.panelM.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelM.Controls.Add(this.btnGame2Start);
            this.panelM.Location = new System.Drawing.Point(216, 35);
            this.panelM.Name = "panelM";
            this.panelM.Size = new System.Drawing.Size(195, 251);
            this.panelM.TabIndex = 5;
            this.panelM.Tag = "模拟器2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 445);
            this.Controls.Add(this.lblReg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelM);
            this.Controls.Add(this.panelC);
            this.Controls.Add(this.rtbLog1);
            this.Name = "Form1";
            this.Text = "阴阳师辅助";
            this.panelC.ResumeLayout(false);
            this.panelM.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbLog1;
        private System.Windows.Forms.Button btnGame1Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.Button btnGame2Start;
        private System.Windows.Forms.Panel panelC;
        private System.Windows.Forms.Panel panelM;
    }
}

