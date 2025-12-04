using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VTI
{
    public class Veritabani
    {
        public Veritabani()
        {
            baglanti = new SqlConnection(@"Data Source=DESKTOP-9QPC6VD\SQLEXPRESS;Initial Catalog=db_AracKiralama_Deneme1;Integrated Security=True");
        }

        SqlConnection baglanti;
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adtr = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public DataTable Select(string sorgu)
        {
            dt = new DataTable();
            baglanti.Open();
            komut.CommandText = sorgu;
            komut.Connection = baglanti;
            adtr.SelectCommand = komut;
            adtr.Fill(dt);
            baglanti.Close();

            return dt;
        }

        public object Insert(string sorgu)
        {
            baglanti.Open();
            komut.CommandText = sorgu;
            komut.Connection = baglanti;
            int kayitSay=komut.ExecuteNonQuery();

            if(kayitSay>0)
            {
                dt = new DataTable();
                komut.CommandText = "select scope_identity()";
                adtr.SelectCommand = komut;
                adtr.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    baglanti.Close();
                    return dt.Rows[0][0];
                }
            }

            baglanti.Close();

            return kayitSay;
        }

        public int UpdateDelete(string sorgu)
        {
            baglanti.Open();
            komut.CommandText = sorgu;
            komut.Connection = baglanti;
            int kayitSay = komut.ExecuteNonQuery();
            baglanti.Close();

            return kayitSay;
        }

    }
}
