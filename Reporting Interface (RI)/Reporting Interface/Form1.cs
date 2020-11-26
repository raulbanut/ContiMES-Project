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
using MySql.Data.MySqlClient;

namespace Reporting_Inrerface
{
    public partial class Form1 : Form
    {
        Reporting_Inrerface.ServiceReference1.WebService1SoapClient service = new Reporting_Inrerface.ServiceReference1.WebService1SoapClient();

       

        public Form1()
        {
            InitializeComponent();
        }

        private void buton_cautare_Click(object sender, EventArgs e)
        {
             label3.Text = service.getTime(textBoxID.Text);
            if (label3.Text == "")
                label3.Text = "Id inexistent!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
