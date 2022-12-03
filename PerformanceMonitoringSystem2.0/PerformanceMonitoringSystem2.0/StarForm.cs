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
    public partial class StarForm : Form
    {
        public static StarForm instance; //creating an instance
        public Label lblPublicStudentStarForm; //creating a public label for the student name
        public Label lblPublicMeritStarForm; //creating a public label for the merit points
        public Label lblPublicDisciplinaryStarForm; //creating a public label for the disciplinary points
                                                    // public Label lblPublicStarsStarForm; //creating a public label for the stars
                                                    //public Label lblPublicFlamesStarForm; //creating a public label for the flames
        public Label lblPublicTotalStarForm; // creating a public label for the total points

        public Label lblPublicStarsTotalStarForm;//creating a public label for the total stars after erasing
        public Label lblPublicFlamesTotalStarForm;//creating a public label for the total flames after erasing
        public StarForm()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Form2 monitorForm = new Form2(); //Connecting the current form (StarForm) with the performance monitor form (Form2) for easy going back
            monitorForm.Show(); //This shows the performance monitor form 
            this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user
        }

        private void StarForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString(); //Displaying the current date on a label
            lblTime.Text = DateTime.Now.ToShortTimeString(); //Displaying the current time on a label

            instance = this; //store object data
            lblPublicStudentStarForm = lblStudentStarForm; //Connecting a public variable to the student name label inside StarForm

            lblPublicMeritStarForm = lblMeritStarForm; //Connecting a public variable to the merit points label inside StarForm
            lblPublicDisciplinaryStarForm = lblDisciplinaryStarForm; //Connecting a public variable to the disciplinary points label inside StarForm
            lblPublicTotalStarForm = lblTotalStarForm; //connecting the public label for total points to the one in StarForm

            lblPublicStarsTotalStarForm = lblStarsTotalStarForm; //Connecting a public variable to the total stars label inside StarForm
            lblPublicFlamesTotalStarForm = lblFlamesTotalStarForm; //Connecting a public variable to the total flames label inside StarForm
        }
    }
}
