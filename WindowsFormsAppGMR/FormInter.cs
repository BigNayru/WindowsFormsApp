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
    public partial class FormInter : Form
    {
        public FormInter()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInter_Load(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            string str = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string strsql = "select * from Materiel";
            SqlCommand cm = new SqlCommand(strsql, conn);
            SqlDataReader rd = cm.ExecuteReader();
            comboBoxMatos.Items.Clear();
            while (rd.Read())
            {
                comboBoxMatos.Items.Add(rd["nom"].ToString());
            }

            rd.Close();
            conn.Close();
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            string stridmat = "7";

            string str2 = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn2 = new SqlConnection(str2);
            conn2.Open();
            string strsql2 = "select ID from Materiel where nom = '" + comboBoxMatos.SelectedItem.ToString() + "'";
            SqlCommand cm2 = new SqlCommand(strsql2, conn2);
            SqlDataReader rd = cm2.ExecuteReader();
            rd.Read();
            stridmat = rd["ID"].ToString();
            conn2.Close();



            string str = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string strsql = "INSERT INTO Intervention VALUES('" + textBoxNom.Text + "'," + stridmat + ",'" +
                dateTimePicker1.Value.ToShortDateString() + "','" + textBoxDescription.Text + "')";

            SqlCommand cm = new SqlCommand(strsql, conn);
            cm.ExecuteNonQuery();

            conn.Close();

            textBoxNom.Text = textBoxDescription.Text = "";

        }

        private void buttonInter_Click(object sender, EventArgs e)
        {
            FormInterList fls = new FormInterList();
            fls.ShowDialog();
        }
    }
}
