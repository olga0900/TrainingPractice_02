using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingPractice_02
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Label firstclick = null;
        Label secondclick = null;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "c","f",
            "b","c",
            "f","b"
         };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstclick == null)
                {
                    firstclick = clickedLabel;
                    firstclick.ForeColor = Color.Black;
                    return;
                }

                secondclick = clickedLabel;
                secondclick.ForeColor = Color.Black;

                CheckForWinner();

                if (firstclick.Text == secondclick.Text)
                {
                    firstclick = null;
                    secondclick = null;
                    return;
                }
                timer1.Start();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstclick.ForeColor = firstclick.BackColor;
            secondclick.ForeColor = secondclick.BackColor;
            firstclick = null;
            secondclick = null;
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("Молодец!");
            Close();
        }
    }
}
