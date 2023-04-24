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
    public partial class frmusuario : Form
    {
        public frmusuario()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmusuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=db_zippy;Data Source=DESKTOP-F8EN0LE\r\n");
            SqlCommand command = new SqlCommand("insert into tbl_usuario(ds_usuario,ds_login,ds_senha,ds_fone,ds_perfil) values(@ds_usuario,@ds_login,@ds_senha,@ds_fone,@ds_perfil)  ",sql);
            
            command.Parameters.Add("@ds_usuario",SqlDbType.VarChar).Value= txtnome.Text;
            command.Parameters.Add("@ds_login", SqlDbType.VarChar).Value = txtlogin.Text;
            command.Parameters.Add("@ds_senha", SqlDbType.Char).Value = txtsenha.Text;
            command.Parameters.Add("@ds_fone", SqlDbType.VarChar).Value = txtfone.Text;
            command.Parameters.Add("@ds_perfil", SqlDbType.VarChar).Value = txtperfil.Text;

          if (txtnome.Text != "" & txtlogin.Text != "" & txtsenha.Text != ""  & txtfone.Text != "" & txtperfil.Text != " ")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cadastro efetuado com sucesso", "SISTEMA ZIPPY -- CADASTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtnome.Text = "";
                    txtlogin.Text = "";
                    txtnome.Text = "";
                    txtsenha.Text = "";
                    txtperfil.Text = "";
                    txtfone.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor digita todas as informações nos campos obrigatorios");
                }
                finally
                {
                    sql.Close();
                }
            }
          else
            {
                MessageBox.Show("Por favor digitar todas as informações nos campos Obrigatorios", "SISTEMA ZIPPY -- CADASTRO -- CAMPOS OBRIGÁTORIOS", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }


        }

        private void txtiduser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=db_zippy;Data Source=DESKTOP-F8EN0LE\r\n");
            SqlCommand command = new SqlCommand("select * from tbl_usuario where id_user=@id_user ", sql);
            command.Parameters.Add("@id_user", SqlDbType.Int).Value = txtiduser.Text;

         

                try

                {
                    sql.Open();
                SqlDataReader drms = command.ExecuteReader();
                if (drms.HasRows==false)
                {
                    throw new Exception("Id não encontrado");
                }

                drms.Read();
                txtiduser.Text = Convert.ToString(drms["id_user"]);
                txtnome.Text = Convert.ToString(drms["ds_usuario"]);
                txtlogin.Text = Convert.ToString(drms["ds_login"]);
                txtsenha.Text = Convert.ToString(drms["ds_senha"]);
                txtfone.Text = Convert.ToString(drms["ds_fone"]);
                txtperfil.Text = Convert.ToString(drms["ds_perfil"]);




            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.Close();
                }
            
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            txtiduser.Text = "";
            txtnome.Text = "";
            txtlogin.Text = "";
            txtsenha.Text = "";
            txtfone.Text = "";
            txtperfil.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=db_zippy;Data Source=DESKTOP-F8EN0LE\r\n");
            SqlCommand command = new SqlCommand("update tbl_usuario set ds_usuario=@ds_usuario,  ds_login=@ds_login, ds_senha=@ds_senha, ds_fone=@ds_fone, ds_perfil=@ds_perfil where id_user=@id_user  ", sql);
            command.Parameters.Add("@id_user", SqlDbType.VarChar).Value = txtiduser.Text;
            command.Parameters.Add("@ds_usuario", SqlDbType.VarChar).Value = txtnome.Text;
            command.Parameters.Add("@ds_login", SqlDbType.VarChar).Value = txtlogin.Text;
            command.Parameters.Add("@ds_senha", SqlDbType.Char).Value = txtsenha.Text;
            command.Parameters.Add("@ds_fone", SqlDbType.VarChar).Value = txtfone.Text;
            command.Parameters.Add("@ds_perfil", SqlDbType.VarChar).Value = txtperfil.Text;



            if (txtnome.Text != "" & txtlogin.Text != "" & txtsenha.Text != "" & txtfone.Text != "" & txtperfil.Text != " ")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Atualizado  com sucesso", "SISTEMA ZIPPY -- ALTERAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtiduser.Text = "";
                    txtlogin.Text = "";
                    txtnome.Text = "";
                    txtsenha.Text = "";
                    txtperfil.Text = "";
                    txtfone.Text = "";


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor digita todas as informações nos campos obrigatorios");
                }
                finally
                {
                    sql.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor digitar todas as informações nos campos Obrigatorios", "SISTEMA ZIPPY -- CADASTRO -- CAMPOS OBRIGÁTORIOS", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=db_zippy;Data Source=DESKTOP-F8EN0LE\r\n");
            SqlCommand command = new SqlCommand("delete from tbl_usuario where id_user=@id_user ", sql);
            command.Parameters.Add("@id_user", SqlDbType.Int).Value = txtiduser.Text;



            try

            {
                sql.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Dados excluidos com sucesso", "SISTEMA ZIPPY -- Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtiduser.Text = "";
                txtlogin.Text = "";
                txtnome.Text = "";
                txtsenha.Text = "";
                txtperfil.Text = "";
                txtfone.Text = "";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
