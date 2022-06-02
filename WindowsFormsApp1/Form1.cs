using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl((e.KeyChar)))
                e.Handled = true;
            base.OnKeyPress(e);
        }
        public int znafza = 0;
        public string vych(string um,string vy)
        {   string raz="";
            int uml = um.Length - 1;
            int vyl=vy.Length - 1;
            int m = 0;
            while(vyl>=0)
            {
                int a = m ;
                a+=Convert.ToInt32(um[uml]) - Convert.ToInt32(vy[vyl]);
                if (a < 0)
                {
                    m = -1;
                    a += 10;
                }
                else m = 0;
                raz=Convert.ToString(a)+raz;
                uml--;
                vyl--;
            }
            return raz;
        }
        public string sqrt(string s)
        {
            string result = "",t="";string exresult="";
            string doublepart="";
            int i = 0, j = 0 ;
            string intpart = s.Substring(0, s.Length - (s.IndexOf('.') + 1));
            if(s.IndexOf('.')!=-1) doublepart= s.Substring(s.IndexOf('.')+1);
            while(doublepart.Length<znafza*2)
            {
                doublepart += "0";
            }
            if (intpart.Length % 2 == 1) { t = Convert.ToString(s[0]); intpart= intpart.Substring(1); }
            else { t = Convert.ToString(s[0]) + Convert.ToString(s[1]); intpart = intpart.Substring(2); }
            int k = 0;
                if (Convert.ToInt32(t) > 0)
                {
                    do { k++; } while (k * k < Convert.ToInt32(t));
                }
            result = Convert.ToString(k);
            t = vych(t, Convert.ToString(k * k));
            while(intpart.Length > 0)
            { 
                t+= Convert.ToString(intpart[0]) + Convert.ToString(intpart[1]);
                string b=result*"2";
                int l = -1;
                do
                {
                    l++;
                } while ((b + Convert.ToString(l)) * l<t));
                result+=Convert.ToString(l);
                t=vych(t, Convert.ToString((b + Convert.ToString(l)) * l));
                intpart = intpart.Substring(2);
            }
            
            if (znafza>0) exresult = result + '.';
            while(j<znafza)
            {
                t += Convert.ToString(doublepart[0]) + Convert.ToString(doublepart[1]);
                string b = result * "2";
                int l = -1;
                do
                {
                    l++;
                } while ((b + Convert.ToString(l)) * l < t));
                result += Convert.ToString(l);
                exresult += Convert.ToString(l);
                t = vych(t, Convert.ToString((b + Convert.ToString(l)) * l));
                doublepart = doublepart.Substring(2);
                j++;
            }
            return exresult;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s=textBox1.Text;
            if (s[0] == '-')
            { s = s.Substring(1); label1.Text = "i";}
            label1.Text = sqrt(s)+ label1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 6)
                znafza = Convert.ToInt32(textBox2.Text);
            else { znafza = 1000000;
                textBox2.Text = "1000000";
            }
        }
    }
}
