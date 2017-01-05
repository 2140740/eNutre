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

namespace WebserviceClientAdmin
{
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
            addToolStripMenuItem.Visible = false;
            deleteToolStripMenuItem.Visible = false;
            searchToolStripMenuItem.Visible = true;

            if (!String.IsNullOrEmpty(token) && client.IsLoggedIn(token))
            {
                MessageBox.Show("A user already logged in: " + user + ". Please log out first.");
            }
        }

        private void buttonGo_Click_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
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
                            dataGridView1.DataSource = vegetais;
                            break;

                        case "Get Restaurantes":
                            Restaurantes[] restaurantes = client.GetRestaurantes(token);
                            dataGridView1.DataSource = restaurantes;
                            break;

                        case "Get Exercicios":
                            Exercicios[] exercicios = client.GetExercicio(token);
                            dataGridView1.DataSource = exercicios;

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

        private void buttonSearch_Click(object sender, EventArgs e)
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

            }
        }

        private void logIn_Click(object sender, EventArgs e)
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

                    if (client.IsAdmin(token))
                    {
                        addToolStripMenuItem.Visible = true;
                        deleteToolStripMenuItem.Visible = true;

                    }
                    else
                    {
                        searchToolStripMenuItem.Visible = true;
                    }
                }
            }
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            addToolStripMenuItem.Visible = false;
            deleteToolStripMenuItem.Visible = false;

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

        private void signUp_Click(object sender, EventArgs e)
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

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch formSeacrh = new FormSearch(token);
            formSeacrh.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd(token);
            formAdd.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete formDelete = new FormDelete(token);
            formDelete.ShowDialog();
        }

    }
}