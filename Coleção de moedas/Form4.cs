using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Coleção_de_moedas
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=root;database=moedas");
        private void Form4_Load(object sender, EventArgs e)
        {
            lblAviso.Text = string.Empty;
            txbValue.Visible = false;
            dtExibir.Visible = false;
            dtExibir.Format = DateTimePickerFormat.Custom;
            dtExibir.CustomFormat = "dd-MMM-yyyy";
            lblDelete.Visible = false;
            btnDelete.Visible = false;
        }

        private void cbbMoedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int desc = cbbMoedas.SelectedIndex;
            switch (desc)
            {
                //Pais
                case 0:
                    if (dtExibir.Visible == true)
                    {
                        dtExibir.Visible = false;
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    else
                    {
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    break;
                //Data
                case 1:
                    if (txbValue.Visible == true)
                    {
                        txbValue.Visible = false;
                        dtExibir.Visible = true;
                        btnSearch.Visible = true;
                    }
                    else
                    {
                        dtExibir.Visible = true;
                        btnSearch.Visible = true;
                    }
                    break;
                //Valor
                case 2:
                    if (dtExibir.Visible == true)
                    {
                        dtExibir.Visible = false;
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    else
                    {
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    break;
                //Tipo de metal
                case 3:
                    if (dtExibir.Visible == true)
                    {
                        dtExibir.Visible = false;
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    else
                    {
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    break;
                //Peso
                case 4:
                    if (dtExibir.Visible == true)
                    {
                        dtExibir.Visible = false;
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    else
                    {
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    break;
                //Diametro
                case 5:
                    if (dtExibir.Visible == true)
                    {
                        dtExibir.Visible = false;
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    else
                    {
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    break;
                //Variedades
                case 6:
                    if (dtExibir.Visible == true)
                    {
                        dtExibir.Visible = false;
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    else
                    {
                        txbValue.Visible = true;
                        btnSearch.Visible = true;
                    }
                    break;
                //caso a parte
                default:
                    lblAviso.Text = "Deu erro";
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int desc = cbbMoedas.SelectedIndex;
                MySqlCommand cmd;
                MySqlDataReader reader;
                string parametro;
                switch (desc)
                {
                    //Pais
                    case 0:
                        lbInfo.Items.Clear();
                        parametro = txbValue.Text;
                        if(parametro == null || parametro == "")
                        {
                            MessageBox.Show("Não foi retornado nenhum Pais específico", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados`", conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                            }
                        }
                        else
                        {
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados` WHERE `PaisOrigem` LIKE @pais;", conn);
                            cmd.Parameters.AddWithValue("@pais", parametro);
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhum valor retornado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                        }
                        cmd = null;
                        reader.Close();
                        txbValue.Text = string.Empty;
                        break;
                    //Data
                    case 1:
                        lbInfo.Items.Clear();
                        parametro = Convert.ToString(dtExibir.Value);
                        parametro = parametro.Substring(0, 10);
                        parametro.Replace("-", "/");
                        cmd = new MySqlCommand("SELECT `DataEmissao` FROM `dados` WHERE `DataEmissao`=@data1", conn);
                        cmd.Parameters.AddWithValue("@data1", parametro);
                        object valor = cmd.ExecuteScalar();
                        cmd = null;
                        string value = Convert.ToString(valor);

                        if (value == null || value == "")
                        {
                            MessageBox.Show("Não foi retornado nenhuma data especifica", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados`", conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                            }
                        }
                        else
                        {

                            cmd = new MySqlCommand("SELECT `id`, `PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados` WHERE `DataEmissao`=@data", conn);
                            cmd.Parameters.AddWithValue("@data", parametro.ToString());
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhum valor retornado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        reader.Close();
                        cmd = null;
                        parametro = null;
                        txbValue.Text = string.Empty;
                        break;
                    //Valor
                    case 2:
                        lbInfo.Items.Clear();
                        parametro = txbValue.Text;
                        if(parametro == null || parametro == "")
                        {
                            MessageBox.Show("Não foi retornado nenhum valor específico", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados`", conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                            }
                        }
                        else
                        {
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados` WHERE `valorFacial`=@value;", conn);
                            cmd.Parameters.AddWithValue("@value", parametro);
                            reader = cmd.ExecuteReader();
                            if(reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhum valor retornado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        reader.Close();
                        cmd = null;
                        txbValue.Text = String.Empty;
                        parametro = null;
                        break;
                    //Tipo de metal
                    case 3:
                        lbInfo.Items.Clear();
                        parametro = txbValue.Text;
                        if (parametro == null || parametro == "")
                        {
                            MessageBox.Show("Não foi retornado nenhum valor específico", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados`", conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                            }
                            reader.Close();
                            cmd = null;
                        }
                        else
                        {
                            cmd = new MySqlCommand("SELECT `id`, `PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados` WHERE `TipoMetal`=@metal;", conn);
                            cmd.Parameters.AddWithValue("@metal", parametro);
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7] );
                                }
                                reader.Close();
                                cmd = null;
                                parametro = null;
                            }
                            else
                            {
                                MessageBox.Show("Nenhum valor retornado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                reader.Close();
                                cmd = null;
                                parametro = null;
                            }
                        }
                        txbValue.Text = string.Empty;
                        break;
                    //Peso
                    case 4:
                        lbInfo.Items.Clear();
                        parametro = txbValue.Text;
                        if (parametro == null || parametro == "")
                        {
                            MessageBox.Show("Não foi retornado nenhum valor específico", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados`", conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                            }
                        }
                        else
                        {
                            cmd = new MySqlCommand("SELECT `id`, `PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados` WHERE `Peso`=@peso", conn);
                            cmd.Parameters.AddWithValue("@peso", parametro);
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhum valor retornado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        reader.Close();
                        cmd = null;
                        parametro = null;
                        txbValue.Text = string.Empty;
                        break;
                    //Diametro
                    case 5:
                        lbInfo.Items.Clear();
                        parametro = txbValue.Text;
                        if (parametro == null || parametro == "")
                        {
                            MessageBox.Show("Não foi retornado nenhum valor específico", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados`", conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                            }
                        }
                        else
                        {
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades`, `imagem`, `ativo` FROM `dados` WHERE `DiametroMoeda`=@diametro", conn);
                            cmd.Parameters.AddWithValue("@diametro", parametro);
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhum valor retornado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        reader.Close();
                        cmd = null;
                        parametro = null;
                        txbValue.Text = string.Empty;
                        break;
                    //Variedades
                    case 6:
                        lbInfo.Items.Clear();
                        parametro = txbValue.Text;
                        if (parametro == null || parametro == "")
                        {
                            MessageBox.Show("Não foi retornado nenhum valor específico", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades` FROM `dados`", conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                            }
                        }
                        else
                        {
                            cmd = new MySqlCommand("SELECT `id`,`PaisOrigem`, `DataEmissao`, `valorFacial`, `TipoMetal`, `Peso`, `DiametroMoeda`, `variedades`, `imagem`, `ativo` FROM `dados` WHERE `variedades`=@vari", conn);
                            cmd.Parameters.AddWithValue("@vari", parametro);
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lbInfo.Items.Add("id: " + reader[0] + ", Pais: " + reader[1] + ", Data de emissão: " + reader[2] + ", Valor: " + reader[3] + ", Tipo de metal: " + reader[4] + ", Peso: " + reader[5] + ", Diâmetro: " + reader[6] + ", variedades: " + reader[7]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhum valor retornado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        reader.Close();
                        cmd = null;
                        parametro = null;
                        txbValue.Text = string.Empty;
                        break;
                    default:
                        MessageBox.Show("Escolha uma opção", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dtExibir.Visible = false;
                txbValue.Visible = false;
            }
        }

        private void lbInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pbView.ImageLocation = "";
                lblDelete.Visible = true;
                btnDelete.Visible = true;
                string id = Convert.ToString(lbInfo.SelectedItem);
                id = id.Substring(0, 6);
                string id2 = id.Replace("id: ", "");
                string idf = id2.Replace(",", "");
                Main.idDelete = Convert.ToInt32(idf);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT `imagem` FROM `dados` WHERE `id`=@id;", conn);
                cmd.Parameters.AddWithValue("@id", idf);
                object imgBruta = cmd.ExecuteScalar();
                pbView.ImageLocation = imgBruta.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand delete = new MySqlCommand("SELECT `identifica` FROM `dados` WHERE `id`=@id;", conn);
                delete.Parameters.AddWithValue("@id", Main.idDelete);
                object id = delete.ExecuteScalar();
                int id2 = Convert.ToInt32(id);
                MySqlCommand delImg = new MySqlCommand("SELECT  `imagem` FROM `dados` WHERE `id`=@id;", conn);
                delImg.Parameters.AddWithValue("@id", Main.idDelete);
                object Img = delImg.ExecuteScalar();
                string caminho = delImg.ToString();
                File.Delete(caminho);
                MySqlCommand apagar = new MySqlCommand("DELETE FROM `colecao` WHERE `id` = @id;", conn);
                apagar.Parameters.AddWithValue("@id", id2);
                apagar.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDelete.Visible = false;
                lblDelete.Visible = false;
                MessageBox.Show("Dados apagados com sucesso na linha " + Main.idDelete + "\n" + "clique em ok", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
