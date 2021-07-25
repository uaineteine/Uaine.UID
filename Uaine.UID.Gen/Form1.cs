using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uaine.UID
{
    public partial class Form1 : Form
    {
        Random rand;
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                UniqueID newid = new UniqueID(ref rand, true);
                textBox1.Text += newid.ParseIntoHexaDecimalString(".");
                textBox1.Text += System.Environment.NewLine;
                textBox2.Text += newid.ToString();
                textBox2.Text += System.Environment.NewLine;
            }
        }
    }
}
