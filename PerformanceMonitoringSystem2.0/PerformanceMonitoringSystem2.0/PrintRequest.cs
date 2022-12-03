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
    public partial class PrintRequest : Form
    {
        public PrintRequest()
        {
            InitializeComponent();
        }

        public static PrintRequest instance; //creating an instance

        public Label lblPublicStudentPrint; //creating a public label for the student name
        public Label lblPublicMeritPrint; //creating a public label for the merit points
        public Label lblPublicDisciplinaryPrint; //creating a public label for the disciplinary points

        public Label lblPublicTotalPrint; // creating a public label for the total points

        public Label lblPublicStarsTotalPrint;//creating a public label for the total stars after erasing
        public Label lblPublicFlamesTotalPrint;//creating a public label for the total flames after erasing

        private void PrintRequest_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString(); //Displaying the current date on a label
            lblTime.Text = DateTime.Now.ToShortTimeString(); //Displaying the current time on a label

            instance = this; //store object data

            lblPublicStudentPrint = lblStudentPrint; //Connecting a public variable to the student name label inside PrintRequest
            lblPublicMeritPrint = lblMeritPrint; //Connecting a public variable to the merit points label inside PrintRequest
            lblPublicDisciplinaryPrint = lblDisciplinaryPrint; //Connecting a public variable to the disciplinary points label inside PrintRequest
            lblPublicTotalPrint = lblTotalPrint; //connecting the public label for total points to the one in PrintRequest

            lblPublicStarsTotalPrint = lblStarsTotalPrint; //Connecting a public variable to the total stars label inside StarForm
            lblPublicFlamesTotalPrint = lblFlamesTotalPrint; //Connecting a public variable to the total flames label inside StarForm
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Form2 monitorForm = new Form2(); //Connecting the current form (PrintRequest) with the performance monitor form (Form2) for easy going back
            monitorForm.Show(); //This shows the performance monitor form 
            this.Hide(); //This line of code hides the current form so there are not many forms on the screen which can confuse the user
        }
    }
}
