namespace TeoryFear
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.gridEnsemble = new System.Windows.Forms.DataGridView();
            this.gridMatrix = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVariant = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridEnsemble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество строк:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество столбцов:";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(137, 37);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(82, 20);
            this.txtRows.TabIndex = 2;
            // 
            // txtCols
            // 
            this.txtCols.Location = new System.Drawing.Point(137, 63);
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(82, 20);
            this.txtCols.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "Задать размеры матрицы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ансамбль А:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Условные вероятности p(bj/ai)";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(12, 415);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(776, 23);
            this.btnCalc.TabIndex = 7;
            this.btnCalc.Text = "Рассчитать";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // gridEnsemble
            // 
            this.gridEnsemble.AllowUserToAddRows = false;
            this.gridEnsemble.AllowUserToDeleteRows = false;
            this.gridEnsemble.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEnsemble.Location = new System.Drawing.Point(15, 136);
            this.gridEnsemble.Name = "gridEnsemble";
            this.gridEnsemble.RowHeadersVisible = false;
            this.gridEnsemble.Size = new System.Drawing.Size(773, 40);
            this.gridEnsemble.TabIndex = 8;
            // 
            // gridMatrix
            // 
            this.gridMatrix.AllowUserToAddRows = false;
            this.gridMatrix.AllowUserToDeleteRows = false;
            this.gridMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMatrix.Location = new System.Drawing.Point(15, 196);
            this.gridMatrix.Name = "gridMatrix";
            this.gridMatrix.RowHeadersVisible = false;
            this.gridMatrix.Size = new System.Drawing.Size(773, 213);
            this.gridMatrix.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Случай 1: A, p(bj/ai)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Номер варианта:";
            // 
            // txtVariant
            // 
            this.txtVariant.Location = new System.Drawing.Point(534, 37);
            this.txtVariant.Name = "txtVariant";
            this.txtVariant.Size = new System.Drawing.Size(82, 20);
            this.txtVariant.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtVariant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gridMatrix);
            this.Controls.Add(this.gridEnsemble);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCols);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Теория информации";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEnsemble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.TextBox txtCols;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.DataGridView gridEnsemble;
        private System.Windows.Forms.DataGridView gridMatrix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVariant;
    }
}