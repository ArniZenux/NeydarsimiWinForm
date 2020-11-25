using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neyðarsimi
{
    public partial class Form2 : Form
    {
        #region "Class"
        tulkur clsTulkur = new tulkur();
        #endregion

        #region "VARIABLES"
        public string nafn;
        public string kennitala; 

        private Form1 form1; 
        #endregion 

        #region "Form"
        public Form2(Form1 fm1)
        {
            InitializeComponent();
            form1 = fm1; 
        }
        #endregion

        #region "Load Form"
        private void Form2_Load(object sender, EventArgs e)
        {
            DisplayListBox1();
        }

        public void DisplayListBox1()
        {
            clsTulkur.HladaTulkur(listBox1);
        }
        #endregion

        #region "Buttons"
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                clsTulkur.setKennitala(textBox1.Text);
                clsTulkur.setNafn(textBox2.Text);
                clsTulkur.BreytaTulkur();

                form1.DisplayListBox1Again();
                
                MessageBox.Show("Tulkur hefur verið breyttur");

                Close();
            }
            else
            {
                MessageBox.Show("Vinsamlegast fylltu inn allar upplýsingar");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                clsTulkur.setKennitala(textBox1.Text);
                clsTulkur.setNafn(textBox2.Text);
                clsTulkur.EydaTulkur();

                form1.DisplayListBox1Again();
                
                MessageBox.Show("Tulkur hefur verið eyðið");

                Close();
            }
            else
            {
                MessageBox.Show("Vinsamlegast fylltu inn allar upplýsingar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region "ListBox + TextBoxes"
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nafn = listBox1.GetItemText(listBox1.SelectedItem);
            HladaTextBox(); 
        }

        public void HladaTextBox()
        {
            clsTulkur.HladaEinnTulkur(nafn, textBox1, textBox2);
        }
        #endregion 
    }
}