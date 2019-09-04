using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool opr_varmi = false;

        bool islem_mi(string x)
        {
            if (x == "+" || x == "-" || x == "/" || x == "*")
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RAKAMLARI YAZDIRMA
            Button b1 = (Button)sender;
            t_ekran.Text += b1.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //SİLME BUTONU
            t_ekran.Text = null;
            opr_varmi = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            String cumle = t_ekran.Text;
            if (cumle.Length != 0)
            {
                t_ekran.Text = cumle.Substring(0, cumle.Length - 1);
                if (islem_mi(cumle.Substring(cumle.Length - 1)))
                {
                    opr_varmi = false;
                }
            }
        }

     

        double ikili_islem(string cumle)
        {
            double x, y,sonuc;
            sonuc = 0;
            for (int i = 0; i < cumle.Length; i++)
            {
                if(islem_mi(cumle.Substring(i,1)))
                {
                    x = Convert.ToDouble(cumle.Substring(0, i));
                    y= Convert.ToDouble(cumle.Substring(i+1));
                  //  MessageBox.Show(x.ToString()+"..."+y.ToString()+"___i="+i.ToString());

                    if (cumle.Substring(i,1)=="-")
                    {
                        sonuc = x - y;
                        //MessageBox.Show("Sonuc= " + (x - y).ToString());
                    }
                    else if (cumle.Substring(i, 1) == "+")
                    {
                        sonuc = x + y;
                    }
                    else if (cumle.Substring(i, 1) == "*")
                    {
                        sonuc = x * y;
                    }
                    else sonuc = x / y;
                }

            }

            return sonuc;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button b1 = (Button)sender;
            string islem = b1.Text;
            string cumle = t_ekran.Text;

          
            if(opr_varmi)
            t_ekran.Text = ikili_islem(cumle).ToString();

            if (islem_mi(islem))
            {
                opr_varmi = true;
            }


            if (t_ekran.Text != "")
            {
                if (cumle.Substring(cumle.Length - 1, 1) != "+" && cumle.Substring(cumle.Length - 1, 1) != "-" && cumle.Substring(cumle.Length - 1, 1) != "/" && cumle.Substring(cumle.Length - 1, 1) != "*" && cumle.Substring(cumle.Length - 1, 1) != ",")
                {
                    if (islem != ",")  t_ekran.Text += islem;
                    else
                    { 
                        for (int i = cumle.Length; i > 0; i--)
			            {
                            if (islem_mi(cumle.Substring(i - 1, 1)) == true)
                            {
                                t_ekran.Text += ",";
                                break;
                            }
                            else if (cumle.Substring(i - 1, 1) == ",")
                            {
                                break;
                            }
                            if(i==1) t_ekran.Text += ",";
			            }
                        
                    }
                    
                }

            }

            
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(t_ekran.Text!="")
            t_ekran.Text=ikili_islem(t_ekran.Text).ToString();
            opr_varmi = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (opr_varmi == false)
            {
                t_ekran.Text = Math.Pow(Convert.ToDouble(t_ekran.Text), 2).ToString();
            }
        }

      
    }
}
