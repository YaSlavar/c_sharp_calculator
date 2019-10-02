using System;
using System.Collections.Generic;
using System.Linq;
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

namespace calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double result;
        public double last_number;
        public string last_operation;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Numbers(object sender, RoutedEventArgs e)
        {
            Button AnyButton = (Button)sender;
            switch (AnyButton.Content)
            {
                case "0":
                    if (Tablo.Text != "0")
                    {
                        Tablo.Text += "0";
                    }
                    break;

                default:
                    if (Tablo.Text == "0")
                    {
                        Tablo.Text = Convert.ToString(AnyButton.Content);
                    }
                    else
                    {
                        Tablo.Text += AnyButton.Content;
                    }
                    break;
            }

        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            if (!Tablo.Text.Contains(","))
            {
                Tablo.Text += ",";
            }
        }

        private void Clean_mode(object sender, RoutedEventArgs e)
        {
            Button CleanButton = (Button)sender;
            switch (CleanButton.Content)
            {
                case "CE":
                    Tablo.Text = "0";
                    break;

                case "C":
                    Tablo.Text = "0";
                    Functions_calc.Text = "";
                    break;

                default:
                    if (Tablo.Text.Length == 1)
                    {
                        Tablo.Text = "0";
                    }
                    else
                    {
                        Tablo.Text = Tablo.Text.Substring(0, Tablo.Text.Length - 1);
                    }
                    break;
            }
        }

        private void Operation(object sender, RoutedEventArgs e)
        {
            Button CleanButton = (Button)sender;

            string val = (string)CleanButton.Content;

            

            switch (val)
            {
                case "=":

                    break;

                default:

                    Functions_calc.Text += Tablo.Text;
                    Functions_calc.Text += " ";
                    Functions_calc.Text += val;
                    Functions_calc.Text += " ";

                    Tablo.Text = "";

                    last_operation = val;
                    last_number = Convert.ToDouble(Tablo.Text);
                    
                    if (Functions_calc.Text.Length > 0)
                    {
                        switch (val)
                        {
                            case "+":
                                result = Convert.ToDouble(Tablo.Text) + last_number;
                                Tablo.Text = Convert.ToString(result);
                                break;
                        }
                        
                    }
                    break;
            }

        }
    }
}
