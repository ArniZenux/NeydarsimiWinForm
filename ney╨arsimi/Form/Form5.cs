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
    public partial class Form5 : Form
    {
        #region "VARIABLES"
        public string[] List = new string[9];
        private Form1 form;
        #endregion

        #region "Form"
        public Form5(string[] lst, Form1 fm1)
        {
            InitializeComponent();
            List = lst;
            form = fm1;
        }
        #endregion

        #region "Buttons"
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(List, form);
            form4.Show();
            Close(); 
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(List, form);
            form6.Show(); 
            Close(); 
        }
        #endregion
    }
}
