using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
       
        public void Kalkulet(string str,out double rez)
        {
            rez = 0;
            string[] _Vs = str.Split(' ');
            List<string> Vs = new List<string>();
            for (int i = 0; i < _Vs.Length; i++)
            {
                Vs.Add(_Vs[i]); 
            }
            if (Vs[Vs.Count-1] == "" &( Vs[Vs.Count-2] == "+" || Vs[Vs.Count - 2] == "-" || Vs[Vs.Count - 2] == "*" || Vs[Vs.Count - 2] == "/"))
            {
                rez = -1;
            }
            else
            {

                for (int i = 0; i < Vs.Count; i++)
                {
                    if (Vs[i] == "*")
                    {
                        Vs[i] = Convert.ToString(Convert.ToDouble(Vs[i - 1]) * Convert.ToDouble(Vs[i + 1]));
                        Vs.RemoveAt(i - 1);
                        Vs.RemoveAt(i);
                        i -= 1;
                    }
                    if (Vs[i] == "/")
                    {
                        Vs[i] = Convert.ToString(Convert.ToDouble(Vs[i - 1]) / Convert.ToDouble(Vs[i + 1]));
                        Vs.RemoveAt(i - 1);
                        Vs.RemoveAt(i);
                        i -= 1;
                    }
                    if (Vs[i] == "%")
                    {
                        Vs[i] = Convert.ToString(Convert.ToDouble(Vs[i - 1]) / 100);
                        Vs.RemoveAt(i - 1);
                        i -= 1;
                    }
                }
                for (int i = 0; i < Vs.Count; i++)
                {
                    if (Vs[i] == "+")
                    {
                        Vs[i] = Convert.ToString(Convert.ToDouble(Vs[i - 1]) + Convert.ToDouble(Vs[i + 1]));
                        Vs.RemoveAt(i - 1);
                        Vs.RemoveAt(i);
                        i -= 1;
                    }
                    if (Vs[i] == "-")
                    {
                        Vs[i] = Convert.ToString(Convert.ToDouble(Vs[i - 1]) - Convert.ToDouble(Vs[i + 1]));
                        Vs.RemoveAt(i - 1);
                        Vs.RemoveAt(i);
                        i -= 1;
                    }
                }
                rez = Convert.ToDouble(Vs[0]);
            }

        }
        private void C_Clicked(object sender, EventArgs e)
        {
            var But = (Xamarin.Forms.Button)sender;
            string str = Convert.ToString(But.Text);
            if (str == "=")
            {
                Kalkulet(Vivod.Text,out double x);
                if(x==-1)
                {
                    DisplayAlert("Ошибка", "Не праильная запись", "Ок");
                }
                else
                {
                    Rez.Text = Convert.ToString(x);
                }
                
            }
            if (str == "0") { Vivod.Text += "0"; }
            if (str == "1") { Vivod.Text += "1"; }
            if (str == "2") { Vivod.Text += "2"; }
            if (str == "3") { Vivod.Text += "3"; }
            if (str == "4") { Vivod.Text += "4"; }
            if (str == "5") { Vivod.Text += "5"; }
            if (str == "6") { Vivod.Text += "6"; }
            if (str == "7") { Vivod.Text += "7"; }
            if (str == "8") { Vivod.Text += "8"; }
            if (str == "9") { Vivod.Text += "9"; }
            if (str == "+") { Vivod.Text += " + "; }
            if (str == "-") { Vivod.Text += " - "; }
            if (str == "*") { Vivod.Text += " * "; }
            if (str == "/") { Vivod.Text += " / "; }
            if (str == "%") { Vivod.Text += " % "; }
            if (str == "C") { Vivod.Text = ""; }
            if (str == "CE")
            {
                if (Vivod.Text[Vivod.Text.Length-1] == '1'|| Vivod.Text[Vivod.Text.Length-1] == '2' || Vivod.Text[Vivod.Text.Length-1] == '3' || Vivod.Text[Vivod.Text.Length-1] == '4' || Vivod.Text[Vivod.Text.Length-1] == '5' || Vivod.Text[Vivod.Text.Length-1] == '6' || Vivod.Text[Vivod.Text.Length-1] == '7' || Vivod.Text[Vivod.Text.Length-1] == '8' || Vivod.Text[Vivod.Text.Length-1] == '9' || Vivod.Text[Vivod.Text.Length-1] == '0')
                {
                    Vivod.Text = Vivod.Text.Remove(Vivod.Text.Length - 1, 1);
                }
                else
                {
                    Vivod.Text = Vivod.Text.Remove(Vivod.Text.Length - 3, 3);
                }
              
            }
            
        }
    }
}
