using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Internet_Cafe
{
    public partial class frmSatis : Form
    {

        public frmSatis()
        {
            InitializeComponent();
        }
        Button btn;

        private void SecileneGore(object sender, EventArgs e)
        {
            btn = sender as Button;
            if (btn.BackColor == Color.OrangeRed)
            {
                süreliMasaAçmaİsteğiGönderToolStripMenuItem.Visible = false;
                süresizMasaAçmaİsteğiGönderToolStripMenuItem.Visible = false;
            }
            if (btn.BackColor == Color.DarkSeaGreen)
            {
                süreliMasaAçmaİsteğiGönderToolStripMenuItem.Visible = true;
                süresizMasaAçmaİsteğiGönderToolStripMenuItem.Visible = true;
            }
        }
        RadioButton radio;
        private void RadioButtonSeciliyeGore(object sender, EventArgs e)
        {
            radio = sender as RadioButton;
        }

        private void frmSatis_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'internetCafeProjeDataSet.TBLSaatUcreti' table. You can move, or remove it, as needed.
            this.tBLSaatUcretiTableAdapter.Fill(this.internetCafeProjeDataSet.TBLSaatUcreti);
            radioBtnSuresiz.Checked = true;
            Yenile();
            comboBosMasalar.Text = "";
            timer1.Start();

        }

        public void Yenile()//veri tabanından boş ve dolu masaları çekme
        {
            Veritabani.SepetListele(dataGridView1);
            Veritabani.ListviewdeKayitlariGoster(listView1);
            Veritabani.ComboyaBosMasaGetir(comboBosMasalar);

            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    if (item.Name != btnMasaAc.Name)
                    {
                        Veritabani.baglanti.Open();
                        SqlCommand komut = new SqlCommand("select * from tblmasalar", Veritabani.baglanti);
                        SqlDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["durumu"].ToString() == "BOŞ" && dr["Masalar"].ToString() == item.Text)//Boş masaların rengi
                            {
                                item.BackColor = Color.DarkSeaGreen;
                            }
                            if (dr["durumu"].ToString() == "DOLU" && dr["Masalar"].ToString() == item.Text)//dolu masaların rengi
                            {
                                item.BackColor = Color.OrangeRed;
                            }
                        }
                        Veritabani.baglanti.Close();
                    }
                }
            }
        }

        private void btnMasaAc_Click(object sender, EventArgs e)
        {//yetkilendirme yapma

            if (Kullanici.KullaniciID == 1)
            {
                string sqlsorgu = "insert into tblsepet(MasaID,Masa,AcilisTuru,Baslangic,Tarih) values('"+comboBosMasalar.Text.Substring(5)+"','"+comboBosMasalar.Text+"','"+radio.Text+"',@Baslangic,@Tarih)";
    //            string sqlsorgu = "insert into tblsepet(MasaID,Masa,AcilisTuru,Baslangic,Tarih) values('" + comboBosMasalar.Text.Substring(5) + "','" + comboBosMasalar.Text + "'" +
    //",'" + radio.Text + "',@Baslangic,@Tarih)";//sepet tablosuna aktarma
                SqlCommand komut = new SqlCommand();
                komut.Parameters.AddWithValue("@Baslangic", DateTime.Parse(DateTime.Now.ToString()));
                komut.Parameters.AddWithValue("@Tarih", DateTime.Parse(DateTime.Now.ToString()));
                Veritabani.EkleSilGuncelle(komut, sqlsorgu);
                MessageBox.Show(comboBosMasalar.Text.Substring(5) + " nolu masa açıldı..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                radioBtnSuresiz.Checked = true;

            }
            else
            {
                MessageBox.Show("Böyle bir yetkiniz bulunamamaktadır.!!", "Uyarı!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmSatis_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Hesapla"].Index)
            {
                if (comboSaatUcreti.Text != "")
                {
                    DateTime BitisTarihi = DateTime.Now;
                    DateTime BaslangicTarihi = DateTime.Parse(dataGridView1.CurrentRow.Cells["BaslamaSaati"].Value.ToString());
                    TimeSpan saatfarki = BitisTarihi - BaslangicTarihi;
                    double saatfarki2 = saatfarki.TotalHours;
                    dataGridView1.CurrentRow.Cells["Süre"].Value = saatfarki2.ToString("0.00");
                    double toplamtutar = saatfarki2 * double.Parse(comboSaatUcreti.Text);
                    dataGridView1.CurrentRow.Cells["Tutar"].Value = toplamtutar.ToString("0.00");
                    dataGridView1.CurrentRow.Cells["BitisSaati"].Value = BitisTarihi;
                }
                if (comboSaatUcreti.Text == "")
                {
                    MessageBox.Show("Önce saat ücreti belirtilmelidir!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if (e.ColumnIndex == dataGridView1.Columns["MasaKapat"].Index)
            {
                if (dataGridView1.CurrentRow.Cells["BitisSaati"].Value != null)
                {
                    frmMasaKapat frm = new frmMasaKapat();
                    frm.txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    frm.txtMasaID.Text = dataGridView1.CurrentRow.Cells["Masa_ID"].Value.ToString();
                    frm.txtMasa.Text = dataGridView1.CurrentRow.Cells["_Masa"].Value.ToString();
                    frm.txtAcilisTuru.Text = dataGridView1.CurrentRow.Cells["AcilisTuru"].Value.ToString();
                    frm.txtBaslamaSaati.Text = dataGridView1.CurrentRow.Cells["BaslamaSaati"].Value.ToString();
                    frm.txtBitisSaati.Text = dataGridView1.CurrentRow.Cells["BitisSaati"].Value.ToString();
                    frm.txtSaatUcreti.Text = comboSaatUcreti.Text;
                    frm.txtSure.Text = dataGridView1.CurrentRow.Cells["Süre"].Value.ToString();
                    frm.txtTutar.Text = dataGridView1.CurrentRow.Cells["Tutar"].Value.ToString();
                    frm.txtTarih.Text = dataGridView1.CurrentRow.Cells["_Tarih"].Value.ToString();
                    frm.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells["BitisSaati"].Value == null)
                {
                    MessageBox.Show("Önce hesaplama yapılmalıdır!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }
        string istek = "";
        private void yöneticiÇağırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            istek = "Yöneticiyi çağırıyor!!!";
            Istekler();
        }

        private void Istekler()
        {

            string sqlsorgu = "insert into tblhareketler(KullaniciID,MasaID,Masa,IstekTuru,Aciklama,Tarih) values("
                + "'" + Kullanici.KullaniciID + "','" + btn.Text.Substring(5) + "','" + btn.Text + "','" + istek + "','Yapılmadı',@Tarih)";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@Tarih", DateTime.Parse(DateTime.Now.ToString()));
            Veritabani.EkleSilGuncelle(komut, sqlsorgu);
            Veritabani.ListviewdeKayitlariGoster(listView1);
        }

        private void süresizMasaAçmaİsteğiGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            istek = "Süresiz Masa Açma İsteği Gönderdi!!";
            Istekler();

        }

        private void masaDeğiştirmeİsteğiGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            istek = "Masa Değiştirme İsteği Gönderdi!!";
            Istekler();
        }
        ToolStripMenuItem item;
        private void SureliIstekSecilirse(object sender, EventArgs e)
        {
            item = sender as ToolStripMenuItem;
            istek = item.Text + " dk süre ile masa açma isteği gönderdi!!";
            Istekler();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac > 29)
            {
                if (comboSaatUcreti.Text != "")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DateTime BitisTarihi = DateTime.Now;
                        DateTime BaslangicTarihi = DateTime.Parse(dataGridView1.Rows[i].Cells["BaslamaSaati"].Value.ToString());
                        TimeSpan saatfarki = BitisTarihi - BaslangicTarihi;
                        double saatfarki2 = saatfarki.TotalHours;
                        dataGridView1.Rows[i].Cells["Süre"].Value = saatfarki2.ToString("0.00");
                        double toplamtutar = saatfarki2 * double.Parse(comboSaatUcreti.Text);
                        dataGridView1.Rows[i].Cells["Tutar"].Value = toplamtutar.ToString("0.00");
                        dataGridView1.Rows[i].Cells["BitisSaati"].Value = BitisTarihi;
                    }
                }
                if (comboSaatUcreti.Text == "")
                {
                    MessageBox.Show("Önce saat ücreti belirtilmelidir!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnMasaDegistir_Click(object sender, EventArgs e)
        {
            int SepetID = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            int MasaID = int.Parse(dataGridView1.CurrentRow.Cells["Masa_ID"].Value.ToString());
            string sql = "update tblsepet set MasaID='" + int.Parse(comboBosMasalar.Text.Substring(5)) + "',Masa='" + comboBosMasalar.Text + "' where SepetID='" + SepetID + "'";
            SqlCommand cmd = new SqlCommand();
            Veritabani.EkleSilGuncelle(cmd, sql);
            /////////////////////////////////////
            string sql2 = "update tblmasalar set durumu='BOŞ' where MasaID='" + MasaID + "'";
            SqlCommand cmd2 = new SqlCommand();
            Veritabani.EkleSilGuncelle(cmd2, sql2);
            ////////////////////////////////////
            string sql3 = "update tblmasalar set durumu='DOLU' where MasaID='" + int.Parse(comboBosMasalar.Text.Substring(5)) + "'";
            SqlCommand cmd3 = new SqlCommand();
            Veritabani.EkleSilGuncelle(cmd3, sql3);
            Yenile();
            MessageBox.Show("Masa Değiştirme İşlemi Başarılı:)", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Süre"].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells["AcilisTuru"].Value.ToString() != "Süresiz")
                    {
                        double sure = double.Parse(dataGridView1.Rows[i].Cells["Süre"].Value.ToString()) * 60;
                        double AcilisTuru = double.Parse(dataGridView1.Rows[i].Cells["AcilisTuru"].Value.ToString());
                        if (AcilisTuru - sure <= 5.0)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                    } 
                }
            }
        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            frmSatislarListele frm = new frmSatislarListele();
            frm.btnGeriAl.Enabled = true;
            frm.ShowDialog();
        }
    }
}
