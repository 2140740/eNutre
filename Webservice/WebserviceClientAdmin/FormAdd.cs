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
    public partial class FormAdd : Form
    {
        private Service1Client client;
        private string token;

        public FormAdd(string token)
        {
            InitializeComponent();
            client = new Service1Client();
            this.token = token;

        }

        private void textBoxCalorias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBoxCalorias.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char) Keys.Back;
            }
        }

        private void textBoxNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            }
        }

        
        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
