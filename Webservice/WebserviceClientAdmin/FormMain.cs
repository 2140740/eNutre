using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebserviceClientAdmin;
using WebserviceClientAdmin.ServiceReferenceWebservice;

namespace WebserviceClientAdmin { 


    public partial class FormMain : Form
    {

        private Service1Client client;
        private string token;
        private string user;

        public FormMain()
        {
            InitializeComponent();

            client = new Service1Client();
            comboBoxOp.Items.Add("Get Vegetais");
            comboBoxOp.Items.Add("Get Restaurantes");
            comboBoxOp.Items.Add("Get Exercicios");

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(token) && client.IsLoggedIn(token))
            {
                MessageBox.Show("A user already logged in: " + user + ". Please log out first.");
            }
            else
            {
                FormLogin formAuth = new FormLogin(client);

                DialogResult dialogResult = formAuth.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    token = formAuth.Token;
                    user = formAuth.User;
                    MessageBox.Show("LogIn successful: " + user);
                }
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(token) || !client.IsLoggedIn(token))
                {
                    MessageBox.Show("User is not logged in");
                }
                else
                {
                    client.LogOut(token);
                    token = null;
                    user = null;
                    MessageBox.Show("LogOut successful.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void buttonSignUp_Click_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(token) || !client.IsLoggedIn(token))
            {
                MessageBox.Show("User is not logged in.");
            }
            else if (!client.IsAdmin(token))
            {
                MessageBox.Show("User does not possess administration privileges.");
            }
            else
            {
                FormSignUp formSignUp = new FormSignUp(client, token);
                DialogResult dialogResult = formSignUp.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    MessageBox.Show("SignUp successful.");
                }
            }
        }

        private void buttonGo_Click_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            try
            {
                if (String.IsNullOrEmpty(token) || !client.IsLoggedIn(token))
                {
                    MessageBox.Show("User is not logged in.");
                }
                else
                {
                    switch (comboBoxOp.Text)
                    {

                        case "Get Vegetais":
                            Vegetais[] vegetais = client.GetVegetais(token);
                            foreach (Vegetais v in vegetais)
                        {
                                textBoxOutput.Text += printBookveg(v) + Environment.NewLine;
                            }
                            break;

                        case "Get Restaurantes":
                            Restaurantes[] restaurantes = client.GetRestaurantes(token);
                        foreach (Restaurantes r in restaurantes)
                        {
                            textBoxOutput.Text += printBookrest(r) + Environment.NewLine;
                        }
                        break;
             
                        case "Get Exercicios":
                            Exercicios[] exercicios = client.GetExercicio(token);
                        foreach (Exercicios ex in exercicios)
                        {
                            textBoxOutput.Text += printBookexer(ex) + Environment.NewLine;
                        }
                        break;

                        default:
                            MessageBox.Show("Operation not implemented.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private string printBookveg(Vegetais vegetais)
        {
            return "Nome: " + vegetais.Nome + Environment.NewLine
            + "Quantidade: " + vegetais.Quantidade + Environment.NewLine
            + "Calorais: " + vegetais.Calorias + Environment.NewLine;
        }

        private string printBookrest(Restaurantes restaurantes)
        {
            return "Nome: " + restaurantes.Restaurante + Environment.NewLine
            + "Item: " + restaurantes.Item + Environment.NewLine
            + "Quantidade: " + restaurantes.Quantidade + Environment.NewLine
            + "Calorais: " + restaurantes.Calorias + Environment.NewLine;
        }

        private string printBookexer(Exercicios exercicios)
        {
            return "Nome: " + exercicios.Nome + Environment.NewLine
            + "Calorias: " + exercicios.Calorias + Environment.NewLine
            + "MET: " + exercicios.Met + Environment.NewLine;
        }

    }
}
