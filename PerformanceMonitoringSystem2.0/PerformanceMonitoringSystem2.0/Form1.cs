using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceMonitoringSystem2._0
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();// Linking the second form to this one

            string UsernameAbraham = "AbrahamC"; // In this variable I will store the first teacher's name. The data type is "string" represents text.
            string PasswordAbraham = "abraham123"; // In this variable I will store the first teacher's password. The data type is again "string"
            string User1 = txtUser.Text; //This variable will allow the first user to enter their username in the username textbox 
            string Pass1 = txtPassword.Text; //This variable will allow the first user to enter their password in the password textbox

            string UsernameBraydon = "BraydonJ"; // In this variable I will store the second username. The data type is "string" represents text.
            string PasswordBraydon = "braydon123"; // In this variable I will store the second user's password. The data type is again "string"
            string User2 = txtUser.Text; //This variable will allow the second user to enter their username in the username textbox 
            string Pass2 = txtPassword.Text; //This variable will allow the second user to enter their password in the password textbox

            string UsernameKyle = "KyleS"; // In this variable I will store the third username. The data type is "string" represents text.
            string PasswordKyle = "kyle123"; // In this variable I will store the third user's password. The data type is again "string"
            string User3 = txtUser.Text; //This variable will allow the third user to enter their username in the username textbox 
            string Pass3 = txtPassword.Text; //This variable will allow the third user to enter their password in the password textbox

            string UsernameElena = "ElenaB"; // In this variable I will store the fourth username. The data type is "string" represents text.
            string PasswordElena = "elena123"; // In this variable I will store the fourth user's password. The data type is again "string"
            string User4 = txtUser.Text; //This variable will allow the fourth user to enter their username in the username textbox 
            string Pass4 = txtPassword.Text; //This variable will allow the fourth user to enter their password in the password textbox

            string UsernameLucia = "LuciaS"; // In this variable I will store the fifth username. The data type is "string" represents text.
            string PasswordLucia = "lucia123"; // In this variable I will store the fifth user's password. The data type is again "string"
            string User5 = txtUser.Text; //This variable will allow the fifth user to enter their username in the username textbox 
            string Pass5 = txtPassword.Text; //This variable will allow the fifth user to enter their password in the password textbox

            if ((UsernameAbraham == User1) && (PasswordAbraham == Pass1)) //This is an "if statement" and the first part of it where I give the first condition. The "UsernameAbraham" variable needs to equal to "User1" variable to let the user onto the next form. The same with "PasswordAbraham" and "Pass1" 
            {
                MessageBox.Show("Welcome Mr Abraham Chavayda!", "Welcome!"); //This is the output message which welcomes the user, given the condition their details are correct
                secondForm.Show();//This line of code shows the second form if the condition is met
                this.Hide();// This instruction hides the login form, so that there are not multiple forms on the screen which will confuse and annoy the user   
            }
            else if ((UsernameBraydon == User2) && (PasswordBraydon == Pass2)) //This is a conditional statement performed after an if statement. If it is true performs a function. The && sign stands for "and" 
            {
                MessageBox.Show("Welcome Mr Braydon Jeffress!", "Welcome!"); // This output message welcomes the second user
                secondForm.Show(); //This line of code shows the second form if the condition is met
                this.Hide(); // This instruction hides the login form
            }
            else if ((UsernameKyle == User3) && (PasswordKyle == Pass3)) //This is another else if statement which comes after the previous one.
            {
                MessageBox.Show("Welcome Mr Kyle Shadler!", "Welcome!"); // This output message welcomes the third user
                secondForm.Show(); //This line of code shows the second form if the condition is met
                this.Hide(); // This instruction hides the login form
            }
            else if ((UsernameElena == User4) && (PasswordElena == Pass4)) //This is another else if statement which comes after the previous one.
            {
                MessageBox.Show("Welcome Mrs Elena Bastianelli!", "Welcome!"); // This output message welcomes the fourth user
                secondForm.Show();//This line of code shows the second form if the condition is met
                this.Hide(); // This instruction hides the login form
            }
            else if ((UsernameLucia == User5) && (PasswordLucia == Pass5)) //This is another else if statement which comes after the previous one.
            {
                MessageBox.Show("Welcome Mrs Lucia Spencer!", "Welcome!"); // This output message welcomes the fifth user
                secondForm.Show();//This line of code shows the second form if the condition is met
                this.Hide(); // This instruction hides the login form
            }
            else //This is an else statement and it is executed if the previous statements are not true. In this case, informing the user that their login details are wrong 
            {
                MessageBox.Show("Something is not right. Please check your details again and ensure there is no space after the last character of your username and password", "Sorry"); //This messagebox informs the user to check the details they have entered because they do not match with the stored ones.
            }
        }

        private void chkShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowHide.Checked) //If the checbox is checked, it will show the password 
            {
                txtPassword.UseSystemPasswordChar = false; //This instruction disables the system password character type, which reveals the password
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true; //This instruction enables the system password character type, which hide the password
            }
        }
    }
}
