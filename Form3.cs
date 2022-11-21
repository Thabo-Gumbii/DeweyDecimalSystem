using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DeweySystemSystem
{
    public partial class Form3 : Form
    {
        private List<double> sortingnumbers = new List<double>();
        private List<String> callNumbers = new List<String>();
        private object selectedCallNumber;
        private int points = 0 ;
        private int countSelectedCallNumber = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Button to return to form2
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            callNumbers = getNewRandomCallNumber();

            for (int i =0; i<10; i++)
            {
                updateUI(i, callNumbers[i]);
            }

        }

        private void updateUI(int c, string callNumber)
        {
            switch (c)
            {
                case 0: label000.Text = callNumber; break;
                case 1: label100.Text = callNumber; break;
                case 2: label200.Text = callNumber; break;
                case 3: label300.Text = callNumber; break;
                case 4: label400.Text = callNumber; break;
                case 5: label500.Text = callNumber; break;
                case 6: label600.Text = callNumber; break;
                case 7: label700.Text = callNumber; break;
                case 8: label800.Text = callNumber; break;
                case 9: label900.Text = callNumber; break;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private List<String> getNewRandomCallNumber()
        {

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
               

                double newNumber = random.NextDouble();

                newNumber = newNumber + (random.Next(100, 999));

                newNumber = Math.Round(newNumber, 2);

                String callNumber = newNumber.ToString();

                String letter = ((char)random.Next('A', 'Z')).ToString() + ((char)random.Next('A', 'Z')).ToString() + ((char)random.Next('A', 'Z')).ToString();

                callNumbers.Add(callNumber + " " + letter);
                sortingnumbers.Add(newNumber);
            }

            return callNumbers;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel000_Paint(object sender, PaintEventArgs e)
        {

        }

        private void callNumberClicked(object sender, EventArgs e)
        {
            
            selectedCallNumber = ((Label)sender).Tag;
            int indexButton = Int16.Parse(selectedCallNumber.ToString());

            updateCallNumberPanel(sender);
            
            //MessageBox.Show(callNumbers[indexButton]);
        }

        private void updateCallNumberPanel(object s)
        {
            
            label000.BackColor = Color.Transparent;
            label100.BackColor = Color.Transparent;
            label200.BackColor = Color.Transparent;
            label300.BackColor = Color.Transparent;
            label400.BackColor = Color.Transparent;
            label500.BackColor = Color.Transparent;
            label600.BackColor = Color.Transparent;
            label700.BackColor = Color.Transparent;
            label800.BackColor = Color.Transparent;
            label900.BackColor = Color.Transparent;

            ((Label)s).BackColor = Color.FromArgb(192, 192, 255);
        }

        private void hidePanelOnClick(int indexButton)
        {
            switch (indexButton)
            {
                case 0: panel000.Hide(); break;
                case 1: panel100.Hide(); break;
                case 2: panel200.Hide(); break;
                case 3: panel300.Hide(); break;
                case 4: panel400.Hide(); break;
                case 5: panel500.Hide(); break;
                case 6: panel600.Hide(); break;
                case 7: panel700.Hide(); break;
                case 8: panel800.Hide(); break;
                case 9: panel900.Hide(); break;
            }

            //MessageBox.Show(callNumbers[indexButton]);
        }

        private void deweyDecimalButtonClicked(object sender, EventArgs e)
        {
            object tag = ((Button)sender).Tag;

            if (selectedCallNumber == null)
            {
                MessageBox.Show("Select a call Number Before","Warning Message"); return;
            }
            int indexCallNumber = Int16.Parse(selectedCallNumber.ToString());
            int indexDeweyButton = Int16.Parse(tag.ToString());

            hidePanelOnClick(indexCallNumber);

            replacingBooks(indexCallNumber,indexDeweyButton);

            selectedCallNumber = null;

        }

        private void replacingBooks(int indexCallNumber, int indexDeweyButton)
        {
            String callNumber = callNumbers[indexCallNumber];
            char fistletter = callNumber[0];

            int fistdigite = Int16.Parse(fistletter.ToString());
            countSelectedCallNumber = countSelectedCallNumber + 1;
           
            if (fistdigite == indexDeweyButton)
            {
                points = points + 1;
            }
           
            if (countSelectedCallNumber == 10)
            {
                button1.Visible = true;
                button14.Visible = true; 
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form4 form2 = new Form4(points);
            form2.Show();
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            selectedCallNumber = null;
            points = 0;
            countSelectedCallNumber = 0;

            callNumbers = getNewRandomCallNumber();

             panel000.Visible = true;
             panel100.Visible = true;
             panel200.Visible = true;
             panel300.Visible = true;
             panel400.Visible = true;
             panel500.Visible = true;
             panel600.Visible = true;
             panel700.Visible = true;
             panel800.Visible = true;
             panel900.Visible = true;
            button1.Visible = false;
            button14.Visible = false;

            for (int i = 0; i < 10; i++)
            {
                updateUI(i, callNumbers[i]);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sort the Dewey Decimal Numbers In Acending order");
            double sortingenteries = 0;
            double[] sortingarray = new double [10];
            sortingnumbers.Sort();
            for (int count=0; count < sortingnumbers.Count; count++)
            {
                sortingenteries = double.Parse(Interaction.InputBox("Enter Only Category Numbers", "Sorting", "", 20, 20));
                sortingarray[count]=sortingenteries;
            }
            Array.Sort(sortingarray);
            for (int i = 0; i < sortingarray.Length; i++)
            {

                if (sortingnumbers[i]== sortingarray[i])
                {
                    
                    points = points + 1;
                    
                }
                    
            }
            MessageBox.Show("calculating scores");
            if (points == 10)
            {
                MessageBox.Show("Well Done Check Your Scores");
                button1.Visible = true;
                button14.Visible = true;
            }
            else
            {
                MessageBox.Show("Scores are done please check");
                button1.Visible = true;
                button14.Visible = true;
            }
        }
    }
}
