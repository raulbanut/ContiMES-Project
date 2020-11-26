using System;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    public class Data
    {
        SqlConnection myCon = new SqlConnection(); // create a connection

        public Data()
        {
        }

        public bool search(ModulPrincipal modul)
        {
            myCon.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\CONTI SB\SW\v6\production_database.mdf;Integrated Security=True;Connect Timeout=30";

            myCon.Open();

            SqlDataAdapter daPiese = new SqlDataAdapter("SELECT * FROM Piese WHERE Id = " + modul.getCodModul(), myCon);

            DataSet datePiesa = new DataSet();
            daPiese.Fill(datePiesa);

            myCon.Close();

            string date_time = "";
            for (int i = 0; i < datePiesa.Tables[0].Rows.Count; i++)
                date_time = datePiesa.Tables[0].Rows[i]["Id"].ToString();


            if (date_time == "")
            {
                return true;
            }

            return false;
        }

        public void insert(ModulPrincipal modul)
        {
            myCon.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\CONTI SB\SW\v6\production_database.mdf;Integrated Security=True;Connect Timeout=30";
            myCon.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Piese(Id, DateTime) VALUES('" + modul.getCodModul()
                + "', '" + modul.GetDateTime() + "')", myCon);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("INSERT INTO Loturi(Id, LotRezistente, LotCondensatoare) VALUES('" + modul.getCodModul()
                + "', '" + modul.getLotRezistente() + "', '" + modul.getLotCondensatoare() + "')", myCon);
            cmd2.CommandType = CommandType.Text;
            cmd2.ExecuteNonQuery();

            myCon.Close();
        }

    }
}
