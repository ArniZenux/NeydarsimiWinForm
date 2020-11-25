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
    public partial class Form6 : Form
    {
        #region "Class"
        neydarsimi clsNeydarsimi = new neydarsimi();
        #endregion

        #region "VARIABLES"
        public string vettvangur;
        public string byrja;
        public string endir;
        public string timiByrja;
        public string timiEndir;
        public string[] List = new string[6];

        private Form1 form;
        #endregion

        #region "Form"
        public Form6(string[] lst, Form1 fm1)
        {
            InitializeComponent();
            List = lst;
            form = fm1; 
        }
        #endregion

        #region "Form load"
        private void Form6_Load(object sender, EventArgs e)
        {
            DisplayComboBox();
            hladaAllt(); 
        }
        
        public void DisplayComboBox()
        {
            comboBox2.DisplayMember = "Vettvangur";
            comboBox2.ValueMember = "Vettvangur";
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Venjuleg vakt");
            comboBox2.Items.Add("Helgarvakt");
            comboBox2.Items.Add("Páskar");
            comboBox2.Items.Add("Sumardagurinn fyrsti");
            comboBox2.Items.Add("Verkalýðsdagurinn");
            comboBox2.Items.Add("Uppstigningardagur");
            comboBox2.Items.Add("Hvítasunnudagur og Annar í hvítasunnu");
            comboBox2.Items.Add("Íslenski þjóðhátíðardagurinn");
            comboBox2.Items.Add("Verslunarmannahelgi");
            comboBox2.Items.Add("Jól");
        }

        public void hladaAllt()
        {
            label27.Text = List[1];
            label2.Text = List[2];
            label3.Text = List[3];
            label6.Text = List[4];
            label5.Text = List[5];
            label4.Text = List[6];
        }
        #endregion
   
        #region "Date"
        private void dateTimePicker3_ValueChanged_1(object sender, EventArgs e)
        {
            endir = dateTimePicker3.Value.ToString("dd.MMMM.yyyy");
            List[3] = endir;
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            byrja = dateTimePicker4.Value.ToString("dd.MMMM.yyyy");
            List[2] = byrja;
        }
        #endregion

        #region "TextBox"
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            timiByrja = textBox4.Text;
            List[4] = timiByrja;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            timiEndir = textBox3.Text;
            List[5] = timiEndir;
        }
        #endregion
 
        #region "ComboBox1"
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            vettvangur = comboBox2.SelectedItem.ToString();
            List[6] = vettvangur;
        }
        #endregion

        #region "Button"
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Nafn : " + List[1] + "\nFrá : " + List[2] + "\nTil : " + List[3] + "\nByrjunartimi : " + List[4] + "\nEndunartími : " + List[5] + "\nVettvangur : " + List[6], "Er upplýsingar rétt ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                clsNeydarsimi.setNumber(Int32.Parse(List[0]));
                clsNeydarsimi.setByrja(List[2]);
                clsNeydarsimi.setEndir(List[3]);
                clsNeydarsimi.setTimiByrja(List[4]);
                clsNeydarsimi.setTimiEndir(List[5]);
                clsNeydarsimi.setVettvangur(List[6]);

                clsNeydarsimi.breytaNeydarsimi();

                MessageBox.Show("Neyðarsími hafa verið breytt");

                form.DisplayListBox1Again();

                Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Neyðarsími hafa ekki verið breytt");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close(); 
        }
        #endregion
    }
}
