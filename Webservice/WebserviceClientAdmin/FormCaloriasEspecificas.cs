using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebserviceClientAdmin.ServiceReferenceWebservice;

namespace WebserviceClientAdmin
{
    public partial class FormCaloriasEspecificas : Form
    {
        private Service1Client client;
        private string token;
        private int auxCalorias = 0;
        private int auxTextboxCalorias = 0;
        private int aux = 0;
        Random rnd = new Random();

        public FormCaloriasEspecificas(string token)
        {
            InitializeComponent();
            client = new Service1Client();
            this.token = token;
        }

        private void buttonProcurar_Click(object sender, EventArgs e)
        {
            auxTextboxCalorias = Convert.ToInt16(textBoxCalorias.Text);
            try
            {
                Vegetais[] vegetais = client.GetVegetais(token);
                foreach (Vegetais v in vegetais.OrderBy(r => rnd.Next()))
                {
                    textBoxResultado.Text = Regex.Replace(textBoxResultado.Text, "(?<Text>.*)(?:[\r\n]?(?:\r\n)?)", "${Text}\r\n");
                    textBoxResultado.Text += printBook(v);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private string printBook(Vegetais vegetais)
        {

            auxCalorias = Convert.ToInt16(vegetais.Calorias);
            if (auxTextboxCalorias > auxCalorias)
            {
                
                
                
                if (aux <= auxTextboxCalorias)
                {
                    aux = aux + auxCalorias;
                    return "Nome: " + vegetais.Nome + "\nCalorias: " + vegetais.Calorias + "\nQuantidade: " + vegetais.Quantidade + "\n------------------" + Environment.NewLine;
                }
             
            }
            return "";
        }

        private void FormCaloriasEspecificas_Load(object sender, EventArgs e)
        {
            textBoxResultado.ScrollBars = ScrollBars.Vertical;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxCalorias.Text = "";
            textBoxResultado.Text = "";
            auxCalorias = 0;
            auxTextboxCalorias = 0;
            aux = 0;
        }
    }
}
