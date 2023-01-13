namespace _Internet_Cafe
{
    partial class frmSatislarListele
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGeriAl = new System.Windows.Forms.Button();
            this.SatisID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KullaniciID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcilisTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Baslangic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bitis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SatisID,
            this.KullaniciID,
            this.MasaID,
            this.AcilisTuru,
            this.Baslangic,
            this.Bitis,
            this.Sure,
            this.Tutar,
            this.Aciklama,
            this.Tarih});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(983, 411);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnGeriAl
            // 
            this.btnGeriAl.BackColor = System.Drawing.Color.Green;
            this.btnGeriAl.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGeriAl.Enabled = false;
            this.btnGeriAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeriAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeriAl.ForeColor = System.Drawing.Color.Yellow;
            this.btnGeriAl.Location = new System.Drawing.Point(835, 411);
            this.btnGeriAl.Name = "btnGeriAl";
            this.btnGeriAl.Size = new System.Drawing.Size(148, 57);
            this.btnGeriAl.TabIndex = 1;
            this.btnGeriAl.Text = "İşlemi Geri Al";
            this.btnGeriAl.UseVisualStyleBackColor = false;
            this.btnGeriAl.Click += new System.EventHandler(this.btnGeriAl_Click);
            // 
            // SatisID
            // 
            this.SatisID.DataPropertyName = "SatisID";
            this.SatisID.HeaderText = "Satış ID";
            this.SatisID.MinimumWidth = 6;
            this.SatisID.Name = "SatisID";
            // 
            // KullaniciID
            // 
            this.KullaniciID.DataPropertyName = "KullaniciID";
            this.KullaniciID.HeaderText = "Kullanıcı ID";
            this.KullaniciID.MinimumWidth = 6;
            this.KullaniciID.Name = "KullaniciID";
            // 
            // MasaID
            // 
            this.MasaID.DataPropertyName = "MasaID";
            this.MasaID.HeaderText = "Masa ID";
            this.MasaID.MinimumWidth = 6;
            this.MasaID.Name = "MasaID";
            // 
            // AcilisTuru
            // 
            this.AcilisTuru.DataPropertyName = "AcilisTuru";
            this.AcilisTuru.HeaderText = "Açılış Türü";
            this.AcilisTuru.MinimumWidth = 6;
            this.AcilisTuru.Name = "AcilisTuru";
            // 
            // Baslangic
            // 
            this.Baslangic.DataPropertyName = "BaslangicSaati";
            this.Baslangic.HeaderText = "Başlama Saati";
            this.Baslangic.MinimumWidth = 6;
            this.Baslangic.Name = "Baslangic";
            // 
            // Bitis
            // 
            this.Bitis.DataPropertyName = "BitisSaati";
            this.Bitis.HeaderText = "Bitiş Saati";
            this.Bitis.MinimumWidth = 6;
            this.Bitis.Name = "Bitis";
            // 
            // Sure
            // 
            this.Sure.DataPropertyName = "Sure";
            this.Sure.HeaderText = "Süre";
            this.Sure.MinimumWidth = 6;
            this.Sure.Name = "Sure";
            // 
            // Tutar
            // 
            this.Tutar.DataPropertyName = "Tutar";
            this.Tutar.HeaderText = "Tutar";
            this.Tutar.MinimumWidth = 6;
            this.Tutar.Name = "Tutar";
            // 
            // Aciklama
            // 
            this.Aciklama.DataPropertyName = "Aciklama";
            this.Aciklama.HeaderText = "Açıklama";
            this.Aciklama.MinimumWidth = 6;
            this.Aciklama.Name = "Aciklama";
            // 
            // Tarih
            // 
            this.Tarih.DataPropertyName = "Tarih";
            this.Tarih.HeaderText = "Tarih";
            this.Tarih.MinimumWidth = 6;
            this.Tarih.Name = "Tarih";
            // 
            // frmSatislarListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 468);
            this.Controls.Add(this.btnGeriAl);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmSatislarListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satışları Listeleme Sayfası";
            this.Load += new System.EventHandler(this.frmSatislarListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button btnGeriAl;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatisID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KullaniciID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MasaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcilisTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baslangic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bitis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarih;
    }
}