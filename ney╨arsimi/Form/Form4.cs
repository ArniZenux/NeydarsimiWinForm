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
    public partial class Form4 : Form
    {
        #region "Class"
        tulkur clsTulkur = new tulkur();
        neydarsimi clsNeydarsimi = new neydarsimi();
        #endregion

        #region "VARIABLES"
        public string nafn;
        public string kennitala;
        public string vettvangur;
        public string byrja;
        public string endir;
        public string[] List = new string[9];

        private Form1 form4;
        #endregion

        #region "Form"
        public Form4(string[] lst, Form1 frm)
        {
            InitializeComponent();
            List = lst;
            form4 = frm;
        }
        #endregion

        #region "Form Load"
        private void Form4_Load(object sender, EventArgs e)
        {
            hladaAllt();
            DisplayListBox1();
        }

        public void DisplayListBox1()
        {
            clsTulkur.HladaTulkur(listBox1);
        }

        public void hladaAllt()
        {
            label32.Text = List[2];
            label31.Text = List[3];
            label29.Text = List[4];
            label28.Text = List[5];
            label30.Text = List[6];
        }
        #endregion

        #region "Buttons"     
           #region "Skipta" 
                #region "Listbox1"
                private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    nafn = listBox1.GetItemText(listBox1.SelectedItem);
                    List[1] = nafn;
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

                #region "Buttons"
                private void button3_Click(object sender, EventArgs e)
                {
                      DialogResult dialogResult = MessageBox.Show("Nafn : " + List[1] + "\nFrá : " + List[2] + "\nTil : " + List[3] + "\nByrjunartimi : " + List[4] + "\nEndunartími : " + List[5] + "\nVettvangur : " + List[6], "Á að skipta túlk ?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            clsNeydarsimi.setNumber(Int32.Parse( List[0]) );
                            
                            //..AFRITA..
                            clsNeydarsimi.setKennitala(kennitala);
                            clsNeydarsimi.setByrja(List[2]);
                            clsNeydarsimi.setEndir(List[3]);
                            clsNeydarsimi.setTimiByrja(List[4]);
                            clsNeydarsimi.setTimiEndir(List[5]);
                            clsNeydarsimi.setVettvangur(List[6]);
                            
                            clsNeydarsimi.skiptaUmTulk();

                            MessageBox.Show("Túlkur hafa verið skipta");

                            form4.DisplayListBox1Again();
                
                            Close(); 
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("Túlkur hafa ekki verið skipta");
                        }
                }

                private void button5_Click_1(object sender, EventArgs e)
                {
                    Close();
                }
            #endregion
        #endregion
          
        #endregion
    }
}