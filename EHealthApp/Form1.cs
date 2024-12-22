using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EHealthApp
{
    public partial class Form1 : Form
    {
        double height, weight, bmi;
        string classification;

        const string AppName = "E-Health BMI Monitor";
        enum Gender { Pria, Wanita };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAge.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            cmbGender.SelectedIndex = -1;
            lblBMI.Text = "-";
            lblClassification.Text = "-";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                height = double.Parse(txtHeight.Text) / 100; 
                weight = double.Parse(txtWeight.Text);

                bmi = weight / (height * height);
                lblBMI.Text = bmi.ToString("F2");

                if (bmi < 18.5)
                    classification = "Kekurangan Berat Badan";
                else if (bmi < 24.9)
                    classification = "Normal";
                else if (bmi < 29.9)
                    classification = "Kelebihan Berat Badan";
                else
                    classification = "Obesitas";

                lblClassification.Text = classification;
            }
            catch (Exception)
            {
                MessageBox.Show("Masukkan data yang valid!", AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("E-Health BMI Monitor\nVersi 1.0\nDibuat oleh Dicky April Zahdi", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
