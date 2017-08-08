namespace Deneme1
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewExceldenGelen = new System.Windows.Forms.DataGridView();
            this.btn_VerileriGetir = new System.Windows.Forms.Button();
            this.btn_transferSql = new System.Windows.Forms.Button();
            this.btn_ilerle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExceldenGelen)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridViewExceldenGelen
            // 
            this.dataGridViewExceldenGelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExceldenGelen.Location = new System.Drawing.Point(58, 88);
            this.dataGridViewExceldenGelen.Name = "dataGridViewExceldenGelen";
            this.dataGridViewExceldenGelen.Size = new System.Drawing.Size(427, 240);
            this.dataGridViewExceldenGelen.TabIndex = 0;
            // 
            // btn_VerileriGetir
            // 
            this.btn_VerileriGetir.Location = new System.Drawing.Point(58, 26);
            this.btn_VerileriGetir.Name = "btn_VerileriGetir";
            this.btn_VerileriGetir.Size = new System.Drawing.Size(108, 40);
            this.btn_VerileriGetir.TabIndex = 1;
            this.btn_VerileriGetir.Text = "Verileri Göster";
            this.btn_VerileriGetir.UseVisualStyleBackColor = true;
            this.btn_VerileriGetir.Click += new System.EventHandler(this.btn_VerileriGetir_Click);
            // 
            // btn_transferSql
            // 
            this.btn_transferSql.Location = new System.Drawing.Point(364, 26);
            this.btn_transferSql.Name = "btn_transferSql";
            this.btn_transferSql.Size = new System.Drawing.Size(121, 40);
            this.btn_transferSql.TabIndex = 2;
            this.btn_transferSql.Text = "Veri Tabanına Aktar";
            this.btn_transferSql.UseVisualStyleBackColor = true;
            this.btn_transferSql.Click += new System.EventHandler(this.btn_transferSql_Click);
            // 
            // btn_ilerle
            // 
            this.btn_ilerle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ilerle.Location = new System.Drawing.Point(364, 367);
            this.btn_ilerle.Name = "btn_ilerle";
            this.btn_ilerle.Size = new System.Drawing.Size(121, 43);
            this.btn_ilerle.TabIndex = 3;
            this.btn_ilerle.Text = "İlerle";
            this.btn_ilerle.UseVisualStyleBackColor = true;
            this.btn_ilerle.Click += new System.EventHandler(this.btn_ilerle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 434);
            this.Controls.Add(this.btn_ilerle);
            this.Controls.Add(this.btn_transferSql);
            this.Controls.Add(this.btn_VerileriGetir);
            this.Controls.Add(this.dataGridViewExceldenGelen);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExceldenGelen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridViewExceldenGelen;
        private System.Windows.Forms.Button btn_VerileriGetir;
        private System.Windows.Forms.Button btn_transferSql;
        private System.Windows.Forms.Button btn_ilerle;
    }
}

