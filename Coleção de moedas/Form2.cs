using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coleção_de_moedas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=root;database=moedas");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT `user` FROM `usuarios` WHERE `user`=@user AND `senha`=@senha;", conn);
            cmd.Parameters.AddWithValue("@user", txbUser.Text);
            cmd.Parameters.AddWithValue("@senha", txbPassword.Text);
            object resp = cmd.ExecuteScalar();
            if(resp == null)
            {
                MessageBox.Show("Dados incorretos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
              Main.nomeLogin = resp.ToString();
                this.Close();
            }
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
