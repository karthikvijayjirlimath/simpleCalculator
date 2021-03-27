using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace simpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;
            tb.Text += b.Content.ToString();
        }

        private void Result()
        {
            string Operator = "";
            int iop = 0;

            //checking for which operand used (+,-,*,/)

            if (tb.Text.Contains("+"))
            {
                iop = tb.Text.IndexOf("+");
            }
            else if (tb.Text.Contains("-"))
            {
                iop = tb.Text.IndexOf("-");
            }
            else if (tb.Text.Contains("*"))
            {
                iop = tb.Text.IndexOf("*");
            }
            else if (tb.Text.Contains("/"))
            {
                iop = tb.Text.IndexOf("/");
            }
            else if (tb.Text.Contains("^"))
            {
                iop = tb.Text.IndexOf("^");
            }
            else
            {
                MessageBox.Show("no operator found.Please start new");
            }

            //we got the two Numbers from the strings
            double operand1 = Convert.ToDouble(tb.Text.Substring(0, iop));
            double operand2 = Convert.ToDouble(tb.Text.Substring(iop + 1, tb.Text.Length - iop - 1));

            Operator = tb.Text.Substring(iop, 1);
            tb.Text = "answer is ";
            switch (Operator)
            {
                case "+":
                    {
                        tb.Text += (operand1 + operand2);
                        break;
                    }
                case "-":
                    {
                        tb.Text += (operand1 - operand2);
                        break;
                    }
                case "*":
                    {
                        tb.Text += (operand1 * operand2);
                        break;
                    }
                case "/":
                    {
                        if (operand2 == 0)
                            tb.Text = "trying to divide by 0";
                        else
                        {
                            tb.Text += (operand1 / operand2);
                        }
                        break;
                    }
                case "^":
                    {
                        int power = Convert.ToInt32(operand2);
                        double res = 1;
                        while(operand2-- > 0)
                        {
                            res *= operand1;
                        }
                        tb.Text += res;
                        break;
                    }

            }
        }
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception)
            {
                MessageBox.Show("there was an exception");
            }

        }

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0)
            {
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
            }
        }
    }
}
