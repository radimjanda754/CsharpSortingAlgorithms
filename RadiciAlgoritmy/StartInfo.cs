using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RadiciAlgoritmy
{
    public partial class StartInfo : Form
    {
        public StartInfo()
        {
            InitializeComponent();
        }

        public string TryToRead()
        // Pokusi se precist informaci, popr ji necha vytvorit
        {
            try
            {
                StreamReader sr = new StreamReader("sinfost.txt");
                sr.ReadLine();
                string temp = sr.ReadLine();
                sr.Close();
                return (temp);
            }
            catch
            {
                Reset();
                return ("POVOLENO");
            }
            return ("");
            
        }

        private void Reset()
        // Vyresetovani informace (defalutne POVOLENO), popr necha soubor vytvorit
        {
            StreamWriter sw = new StreamWriter("sinfost.txt");
            sw.WriteLine(" - ZOBRAZOVAT UVODNI ZPRAVU: -");
            sw.WriteLine("POVOLENO");
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
            //Button OK, zavre okno popr zakaze zobrazovani uvodni zpravi
        {
            if (checkBox1.Checked == true)
            {
                StreamWriter sw = new StreamWriter("sinfost.txt");
                sw.WriteLine(" - ZOBRAZOVAT UVODNI ZPRAVU: -");
                sw.WriteLine("ZAKAZANO");
                sw.Close();
            }
            Close();
        }
    }
}
