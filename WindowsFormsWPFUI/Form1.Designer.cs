
namespace WindowsFormsWPFUI
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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.comboBoxView1 = new WindowsFormsWPFUI.Controls.ComboBoxView();
            this.elementHost4 = new System.Windows.Forms.Integration.ElementHost();
            this.colorSelector1 = new Panuon.UI.Silver.ColorSelector();
            this.elementHost5 = new System.Windows.Forms.Integration.ElementHost();
            this.clock1 = new Panuon.UI.Silver.Clock();
            this.elementHost6 = new System.Windows.Forms.Integration.ElementHost();
            this.imageCuter1 = new Panuon.UI.Silver.ImageCuter();
            this.elementHost7 = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(524, 143);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(292, 46);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(169, 197);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(292, 47);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = null;
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(169, 278);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(394, 29);
            this.elementHost3.TabIndex = 2;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.comboBoxView1;
            // 
            // elementHost4
            // 
            this.elementHost4.Location = new System.Drawing.Point(46, 39);
            this.elementHost4.Name = "elementHost4";
            this.elementHost4.Size = new System.Drawing.Size(304, 114);
            this.elementHost4.TabIndex = 3;
            this.elementHost4.Text = "elementHost4";
            this.elementHost4.Child = this.colorSelector1;
            // 
            // elementHost5
            // 
            this.elementHost5.Location = new System.Drawing.Point(24, 250);
            this.elementHost5.Name = "elementHost5";
            this.elementHost5.Size = new System.Drawing.Size(200, 100);
            this.elementHost5.TabIndex = 4;
            this.elementHost5.Text = "elementHost5";
            this.elementHost5.Child = this.clock1;
            // 
            // elementHost6
            // 
            this.elementHost6.Location = new System.Drawing.Point(273, 313);
            this.elementHost6.Name = "elementHost6";
            this.elementHost6.Size = new System.Drawing.Size(200, 100);
            this.elementHost6.TabIndex = 5;
            this.elementHost6.Text = "elementHost6";
            this.elementHost6.Child = this.imageCuter1;
            // 
            // elementHost7
            // 
            this.elementHost7.Location = new System.Drawing.Point(524, 250);
            this.elementHost7.Name = "elementHost7";
            this.elementHost7.Size = new System.Drawing.Size(200, 100);
            this.elementHost7.TabIndex = 6;
            this.elementHost7.Text = "elementHost7";
            this.elementHost7.Child = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.elementHost7);
            this.Controls.Add(this.elementHost6);
            this.Controls.Add(this.elementHost5);
            this.Controls.Add(this.elementHost4);
            this.Controls.Add(this.elementHost3);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.elementHost1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private Controls.ComboBoxView comboBoxView1;
        private System.Windows.Forms.Integration.ElementHost elementHost4;
        private Panuon.UI.Silver.ColorSelector colorSelector1;
        private System.Windows.Forms.Integration.ElementHost elementHost5;
        private Panuon.UI.Silver.Clock clock1;
        private System.Windows.Forms.Integration.ElementHost elementHost6;
        private Panuon.UI.Silver.ImageCuter imageCuter1;
        private System.Windows.Forms.Integration.ElementHost elementHost7;
    }
}

