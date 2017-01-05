using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebserviceClientAdmin.ServiceReferenceWebservice;

namespace WebserviceClientAdmin
{
    public partial class FormDelete : Form
    {

        private Service1Client client;
        private string token;

        public FormDelete(string token)
        {
            InitializeComponent();
            client = new Service1Client();
            this.token = token;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende remover o elemento " + textBox1.Text + " ?", "Tem a certeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (radioButtonVegetais.Checked) {
                    try
                    {
                        Vegetais vegetal = client.GetVegetaisByNome(textBox1.Text, token);

                    DialogResult dialogResult2 = MessageBox.Show("Este elemento é o seguinte "+ 
                        "\nNome: " + vegetal.Nome + 
                        "\nCalorias: " + vegetal.Calorias + 
                        "\nQuantidade: " + vegetal.Quantidade +
                        "", "Tem a certeza que deseja eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult2 == DialogResult.Yes)
                    {
                        client.DeleteVegetaisByTitle(textBox1.Text.ToString(), token);
                    }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Impossível não existe na base de dados");
                    }

                }
                else if (radioButtonRestaurantes.Checked)
                {
                    try
                    {
                        Restaurantes restaurante = client.GetRestaurantesByNome(textBox1.Text, token);

                    DialogResult dialogResult2 = MessageBox.Show("Este elemento é o seguinte " +
                        "\nNome: " + restaurante.Restaurante +
                        "\nItem: " + restaurante.Item +
                        "\nQuantidade: " + restaurante.Quantidade +
                        "\nCalorias: " + restaurante.Calorias +
                    "", "Tem a certeza que deseja eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult2 == DialogResult.Yes)
                    {
                        client.DeleteRestauranteByTitle(textBox1.Text.ToString(), token);
                    }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Impossível não existe na base de dados");
                    }

                }

                else if (radioButtonExercícios.Checked)
                {
                    try
                    {
                        
                    
                    Exercicios exercicio = client.GetExerciciosByNome(textBox1.Text, token);

                    DialogResult dialogResult2 = MessageBox.Show("Este elemento é o seguinte " +
                        "\nNome: " + exercicio.Nome +
                        "\nCalorias: " + exercicio.Calorias +
                        "\nMet: " + exercicio.Met +
                    "", "Tem a certeza que deseja eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult2 == DialogResult.Yes)
                    {
                        client.DeleteExercicioisByTitle(textBox1.Text.ToString(), token);
                    }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Impossível não existe na base de dados");
                    }
                }
            }            
        }

        private void radioButtonVegetais_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
        }

        private void radioButtonRestaurantes_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
        }

        private void radioButtonExercícios_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = false;
        }
    }
}
