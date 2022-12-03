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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Storing the user input into variables
            decimal meritPts = NUD_Merits.Value;
            decimal discPts = NUD_Disc.Value;
            

            lblStudent.Text = txtFirstName.Text + " " + txtSurname.Text; //Displaying a student's name
            //Try catch statement for catching an error instead of crashing the program
            try
            {
                InstantiateMyNumericUpDown();
                DataRow row = ds.Tables[0].Rows[inc];
                row[1] = txtFirstName.Text;
                row[2] = txtSurname.Text;
                row[3] = txtCourse.Text;
                row[4] = Convert.ToInt32(NUD_Merits.Value);
                row[5] = Convert.ToInt32(NUD_Disc.Value);
                row[6] = txtDepartment.Text;
                row[7] = txtPhoneNumber.Text;
                row[8] = txtAddress.Text;
                row[9] = txtPostCode.Text;
                row[10] = txtEmail.Text;
                row[11] = txtStudentNumber.Text;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            try
            {
                objConnect.UpdateDatabase(ds);

                MessageBox.Show("Record Updated");
                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            try
            {
                //lblMeritPts.Text = txtMeritPts.Text;
                lblMeritPts.Text = Convert.ToString(NUD_Merits.Value);
                //lblMeritPts.Text = txtDisciplinaryPts.Text;
                lblDisciplinaryPts.Text = Convert.ToString(NUD_Disc.Value);

                lblTotal.Text = Convert.ToString(TotalPts2(Convert.ToInt32(NUD_Merits.Value), Convert.ToInt32(NUD_Disc.Value)));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //From here starts the calculating of stars and flames
            FlameForm flameForm = new FlameForm(); //Connecting the form that will generate a receipt in case a flame is given to a student
            StarForm starForm = new StarForm(); //Connecting the form that will generate a receipt in case a star is given to a student

            try
            {
                if (Convert.ToInt32(meritPts) >= 500 && Convert.ToInt32(meritPts) <= 999) //This if statement will display one star if the condition inside the parentheses is met. The sign && is the "and" operator which connects the two conditions
                {
                    lblStar.Text = Convert.ToString(1); // This is what will be displayed on the label. It is converted from integer to string so it can be displayed

                    starForm.Show(); //The form with the star receipt will open if the condition is met

                    this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user

                    StarForm.instance.lblPublicStudentStarForm.Text = lblStudent.Text; //connecting the student name label in Form2 to the one in starForm 
                    StarForm.instance.lblPublicMeritStarForm.Text = lblMeritPts.Text; //connecting the student merit points label in Form2 to the one in starForm 
                    StarForm.instance.lblPublicDisciplinaryStarForm.Text = lblDisciplinaryPts.Text; //connecting the student disciplinary points label in Form2 to the one in starForm 

                    StarForm.instance.lblPublicTotalStarForm.Text = lblTotal.Text; //Connecting the public total label in StarForm to the one in Form2
                }
                else if (Convert.ToInt32(meritPts) >= 1000 && Convert.ToInt32(meritPts) <= 1499) //This if statement will display two stars if the condition inside the parentheses is met. The operator ">=" means "greater than or equal"
                {
                    lblStar.Text = Convert.ToString(2); // This is what will be displayed on the label. It is converted from integer to string so it can be displayed
                    starForm.Show(); //The form with the star receipt will open if the condition is met
                    this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user

                    StarForm.instance.lblPublicStudentStarForm.Text = lblStudent.Text; //connecting the student name label in Form2 to the one in starForm 
                    StarForm.instance.lblPublicMeritStarForm.Text = lblMeritPts.Text; //connecting the student merit points label in Form2 to the one in starForm 
                    StarForm.instance.lblPublicDisciplinaryStarForm.Text = lblDisciplinaryPts.Text; //connecting the student disciplinary points label in Form2 to the one in starForm 
                    StarForm.instance.lblPublicTotalStarForm.Text = lblTotal.Text; //Connecting the public total label in StarForm to the one in Form2



                }
                else if (Convert.ToInt32(meritPts) >= 1500 && Convert.ToInt32(meritPts) <= 2000) //This if statement will display three stars if the condition inside the parentheses is met. The operator "<=" means "less than or equal"
                {
                    lblStar.Text = Convert.ToString(3); // This is what will be displayed on the label. It is converted from integer to string so it can be displayed
                    starForm.Show(); //The form with the star receipt will open if the condition is met
                    this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user

                    StarForm.instance.lblPublicStudentStarForm.Text = lblStudent.Text; //connecting the student name label in Form2 to the one in starForm 
                    StarForm.instance.lblPublicMeritStarForm.Text = lblMeritPts.Text; //connecting the student merit points label in Form2 to the one in starForm 
                    StarForm.instance.lblPublicDisciplinaryStarForm.Text = lblDisciplinaryPts.Text; //connecting the student disciplinary points label in Form2 to the one in starForm 
                    StarForm.instance.lblPublicTotalStarForm.Text = lblTotal.Text; //Connecting the public total label in StarForm to the one in Form2
                }
                else
                {
                    
                    lblStar.Text = "0";
                }

                //flames
                if (Convert.ToInt32(discPts) >= 500 && Convert.ToInt32(discPts) <= 999) //This if statement will display one flame if the condition inside the parentheses is met. The sign && is the "and" operator which connects the two conditions
                {
                    lblFlame.Text = Convert.ToString(1); // This is what will be displayed on the label. It is converted from integer to string so it can be displayed
                    flameForm.Show(); //The form with the flame receipt will open if the condition is met
                    this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user
                    FlameForm.instance.lblPublicStudentFlameForm.Text = lblStudent.Text; //connecting the student name label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicMeritFlameForm.Text = lblMeritPts.Text; //connecting the student merit points label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicDisciplinaryFlameForm.Text = lblDisciplinaryPts.Text; //connecting the student disciplinary points label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicTotalFlameForm.Text = lblTotal.Text; //Connecting the public total label in FlameForm to the one in Form2

                }
                else if (Convert.ToInt32(discPts) >= 1000 && Convert.ToInt32(discPts) <= 1499) //This if statement will display two flames if the condition inside the parentheses is met. The operator ">=" means "greater than or equal"
                {
                    lblFlame.Text = Convert.ToString(2); // This is what will be displayed on the label. It is converted from integer to string so it can be displayed
                    flameForm.Show(); //The form with the flame receipt will open if the condition is met
                    this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user




                    FlameForm.instance.lblPublicStudentFlameForm.Text = lblStudent.Text; //connecting the student name label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicMeritFlameForm.Text = lblMeritPts.Text; //connecting the student merit points label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicDisciplinaryFlameForm.Text = lblDisciplinaryPts.Text; //connecting the student disciplinary points label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicTotalFlameForm.Text = lblTotal.Text; //Connecting the public total label in FlameForm to the one in Form2


                }
                else if (Convert.ToInt32(discPts) >= 1500 && Convert.ToInt32(discPts) <= 2000) //This if statement will display three flames if the condition inside the parentheses is met. The operator "<=" means "less than or equal"
                {
                    lblFlame.Text = Convert.ToString(3); // This is what will be displayed on the label. It is converted from integer to string so it can be displayed
                    flameForm.Show(); //The form with the flame receipt will open if the condition is met
                    this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user


                    FlameForm.instance.lblPublicStudentFlameForm.Text = lblStudent.Text; //connecting the student name label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicMeritFlameForm.Text = lblMeritPts.Text; //connecting the student merit points label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicDisciplinaryFlameForm.Text = lblDisciplinaryPts.Text; //connecting the student disciplinary points label in Form2 to the one in FlameForm 
                    FlameForm.instance.lblPublicTotalFlameForm.Text = lblTotal.Text; //Connecting the public total label in FlameForm to the one in Form2
                }
                
                else
                {
                    lblFlame.Text = "0";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            //From here start the flames and stars erasing
            if (lblStar.Text == "0" && lblFlame.Text == "0") //Inside the parentheses is the condition
            {
                lblFlameFinal.Text = "0"; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "0"; //this is the result that will be displayed for the total stars if the condition is true
            }
            else if (lblStar.Text == "1" && lblFlame.Text == "0")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = lblStar.Text; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2



            }
            else if (lblStar.Text == "2" && lblFlame.Text == "0")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = lblStar.Text;//this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "3" && lblFlame.Text == "0")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = lblStar.Text; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "3" && lblFlame.Text == "1")
            {
                lblFlameFinal.Text = "0"; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "2";//this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2
                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "3" && lblFlame.Text == "2")
            {
                lblFlameFinal.Text = "1";//this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "2"; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2
                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "3" && lblFlame.Text == "3")
            {
                lblFlameFinal.Text = "2"; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "2"; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2
                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "2" && lblFlame.Text == "3")
            {
                lblFlameFinal.Text = "2"; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "1"; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2
                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "1" && lblFlame.Text == "3")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "0"; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2

                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2

            }
            else if (lblStar.Text == "0" && lblFlame.Text == "3")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = lblStar.Text; //this is the result that will be displayed for the total stars if the condition is true



                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2

            }
            else if (lblStar.Text == "1" && lblFlame.Text == "1")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = lblStar.Text; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2
                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "2" && lblFlame.Text == "1")
            {
                lblFlameFinal.Text = "0"; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = lblStar.Text; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2
                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "2" && lblFlame.Text == "2")
            {
                lblFlameFinal.Text = "1"; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "1"; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2
                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "1" && lblFlame.Text == "2")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "0"; //this is the result that will be displayed for the total stars if the condition is true

                StarForm.instance.lblPublicStarsTotalStarForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                StarForm.instance.lblPublicFlamesTotalStarForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2
                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2


            }
            else if (lblStar.Text == "0" && lblFlame.Text == "1")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "0"; //this is the result that will be displayed for the total stars if the condition is true


                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2

            }

            else if (lblStar.Text == "0" && lblFlame.Text == "2")
            {
                lblFlameFinal.Text = lblFlame.Text; //this is the result that will be displayed for the total flames if the condition is true
                lblStarsFinal.Text = "0"; //this is the result that will be displayed for the total stars if the condition is true


                FlameForm.instance.lblPublicStarsTotalFlameForm.Text = lblStarsFinal.Text; //connecting the final stars public variable to the final stars in Form2
                FlameForm.instance.lblPublicFlamesTotalFlameForm.Text = lblFlameFinal.Text; //connecting the final flames public variable to the final flames in Form2

            }
            else
            {
                MessageBox.Show("Something's wrong", "Sorry"); //This is a message if something goes wrong
            }
        }

        public int TotalPts2(int merit, int disciplinary)//Method for calculating the points
        {
            int total = merit - disciplinary;
            return total;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintRequest print = new PrintRequest(); //Connecting the print on request form to this one (Form2)
            print.Show(); //The PrintRequest form shows due to this line of code
            this.Hide(); //Hiding the current form (Form2) so it does not confuse the user with having multiple forms on the screen

            PrintRequest.instance.lblPublicStudentPrint.Text = lblStudent.Text; //connecting the public label for the student name to the student name label in form2
            PrintRequest.instance.lblPublicMeritPrint.Text = lblMeritPts.Text; //connecting the public label for the student's merit points to the student's merits label in form2
            PrintRequest.instance.lblPublicDisciplinaryPrint.Text = lblDisciplinaryPts.Text; //connecting the public label for the student disciplinary points to the student disciplinary points label in form2
            PrintRequest.instance.lblPublicTotalPrint.Text = lblTotal.Text; //connecting the public label for the student total points to the student total points label in form2
            PrintRequest.instance.lblPublicFlamesTotalPrint.Text = lblFlameFinal.Text; //connecting the public label for the student final flames to the student final flames label in form2
            PrintRequest.instance.lblPublicStarsTotalPrint.Text = lblStarsFinal.Text; //connecting the public label for the student final stars to the student final stars label in form2

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login logInForm = new Login(); // Connecting this form to Form1
            logInForm.Show();
            this.Close();//Closing the current form
        }

        private void btnHelp_Click(object sender, EventArgs e) //This button opens up help form
        {
            HelpForm help = new HelpForm();
            help.Show();
            this.Hide();
        }
        DatabaseConnection objConnect; //Variable with type DatabaseConnection, which is the class
        string conString; //String variable that holds the connection connection string from the Setting page

        DataSet ds; //When the GetConnection method is called, the DataSet will need to be put someewhere, which is this variable
        DataRow dRow; //This variable is for manipulating each row of the table

        int MaxRows;//Tells how many rows were pulled from the database table
        int inc = 0;// This variable is used to move from one record to another, and back again
        private void Form2_Load(object sender, EventArgs e)
        {
            //Try-Catch satement for preventing the program to crash and catch and display the error in the form of a message box
            try
            {
                objConnect = new DatabaseConnection(); // This is an object from the class "DatabaseConnection"
                conString = Properties.Settings.Default.StudentsConnectionString; //The connection string is placed here

                objConnect.connection_string = conString;//his allows us to pass over the connection string to the DatabaseConnection class
                objConnect.Sql = Properties.Settings.Default.SQL;

                ds = objConnect.GetConnection;
                MaxRows = ds.Tables[0].Rows.Count;//Counts how many rows are in the table

                NavigateRecord(); // Calling the method below
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }
        }

        private void NavigateRecord() //Method for navigating through the records
        {
            try
            {
                InstantiateMyNumericUpDown();
                dRow = ds.Tables[0].Rows[inc];

                txtFirstName.Text = dRow.ItemArray.GetValue(1).ToString();
                txtSurname.Text = dRow.ItemArray.GetValue(2).ToString();
                txtCourse.Text = dRow.ItemArray.GetValue(3).ToString();
                NUD_Merits.Value = Convert.ToInt32(dRow.ItemArray.GetValue(4));
                NUD_Disc.Value = Convert.ToInt32(dRow.ItemArray.GetValue(5));
                txtDepartment.Text = dRow.ItemArray.GetValue(6).ToString();
                txtPhoneNumber.Text = dRow.ItemArray.GetValue(7).ToString();
                txtAddress.Text = dRow.ItemArray.GetValue(8).ToString();
                txtPostCode.Text = dRow.ItemArray.GetValue(9).ToString();
                txtEmail.Text = dRow.ItemArray.GetValue(10).ToString();
                txtStudentNumber.Text = dRow.ItemArray.GetValue(11).ToString();


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e) //Button for going to the next student record
        {
            if (inc != MaxRows - 1)
            {
                inc++;
                NavigateRecord();
            }
            else
            {
                MessageBox.Show("Sorry, there are no more rows", "Last Record");
            }
        }

        private void btnBack_Click(object sender, EventArgs e) //Button for going back to the previous student record
        {
            if (inc > 0)
            {
                inc--;
                NavigateRecord();
            }
            else
            {
                MessageBox.Show("This is the first student record", "First Record");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) //Button for adding a new record
        {
            InstantiateMyNumericUpDown();

            txtFirstName.Clear();
            txtSurname.Clear();
            txtCourse.Clear();
            NUD_Merits.Value = 0;
            NUD_Disc.Value = 0;
            txtDepartment.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtPostCode.Clear();
            txtEmail.Clear();
            txtStudentNumber.Clear();

            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e) //Button for cancelling the addition of a new student record
        {
            NavigateRecord();

            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e) //Button for saving a student record
        {
            InstantiateMyNumericUpDown();
            DataRow row = ds.Tables[0].NewRow();
            row[1] = txtFirstName.Text;
            row[2] = txtSurname.Text;
            row[3] = txtCourse.Text;
            row[4] = Convert.ToInt32(NUD_Merits.Value);
            row[5] = Convert.ToInt32(NUD_Disc.Value);
            row[6] = txtDepartment.Text;
            row[7] = txtPhoneNumber.Text;
            row[8] = txtAddress.Text;
            row[9] = txtPostCode.Text;
            row[10] = txtEmail.Text;
            row[11] = txtStudentNumber.Text;

            ds.Tables[0].Rows.Add(row);

            try
            {
                objConnect.UpdateDatabase(ds);
                MaxRows = MaxRows + 1;
                inc = MaxRows - 1;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e) //Button for deleting a student record
        {
            try
            {
                ds.Tables[0].Rows[inc].Delete();
                objConnect.UpdateDatabase(ds);

                MaxRows = ds.Tables[0].Rows.Count;
                inc--;
                NavigateRecord();

                MessageBox.Show("Record deleted");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void InstantiateMyNumericUpDown() //Method that does not return a value for setting max and minvvalue for the numeric up down controls
        {
            NUD_Merits.Maximum = Convert.ToInt32(2000);
            NUD_Merits.Minimum = Convert.ToInt32(0);

            NUD_Disc.Maximum = Convert.ToInt32(2000);
            NUD_Disc.Minimum = Convert.ToInt32(0);
        } 
    }
}
