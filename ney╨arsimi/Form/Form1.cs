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
    public partial class Form1 : Form
    {
        #region "Class"
        tulkur clsTulkur = new tulkur();
        neydarsimi clsNeydarsimi = new neydarsimi();
        #endregion

        #region "VARIABLES"
        public string nafn;

        public string day;
        public string month;
        public string year;
        public string byrja;

        public string endir;
        public string timi_byrja;
        public string timi_endir;
        public string vettvangur;
        public string kennitala;

        public ListViewItem items;
        public string[] List = new string[9];
        #endregion

        #region "Form 1"
        public Form1()
        {
            InitializeComponent();
        }
        #endregion 

        #region "Load Form" 
        private void Form1_Load(object sender, EventArgs e)
        {
            SelectDateByrja();
            SelectDateEndir();
            DisplayComboBox();
            DisplayListBox1();
            DisplayListView1();
        }

        public void DisplayComboBox()
        {
            comboBox1.DisplayMember = "Vettvangur";
            comboBox1.ValueMember = "Vettvangur";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Venjuleg vakt");
            comboBox1.Items.Add("Helgarvakt");
            comboBox1.Items.Add("Páskar");
            comboBox1.Items.Add("Sumardagurinn fyrsti");
            comboBox1.Items.Add("Verkalýðsdagurinn");
            comboBox1.Items.Add("Uppstigningardagur");
            comboBox1.Items.Add("Hvítasunnudagur og Annar í hvítasunnu");
            comboBox1.Items.Add("Íslenski þjóðhátíðardagurinn");
            comboBox1.Items.Add("Verslunarmannahelgi");
            comboBox1.Items.Add("Jól");
        }

        public void DisplayListBox1()
        {
            clsTulkur.HladaTulkur(listBox1);
        }

        public void SelectDateByrja()
        {
            //byrja = dateTimePicker1.Value.ToShortDateString();
            byrja = dateTimePicker1.Value.ToString("dd.MMMM.yyyy");
        }

        public void SelectDateEndir()
        {
            //endir = dateTimePicker2.Value.ToShortDateString();
            endir = dateTimePicker2.Value.ToString("dd.MMMM.yyyy");
        }

        public void DisplayListView1()
        {
            clsNeydarsimi.HladaNeydarsimi(listView1, byrja);
        }

        public void DisplayListBox1Again()
        {
            Form1_Load(this, null);
        }
        #endregion

        #region "Button - Form 2"
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        #endregion

        #region "Button - Form 3"
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.Show();
        }
        #endregion

        #region "Date"
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            byrja = dateTimePicker1.Value.ToString("dd.MMMM.yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            endir = dateTimePicker2.Value.ToString("dd.MMMM.yyyy");
        }
        #endregion

        #region "Listbox1"
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nafn = listBox1.GetItemText(listBox1.SelectedItem);
            Hlada_KT();
            naKennitala();
        }

        public void Hlada_KT()
        {
            clsTulkur.HladaKennitala(nafn);
        }

        public void naKennitala()
        {
            kennitala = clsTulkur.getKennitala();
        }
        #endregion

        #region "ComboBox1"
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vettvangur = comboBox1.SelectedItem.ToString();
        }
        #endregion

        #region "Button - Functions"
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nafn) && !string.IsNullOrWhiteSpace(byrja) && !string.IsNullOrWhiteSpace(endir) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(vettvangur))
            {
                DialogResult dialogResult = MessageBox.Show("Nafn : " + nafn + "\nFrá : " + byrja + "\nTil : " + endir + "\nByrjunartimi : " + textBox1.Text + "\nEndunartími : " + textBox2.Text + "\nVettvangur : " + vettvangur, "Er upplýsingar rétt?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    clsNeydarsimi.setKennitala(kennitala);
                    clsNeydarsimi.setByrja(byrja);
                    clsNeydarsimi.setEndir(endir);
                    clsNeydarsimi.setTimiByrja(textBox1.Text);
                    clsNeydarsimi.setTimiEndir(textBox2.Text);
                    clsNeydarsimi.setVettvangur(vettvangur);

                    clsNeydarsimi.SkraVinnaNeydarsimi();

                    DisplayListBox1Again();

                    MessageBox.Show("Túlkur hafa verið bókuð");
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Túlkur hafa ekki verið bókuð");
                }
            }
            else {
                MessageBox.Show("Vinsamlegast fylltu inn allar upplýsingar");
            }
        }
        #endregion

        #region "TextBox"
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox1.MaxLength = 5;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox2.MaxLength = 5;
        }
        #endregion

        #region "ListView1"
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                items = listView1.SelectedItems[0];

                //verk.setId(items.SubItems[0].Text);
                List[0] = items.SubItems[0].Text;
                List[1] = items.SubItems[1].Text;
                List[2] = items.SubItems[2].Text;
                List[3] = items.SubItems[3].Text;
                List[4] = items.SubItems[4].Text;
                List[5] = items.SubItems[5].Text;
                List[6] = items.SubItems[6].Text;

                if (clsNeydarsimi.getRok( Int32.Parse( List[0]) ) == 1)
                {
                    Form5 form5 = new Form5(List, this);
                    form5.Show();
                }

                else
                {
                   MessageBox.Show("Þvi miður að neyðarsími er afbókað.", "Tilkynning");
                }
            }
        }
        #endregion
    }
}
