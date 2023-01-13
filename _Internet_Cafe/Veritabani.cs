using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Internet_Cafe
{
    class Veritabani
    {
        public static SqlConnection baglanti = new SqlConnection(@"Data Source =.\sqlexpress; Initial Catalog = InternetCafeProje; Integrated Security = True; Pooling=False");
        public static DataTable SepetListele(DataGridView gridview)
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select *from tblsepet", baglanti);
            DataTable tbl = new DataTable();
            adtr.Fill(tbl);
            gridview.DataSource = tbl;
            return tbl;
        }
        public static DataTable Listele(DataGridView gridview,string sorgu)
        {
            SqlDataAdapter adtr = new SqlDataAdapter(sorgu, baglanti);
            DataTable tbl = new DataTable();
            adtr.Fill(tbl);
            gridview.DataSource = tbl;
            return tbl;
        }
        public static DataTable ComboyaBosMasaGetir(ComboBox combo)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from tblmasalar where durumu='BOŞ'", baglanti);
            DataTable tbl = new DataTable();
            adtr.Fill(tbl);
            combo.DataSource = tbl;
            combo.DisplayMember = "Masalar";
            combo.ValueMember = "MasaID";
            baglanti.Close();
            return tbl;//geriye değer döndüren metot
        }
        public static void EkleSilGuncelle(SqlCommand command, string sorgu)
        {
            baglanti.Open();
            command.Connection = baglanti;
            command.CommandText = sorgu;
            command.ExecuteNonQuery();
            baglanti.Close();

        }
        public static SqlDataReader ListviewdeKayitlariGoster(ListView list)
        {
            list.Items.Clear();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLHareketler where tarih>=@Tarih", baglanti);
            cmd.Parameters.AddWithValue("@Tarih",DateTime.Parse(DateTime.Now.ToShortDateString()));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();//kayıtları listviewe aktarmak için bir nesne türettim.hareketler tablosundaki.
                ekle.Text = dr[0].ToString();//İstekID için
                ekle.SubItems.Add(dr[1].ToString());//masaID için   
                ekle.SubItems.Add(dr[2].ToString());//KullaniciID için
                ekle.SubItems.Add(dr[3].ToString());//Masa için
                ekle.SubItems.Add(dr[4].ToString());//İstek Türü için 
                ekle.SubItems.Add(dr[5].ToString());//açıklama için
                ekle.SubItems.Add(dr[6].ToString());//tarih için
                list.Items.Add(ekle);
            }
            baglanti.Close();
            return dr;

        }
    }
}
