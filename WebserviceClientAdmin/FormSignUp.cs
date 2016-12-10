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
    public partial class FormSignUp : Form
    {

        private Service1Client client;
        private string token;
        public FormSignUp(Service1Client client, string token)
        {
            InitializeComponent();

            this.client = client;
            this.token = token;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.Username = textBoxUsername.Text;
                user.Password = textBoxPassword.Text;
                user.Admin = radioButton1.Checked;
                client.SignUp(user, token);
                this.DialogResult = DialogResult.OK;
                }
             catch (Exception ex)
             {
                MessageBox.Show(ex.Message, "ERROR");
             }
          this.Close();
          }
       }
  }

