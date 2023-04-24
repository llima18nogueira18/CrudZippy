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

namespace WindowsFormsApp1
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=db_zippy;Data Source=DESKTOP-F8EN0LE\r\n");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dt;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtfrmlogin.Text =="" || txtfrmsenha.Text =="")
            {
                MessageBox.Show("Obrigatório preencher os campos login e senha", "ATENÇÃO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            else
            {
                try
                {
                    cn.Open();
                    cm.CommandText = "select * from tbl_usuario where ds_login = ('" + txtfrmlogin.Text + "') and ds_senha = ('" + txtfrmsenha.Text + "')";
                    cm.Connection = cn;
                    dt = cm.ExecuteReader();
                    if (dt.HasRows)
                    {
                        frmprincipal menu = new frmprincipal();
                        menu.Show();
                        this.Hide();

                    }   
                    
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidos", "Ocorreu um erro!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtfrmlogin.Clear();
                        txtfrmsenha.Clear();
                        txtfrmlogin.Focus();
                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                    cn.Close();
                }
                finally
                {
                    cn.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtfrmlogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfrmsenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
