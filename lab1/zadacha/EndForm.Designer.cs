namespace TeoryFear
{
    partial class EndForm
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
            this.gridMatrix = new System.Windows.Forms.DataGridView();
            this.btnCalc3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVariant = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMatrix
            // 
            this.gridMatrix.AllowUserToAddRows = false;
            this.gridMatrix.AllowUserToDeleteRows = false;
            this.gridMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMatrix.Location = new System.Drawing.Point(15, 136);
            this.gridMatrix.Name = "gridMatrix";
            this.gridMatrix.RowHeadersVisible = false;
            this.gridMatrix.Size = new System.Drawing.Size(773, 273);
            this.gridMatrix.TabIndex = 19;
            // 
            // btnCalc3
            // 
            this.btnCalc3.Location = new System.Drawing.Point(12, 415);
            this.btnCalc3.Name = "btnCalc3";
            this.btnCalc3.Size = new System.Drawing.Size(776, 23);
            this.btnCalc3.TabIndex = 17;
            this.btnCalc3.Text = "Рассчитать";
            this.btnCalc3.UseVisualStyleBackColor = true;
            this.btnCalc3.Click += new System.EventHandler(this.btnCalc3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Совместные вероятности p(ai,bj)";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(225, 37);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(204, 46);
            this.button13.TabIndex = 14;
            this.button13.Text = "Задать размеры матрицы";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // txtCols
            // 
            this.txtCols.Location = new System.Drawing.Point(137, 63);
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(82, 20);
            this.txtCols.TabIndex = 13;
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(137, 37);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(82, 20);
            this.txtRows.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Количество столбцов:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Количество строк:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Случай 3: p(ai, bj)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Номер варианта:";
            // 
            // txtVariant
            // 
            this.txtVariant.Location = new System.Drawing.Point(534, 37);
            this.txtVariant.Name = "txtVariant";
            this.txtVariant.Size = new System.Drawing.Size(82, 20);
            this.txtVariant.TabIndex = 22;
            // 
            // EndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtVariant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gridMatrix);
            this.Controls.Add(this.btnCalc3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.txtCols);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EndForm";
            this.Text = "Теория информации";
            this.Load += new System.EventHandler(this.EndForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMatrix;
        private System.Windows.Forms.Button btnCalc3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox txtCols;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVariant;
    }
}