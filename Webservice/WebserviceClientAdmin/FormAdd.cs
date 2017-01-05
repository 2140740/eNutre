using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebserviceClientAdmin.ServiceReferenceWebservice;

namespace WebserviceClientAdmin
{
    public partial class FormAdd : Form
    {

        private Service1Client client;
        private string token;

        public FormAdd(string token)
        {
            InitializeComponent();
            client = new Service1Client();
            this.token = token;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }
        
        private void buttonGravar_Click(object sender, EventArgs e)
        {
            if (radioButtonVegetais.Checked)
            {
                try
                {
                    Vegetais vegetal = new Vegetais();

                    vegetal.Calorias = textBoxCalorias.Text;
                    vegetal.Nome = textBoxNome.Text;
                    vegetal.Quantidade = textBoxQuantidade.Text;

                    client.AddVegetal(vegetal, token);

                    MessageBox.Show("Vegetal criado com sucesso!", "Sucesso", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }
            }
            else if (radioButtonRestaurantes.Checked)
            {
                try
                {
                    Restaurantes restaurantes = new Restaurantes();

                    restaurantes.Restaurante = textBoxNomeRestaurante.Text;
                    restaurantes.Item = textBoxItemRestaurante.Text;
                    restaurantes.Quantidade = textBoxQuantidadeRestaurante.Text;
                    restaurantes.Calorias = textBoxCaloriasRestaurante.Text;

                    client.AddRestaurante(restaurantes, token);

                    MessageBox.Show("Restaurante criado com sucesso!", "Sucesso", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }

            }
            else if (radioButtonExercicios.Checked)
            {
                try
                {
                    Exercicios exercicios = new Exercicios();

                    exercicios.Nome = textBoxNomeExercicio.Text;
                    exercicios.Calorias = textBoxCaloriasExercicio.Text;
                    exercicios.Met = textBoxMet.Text;

                    client.AddExercicio(exercicios, token);

                    MessageBox.Show("Exercicio criado com sucesso!", "Sucesso", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }
            }
        }

        private void radioButtonVegetais_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void radioButtonRestaurantes_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void radioButtonExercicios_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }
    }
}
