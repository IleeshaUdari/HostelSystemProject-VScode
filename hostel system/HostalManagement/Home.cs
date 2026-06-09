using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostalManagement
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            students studentsForm = new students();
            studentsForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rooms roomForm = new rooms();
            roomForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            warden wardenForm = new warden();
            wardenForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            complain complaintsForm = new complain();
            complaintsForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dining diningForm = new dining();
            diningForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            maintatinance maintainForm = new maintatinance();
            maintainForm.Show();
            this.Hide();
        }
    }
}
