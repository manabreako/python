namespace TeoryFear
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.radioAB = new System.Windows.Forms.RadioButton();
            this.chooseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите случай";
            // 
            // radioA
            // 
            this.radioA.AutoSize = true;
            this.radioA.Checked = true;
            this.radioA.Location = new System.Drawing.Point(16, 42);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(177, 17);
            this.radioA.TabIndex = 1;
            this.radioA.TabStop = true;
            this.radioA.Text = "Ввести для расчёта: A, p(bj/ai)";
            this.radioA.UseVisualStyleBackColor = true;
            // 
            // radioB
            // 
            this.radioB.AutoSize = true;
            this.radioB.Location = new System.Drawing.Point(16, 65);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(177, 17);
            this.radioB.TabIndex = 2;
            this.radioB.Text = "Ввести для расчёта: B, p(ai/bj)";
            this.radioB.UseVisualStyleBackColor = true;
            // 
            // radioAB
            // 
            this.radioAB.AutoSize = true;
            this.radioAB.Location = new System.Drawing.Point(16, 88);
            this.radioAB.Name = "radioAB";
            this.radioAB.Size = new System.Drawing.Size(164, 17);
            this.radioAB.TabIndex = 3;
            this.radioAB.Text = "Ввести для расчёта: p(ai/bj)";
            this.radioAB.UseVisualStyleBackColor = true;
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(16, 120);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(120, 30);
            this.chooseButton.TabIndex = 4;
            this.chooseButton.Text = "Выбрать";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 170);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.radioAB);
            this.Controls.Add(this.radioB);
            this.Controls.Add(this.radioA);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Теория информации";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioA;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.RadioButton radioAB;
        private System.Windows.Forms.Button chooseButton;
    }
}
