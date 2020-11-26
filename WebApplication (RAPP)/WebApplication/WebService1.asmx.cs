using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string getTime(string Id)
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\CONTI SB\SW\v6\production_database.mdf;Integrated Security=True;Connect Timeout=30";
            myCon.Open();
            SqlDataAdapter daPiese = new SqlDataAdapter("SELECT * FROM Piese WHERE Id = " + Id, myCon);

            DataSet datePiesa = new DataSet();
            daPiese.Fill(datePiesa);

            string date_time = "";
            for (int i = 0; i < datePiesa.Tables[0].Rows.Count; i++)
                date_time = datePiesa.Tables[0].Rows[i]["DateTime"].ToString();

            myCon.Close();

            return date_time;
        }

    }
}
