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
            textBoxSearch.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxSearch.Text);

            if (textBoxSearch.Text == "" || comboBoxresource.SelectedItem == null)
            {
                MessageBox.Show("Tem de inserir o nome do produto na caixa de texto e seleccionar o recurso que procura.", "Erro", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if(comboBoxresource.SelectedItem=="Vegetais")
            {
                Vegetais[] vegetais = client.GetVegetais(token);
                foreach (Vegetais v in vegetais)
                {
                    textBoxOutput.Text += printBookVeg(v);
                }
            }
            else if (comboBoxresource.SelectedItem == "Restaurantes")
            {
                Restaurantes[] restaurantes = client.GetRestaurantes(token);
                foreach (Restaurantes r in restaurantes)
                {
                    textBoxOutput.Text += printBookRest(r);
                }
            }

             else if (comboBoxresource.SelectedItem == "Exercícios")
            {
                Exercicios[] exercicios = client.GetExercicio(token);
                foreach (Exercicios ex in exercicios)
                {
                    textBoxOutput.Text += printBookExer(ex);
                }
            }
        }

        private string printBookVeg(Vegetais vegetais)
        {
            if (vegetais.Nome.Contains(textBoxSearch.Text))
            {
                return "Nome: " + vegetais.Nome + Environment.NewLine
                       + "Quantidade: " + vegetais.Quantidade + Environment.NewLine
                       + "Calorias: " + vegetais.Calorias + Environment.NewLine + Environment.NewLine;
            }
            else
            {
                return null;
            }
        }        private string printBookRest(Restaurantes restaurantes)
        {
            if (restaurantes.Restaurante.Contains(textBoxSearch.Text))
            {
                return "Nome: " + restaurantes.Restaurante + Environment.NewLine
                       + "Item: " + restaurantes.Item + Environment.NewLine
                       + "Quantidade" + restaurantes.Quantidade + Environment.NewLine
                       +"Calorias: " + restaurantes.Calorias + Environment.NewLine + Environment.NewLine;

            }
            else
            {
                return null;
            }
        }        private string printBookExer(Exercicios exercicios)
        {
            if (exercicios.Nome.Contains(textBoxSearch.Text))
            {
                return "Nome: " + exercicios.Nome + Environment.NewLine
                       + "Calorias: " + exercicios.Calorias + Environment.NewLine
                       + "Met: " + exercicios.Met + Environment.NewLine + Environment.NewLine;
            }
            else
            {
                return null;
            }
        }
    }
}
