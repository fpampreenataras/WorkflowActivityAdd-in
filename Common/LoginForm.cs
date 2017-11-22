using System;
using Aras.IOM;
using System.Windows.Forms;

namespace Common
{
    public partial class LoginForm : Form
    {
        private Innovator _inn = null;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void URL_entered(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            HttpServerConnection conn = IomFactory.CreateHttpServerConnection(URLTextBox.Text, DBsComboBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
            _inn = IomFactory.CreateInnovator(conn);
            this.Close();
        }

        public Innovator Inn
        {
            get
            {
                return _inn;
            }
        }

        private void Database_Click(object sender, EventArgs e)
        {

            HttpServerConnection server = IomFactory.CreateHttpServerConnection(URLTextBox.Text);
            string[] dbs = server.GetDatabases();
            DBsComboBox.Items.Clear();
            DBsComboBox.Items.AddRange(dbs);
        }
    }
}
