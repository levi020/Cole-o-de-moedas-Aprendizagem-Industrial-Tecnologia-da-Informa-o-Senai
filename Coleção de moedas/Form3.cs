using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace Coleção_de_moedas
{
    public partial class Form3 : Form
    {
        string origem;
        string foto;
        string pastaDestino;
        string destino;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tbInsert.TabPages.Remove(tbDados);
            tbInsert.TabPages.Remove(tbItens);
            tbInsert.TabPages.Remove(tbNotas);
            lblPuxarId.Visible = false;
        }
        //colecao
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbDataA.Text == "") { txbDataA.Text = "Nulo"; }
                if (txbLocalA.Text == "") { txbLocalA.Text = "Nulo"; }
                if (txbCondicaoC.Text == "") { txbCondicaoC.Text = "Nulo"; }
                if (txbCertificado.Text == "") { txbCondicaoC.Text = "Nulo"; }
                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=root;database=moedas");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `colecao`(`dataAquisicao`, `localAquisicao`, `Valor`, `condicaoConserva`, `certificado`, `ativo`) VALUES (@data, @local, @valor, @condicao, @certificado,@s);", conn);
                cmd.Parameters.AddWithValue("@data", txbDataA.Text);
                cmd.Parameters.AddWithValue("@local", txbLocalA.Text);
                cmd.Parameters.AddWithValue("@Valor", txbValorAquisicao.Text);
                cmd.Parameters.AddWithValue("@condicao", txbCondicaoC.Text);
                cmd.Parameters.AddWithValue("@certificado", txbCertificado.Text);
                cmd.Parameters.AddWithValue("@s", "s");
                cmd.ExecuteNonQuery();

                MySqlCommand nome = new MySqlCommand("SELECT LAST_INSERT_ID() AS last_id FROM `colecao`", conn);
                object id = nome.ExecuteScalar();
                Main.puxarId = Convert.ToInt32(id);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txbDataA.Text = string.Empty;
                txbLocalA.Text = string.Empty;
                txbCondicaoC.Text = string.Empty;
                txbCertificado.Text = string.Empty;
                tbInsert.TabPages.Add(tbDados);
                this.tbInsert.SelectedIndex = 1;
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                origem = "";
                foto = "";
                pastaDestino = "C:\\Users\\levi_cerqueira\\Desktop\\exercicios\\Coleção de moedas\\Coleção de moedas\\Resources\\foto\\";
                destino = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    origem = openFileDialog1.FileName;
                    foto = openFileDialog1.SafeFileName;

                    destino = pastaDestino + foto;
                }
                if (File.Exists(destino))
                {
                    if (MessageBox.Show("Arquivo já existe, deseja substituir?", "Substituir", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                pbFoto.ImageLocation = origem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrarDados_Click(object sender, EventArgs e)
        {
            try
            {
                if (Main.puxarId <= 0)
                {
                    MessageBox.Show("Não será possível realizar o cadastro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=root;database=moedas");
                    conn.Open();
                    if (txbValorFace.Text == "") { txbValorFace.Text = "Nulo"; }
                    if (txbDataEmissao.Text == "") { txbValorFace.Text = "Nulo"; }
                    if (txbVariedades.Text == "") { txbVariedades.Text = "Nulo"; }
                    if (txbPeso.Text == "") { txbPeso.Text = "Nulo"; }
                    if (txbDiametro.Text == "") { txbDiametro.Text = "Nulo"; }
                    if (txbPais.Text == "") { txbPais.Text = "Nulo"; }
                    if (txbMetal.Text == "") { txbMetal.Text = "Nulo"; }

                    if (destino == "")
                    {
                         if (MessageBox.Show("Você não selecionou nenhuma imagem, deseja continuar mesmo assim?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                         {
                            return;
                         }
                         else
                         {
                         
                            MySqlCommand cmd = new MySqlCommand("INSERT INTO `dados`(`identifica`, `PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades`, `imagem`, `ativo`) VALUES (@idlabel, @pais, @data, @valor, @tipoMetal, @peso, @diametro, @variedades, @imagem, @ativo);", conn);
                            cmd.Parameters.AddWithValue("@idlabel", Main.puxarId);
                            cmd.Parameters.AddWithValue("@pais", txbPais.Text);
                            cmd.Parameters.AddWithValue("@data", txbDataEmissao.Text);
                            cmd.Parameters.AddWithValue("@valor", txbValorFace.Text);
                            cmd.Parameters.AddWithValue("@tipoMetal", txbMetal.Text);
                            cmd.Parameters.AddWithValue("@peso", txbPeso.Text);
                            cmd.Parameters.AddWithValue("@diametro", txbDiametro.Text);
                            cmd.Parameters.AddWithValue("@variedades", txbVariedades.Text);
                            cmd.Parameters.AddWithValue("@imagem", "Nulo");
                            cmd.Parameters.AddWithValue("@ativo", "s");
                            cmd.ExecuteNonQuery();
                         }
                    }
                    if (destino != "")
                    {
                        System.IO.File.Copy(origem, destino, true);
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO `dados`(`identifica`, `PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades`, `imagem`, `ativo`) VALUES (@idlabel, @pais, @data, @valor, @tipoMetal, @peso, @diametro, @variedades, @imagem, @ativo);", conn);
                        cmd.Parameters.AddWithValue("@idlabel", Main.puxarId);
                        cmd.Parameters.AddWithValue("@pais", txbPais.Text);
                        cmd.Parameters.AddWithValue("@data", txbDataEmissao.Text);
                        cmd.Parameters.AddWithValue("@valor", txbValorFace.Text);
                        cmd.Parameters.AddWithValue("@tipoMetal", txbMetal.Text);
                        cmd.Parameters.AddWithValue("@peso", txbPeso.Text);
                        cmd.Parameters.AddWithValue("@diametro", txbDiametro.Text);
                        cmd.Parameters.AddWithValue("@variedades", txbVariedades.Text);
                        cmd.Parameters.AddWithValue("@imagem", destino);
                        cmd.Parameters.AddWithValue("@ativo", "s");
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                txbVariedades.Text = string.Empty;
                txbDataEmissao.Text = string.Empty;
                txbDiametro.Text = string.Empty;
                txbPais.Text = string.Empty;
                txbMetal.Text = string.Empty;
                txbValorFace.Text = string.Empty;
                txbPeso.Text = string.Empty;
                tbInsert.TabPages.Add(tbItens);
                this.tbInsert.SelectedIndex = 2;
            }
        }
        //itens
        private void btnSalvarItens_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbVerso.Text == string.Empty) { txbVerso.Text = "Nulo"; }
                if (txbMarca.Text == string.Empty) { txbMarca.Text = "Nulo"; }
                if (txbNum.Text == string.Empty) { txbNum.Text = "Nulo"; }
                if (txbErros.Text == string.Empty) { txbErros.Text = "Nulo"; }
                if (txbDetalhes.Text == string.Empty) { txbDetalhes.Text = "Nulo"; }
                if (Main.puxarId <= 0 )
                {
                    MessageBox.Show("Não é possível cadastrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=root;database=moedas");
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `itens_colecao`(`id_colecao`, `versos`, `marcas`, `numSerie`, `errosCunhagem`, `detalhes`, `ativo`) VALUES (@id, @verso, @marca, @num, @erro, @detalhe, 's')", conn);
                    cmd.Parameters.AddWithValue("@id", Main.puxarId);
                    cmd.Parameters.AddWithValue("@verso", txbVerso.Text);
                    cmd.Parameters.AddWithValue("@marca",txbMarca.Text);
                    cmd.Parameters.AddWithValue("@num", txbNum.Text);
                    cmd.Parameters.AddWithValue("@erro", txbErros.Text);
                    cmd.Parameters.AddWithValue("@detalhe", txbDetalhes.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Cadastro feito com sucesso.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                txbVerso.Text = string.Empty;
                txbNum.Text = string.Empty;
                txbMarca.Text = string.Empty;
                txbDetalhes.Text = string.Empty;
                txbErros.Text = string.Empty;
                tbInsert.TabPages.Add(tbNotas);
                this.tbInsert.SelectedIndex = 3;
            }
        }

        private void btnSalvarNotas_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbRefs.Text == string.Empty) { txbRefs.Text = "Nulo"; }
                if (txbHistorico.Text == string.Empty) { txbHistorico.Text = "Nulo"; }
                if (txbObservacoes.Text == string.Empty) { txbObservacoes.Text = "Nulo"; }
                if (Main.puxarId <= 0)
                {
                    MessageBox.Show("Não é possível cadastrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=root;database=moedas");
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `informacoes`(`id_moeda`, `observacoes`, `links`, `historico`, `ativo`) VALUES (@id, @observa, @link, @historico, 's')", conn);
                    cmd.Parameters.AddWithValue("@id", Main.puxarId);
                    cmd.Parameters.AddWithValue("@observa", txbObservacoes.Text);
                    cmd.Parameters.AddWithValue("@link", txbRefs.Text);
                    cmd.Parameters.AddWithValue("@historico", txbHistorico.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
