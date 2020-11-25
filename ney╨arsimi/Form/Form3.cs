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
    public partial class Form3 : Form
    {
        #region "Class"
        tulkur clsTulkur = new tulkur();
        #endregion 

        #region "VARIABLES"
        public string nafn;
        public string kennitala;
        private Form1 form1;
        #endregion
        
        #region "Form3"
        public Form3(Form1 fm1)
        {
            InitializeComponent();
            form1 = fm1; 
        }
        #endregion 
        
        #region "Textboxes"
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox1.MaxLength = 10;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox2.MaxLength = 75;
        }
        #endregion

        #region "Buttons"
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                clsTulkur.setKennitala(textBox1.Text);
                clsTulkur.setNafn(textBox2.Text);
                clsTulkur.SkraTulkur();

                form1.DisplayListBox1Again();

                MessageBox.Show("Túlkur hefur verið bókuð");

                Close();
            }
            else
            {
                MessageBox.Show("Vinsamlegast fylltu inn allar upplýsingar");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
