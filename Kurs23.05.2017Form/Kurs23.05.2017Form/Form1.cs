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

namespace Kurs23._05._2017Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int k = 0;
        string fayl = "";
        FileInfo f;
        private void faylYarad_Click(object sender, EventArgs e)
        {
            
            if (k == 1)
            {
                MessageBox.Show("sizin fayliniz "+fayl +" artiq movcuddur !!!" );
            }
            else
            {
                fayl = textBox1.Text + ".txt";
                 f = new FileInfo(fayl);
                f.Create().Close();
                MessageBox.Show("fayliniz "+fayl +" yaradildi !!!");
                k = 1;
            }
        }

        public void serhGonder_Click(object sender,EventArgs e)
        {
            if(fayl != "")
            {
                StreamWriter sw = f.AppendText();

                sw.WriteLine("ad:"+textBox2.Text);
                sw.WriteLine("soyad:"+textBox3.Text);
                sw.WriteLine("serh:"+textBox4.Text);
                sw.WriteLine("=========================");
                sw.Close();

                MessageBox.Show("Serhiniz gonderildi ^_^");
                comboBox1.Items.Add(textBox2.Text);
            }
            else
            {
                MessageBox.Show("Fayl yaradmaginniz xaiw olunur !!!");
            }
        }

        public void comboBox_change(object sender, EventArgs e)
        {
            //MessageBox.Show("change");
            if (fayl != "")
            {
                string str;
                string find = comboBox1.Text;
                StreamReader sr = new StreamReader(fayl);
                while ((str=sr.ReadLine())!=null)
                {
                    
                    if (str.Substring(0, 3) == "ad:")
                    {
                        if (str.Substring(3, str.Length - 3) == find)
                        {
                            sr.ReadLine();
                            string s = sr.ReadLine();
                            textBox5.Text = s.Substring(5,s.Length - 5);
                        }

                    }
                }
                sr.Close();
                
            }
          
        }
        
    }
}
