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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonInter_Click(object sender, EventArgs e)
        {
            FormInter frm = new FormInter();
            frm.ShowDialog();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ChargeListMatos();
        }

        private void ChargeListMatos()
        {
            string str = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string strsql = "select * from Materiel";
            SqlCommand cm = new SqlCommand(strsql, conn);
            SqlDataReader rd = cm.ExecuteReader();
            listBoxMatos.Items.Clear();
            while (rd.Read())
            {
                listBoxMatos.Items.Add(rd["nom"].ToString());
            }

            rd.Close();
            conn.Close();
        }

        private void listBoxMatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string strsql = "select * from Materiel where Nom = '" + listBoxMatos.SelectedItem.ToString() + "'";
          

            SqlCommand cm = new SqlCommand(strsql, conn);
            SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            textBoxNom.Text = rd["Nom"].ToString();
            textBoxClient.Text = rd["Client"].ToString();
            textBoxRef.Text = rd["Ref"].ToString();
            textBoxMarque.Text = rd["Marque"].ToString();
            textBoxDescription.Text = rd["Description"].ToString();

            rd.Close();
            conn.Close();

        }

        private void buttonNouveau_Click(object sender, EventArgs e)
        {
            string str = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string strsql = "INSERT INTO Materiel VALUES('" + textBoxNom.Text + "','" + textBoxClient.Text + "','" +
                textBoxRef.Text + "','" + textBoxMarque.Text + "','" + textBoxDescription.Text + "')";                     


            SqlCommand cm = new SqlCommand(strsql, conn);
            cm.ExecuteNonQuery();

            conn.Close();

            ChargeListMatos();

        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {               
            string str = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string strsql = "delete from materiel where Nom = '" + listBoxMatos.SelectedItem.ToString() + "'";

            SqlCommand cm = new SqlCommand(strsql, conn);
            cm.ExecuteNonQuery();

            conn.Close();

            ChargeListMatos();
         
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            string str = @"Server = .\SQLEXPRESS; Database = GMR; Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string strsql = "UPDATE Materiel SET Nom = '" + textBoxNom.Text + "', Client = '" + textBoxClient.Text + "', Ref= '" +
                textBoxRef.Text + "', Marque = '" + textBoxMarque.Text + "', Description = '" + textBoxDescription.Text + "' where Nom = '" + textBoxNom.Text + "'";

            MessageBox.Show(strsql);

            SqlCommand cm = new SqlCommand(strsql, conn);
            cm.ExecuteNonQuery();

            conn.Close();

            ChargeListMatos();






        }
    }
}
