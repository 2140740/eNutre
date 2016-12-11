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
    public partial class FormLogin : Form
    {

        private Service1Client client;
        private string token;
        private string user;

        public FormLogin(Service1Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                user = textBoxUsername.Text;
                token = client.LogIn(textBoxUsername.Text, textBoxPassword.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                MessageBox.Show(ex.Message, "ERROR");
            }
            this.Close();
        }
        public string Token
        {
            get
            {
                return token;
            }
 }
        public string User
        {
            get
            {
                return user;
            }
        }
    }
    }