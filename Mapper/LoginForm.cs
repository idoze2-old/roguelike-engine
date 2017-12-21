using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapper
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            if(DAL.UserMethods.UserExists(Username_TextBox.Text, Password_TextBox.Text))
            {
                Program.auth = true;
                Program.UserID = DAL.UserMethods.GetUser(Username_TextBox.Text, Password_TextBox.Text).ID;
                this.Close();
            }
            else
            {
                Log_Label.Text = "Invalid Login.";
            }
        }

        private void Username_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        
            
        
    }
}
