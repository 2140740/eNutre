using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebserviceClientAdmin.ServiceReferenceWebservice;

namespace WebserviceClientAdmin
{
    public partial class FormCaloriasExercicios : Form
    {
        private Service1Client client;
        private string token;
        private int auxCalorias = 0;
        private int auxTextboxCalorias = 0;
        private int aux = 0;
        Random rnd = new Random();

        public FormCaloriasExercicios(string token)
        {
            InitializeComponent();
            client = new Service1Client();
            this.token = token;
        }

        private void buttonProcuraExercicios_Click(object sender, EventArgs e)
        {
            auxTextboxCalorias = Convert.ToInt16(textBoxCalorias.Text);
            try
            {
                Exercicios[] exercicios = client.GetExercicio(token);
                foreach (Exercicios es in exercicios.OrderBy(r => rnd.Next()))
                {
                    textBoxResultado.Text = Regex.Replace(textBoxResultado.Text, "(?<Text>.*)(?:[\r\n]?(?:\r\n)?)", "${Text}\r\n");
                    textBoxResultado.Text += printBook(es);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private string printBook(Exercicios exercicios)
        {

            auxCalorias = Convert.ToInt16(exercicios.Calorias);
            if (auxTextboxCalorias > auxCalorias)
            {



                if (aux <= auxTextboxCalorias)
                {
                    aux = aux + auxCalorias;
                    return "Nome: " + exercicios.Nome + "\nCalorias: " + exercicios.Calorias + "\nMet: " + exercicios.Met + "\n------------------" + Environment.NewLine;
                }



            }
            return "";
        }

        private void FormCaloriasExercicios_Load(object sender, EventArgs e)
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
