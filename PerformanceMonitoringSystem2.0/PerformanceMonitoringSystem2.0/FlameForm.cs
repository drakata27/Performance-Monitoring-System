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
    public partial class FlameForm : Form
    {
        public FlameForm()
        {
            InitializeComponent();
        }

        public static FlameForm instance; //creating an instance

        public Label lblPublicStudentFlameForm; //creating a public label for the student name
        public Label lblPublicMeritFlameForm; //creating a public label for the merit points
        public Label lblPublicDisciplinaryFlameForm; //creating a public label for the disciplinary points

        public Label lblPublicTotalFlameForm;


        public Label lblPublicStarsTotalFlameForm;//creating a public label for the total stars after erasing
        public Label lblPublicFlamesTotalFlameForm;//creating a public label for the total flames after erasing

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Form2 monitorForm = new Form2(); //Connecting the current form (FlameForm) with the performance monitor form (Form2) for easy going back
            monitorForm.Show(); //This shows the performance monitor form 
            this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user
        }

        private void FlameForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString(); //Displaying the current date on a label
            lblTime.Text = DateTime.Now.ToShortTimeString(); //Displaying the current time on a label

            instance = this; //store object data
            lblPublicStudentFlameForm = lblStudentFlameForm; //Connecting a public variable to the student name label inside FlameForm

            lblPublicMeritFlameForm = lblMeritFlameForm; //Connecting a public variable to the merit points label inside FlameForm
            lblPublicDisciplinaryFlameForm = lblDisciplinaryFlameForm; //Connecting a public variable to the disciplinary points label inside FlameForm
            lblPublicTotalFlameForm = lblTotalFlameForm; //connecting the public label for total points to the one in FlameForm

            lblPublicStarsTotalFlameForm = lblStarsTotalFlameForm; //Connecting a public variable to the total stars label inside FlameForm
            lblPublicFlamesTotalFlameForm = lblFlamesTotalFlameForm; //Connecting a public variable to the total flames label inside
        }
    }
}
