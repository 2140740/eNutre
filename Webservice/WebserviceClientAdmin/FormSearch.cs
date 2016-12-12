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
    public partial class FormSearch : Form
    {

        private Service1Client client;
        private string token;

        public FormSearch(string token)
        {
            InitializeComponent();
            client = new Service1Client();
            this.token = token;
        }

        private void FormSeacrh_Load(object sender, EventArgs e)
        {

        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = "";

            //para converter o primeiro caracter para maiuscula
            

            if (textBoxSearch.Text == "" || comboBoxresource.SelectedItem == null)
            {
                MessageBox.Show("Tem de inserir o nome do produto na caixa de texto e seleccionar o recurso que procura.", "Erro", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if(comboBoxresource.SelectedItem=="Vegetais")
            {
                textBoxSearch.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxSearch.Text);

                Vegetais vegetal = client.GetVegetaisByNome(textBoxSearch.Text, token);

                textBoxOutput.Text = "Nome: " + vegetal.Nome + Environment.NewLine 
                    + "Calorias: " +vegetal.Calorias + Environment.NewLine 
                    + "Quantidade: " + vegetal.Quantidade;

            }
            else if (comboBoxresource.SelectedItem == "Restaurantes")
            {
                
                Restaurantes restaurante = client.GetRestaurantesByNome(textBoxSearch.Text, token);

                textBoxOutput.Text = "Nome: " + restaurante.Restaurante + Environment.NewLine
                    + "Item: " + restaurante.Item + Environment.NewLine
                    + "Quantidade: " + restaurante.Quantidade + Environment.NewLine
                    + "Calorias: " + restaurante.Calorias;
                    
            }

             else if (comboBoxresource.SelectedItem == "Exercícios")
            {
                textBoxSearch.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxSearch.Text);

                Exercicios exercicio = client.GetExerciciosByNome(textBoxSearch.Text, token);

                textBoxOutput.Text = "Nome: " + exercicio.Nome + Environment.NewLine
                    + "Calorias: " + exercicio.Calorias + Environment.NewLine
                    + "Met: " + exercicio.Met;
            }
        }

    }
}
