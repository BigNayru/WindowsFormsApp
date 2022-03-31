using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsAppGMR
{
    public partial class FormInterList : Form
    {
        public FormInterList()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInterList_Load(object sender, EventArgs e)
        {
            string str = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string strsql = "select * from Intervention";
            SqlCommand cm = new SqlCommand(strsql, conn);
            SqlDataReader rd = cm.ExecuteReader();
            listBoxInter.Items.Clear();
            while (rd.Read())
            {
                listBoxInter.Items.Add(rd["nom"].ToString());
            }

            rd.Close();
            conn.Close();
        }
    }
}
