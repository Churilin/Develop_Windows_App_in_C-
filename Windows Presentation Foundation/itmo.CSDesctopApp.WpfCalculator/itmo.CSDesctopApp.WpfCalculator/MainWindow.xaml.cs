using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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

namespace itmo.CSDesctopApp.WpfCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in Main.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "CE")
                txtBlock.Text = "";
            else if (str == "=")
            {
                string expression = txtBlock.Text.Replace("%", "*1");
                string value = new DataTable().Compute(expression, null).ToString();
                txtBlock.Text = value;
            }
            else if (str == "√")
            {
                double number;
                if (double.TryParse(txtBlock.Text, out number))
                {
                    double sqrtResult = Math.Sqrt(number);
                    txtBlock.Text = sqrtResult.ToString();
                }
                else
                {
                    txtBlock.Text = "Error";
                }
            }
            else if (str == "⌫")
            {
                if (txtBlock.Text.Length > 0)
                {
                    txtBlock.Text = txtBlock.Text.Substring(0, txtBlock.Text.Length - 1);
                }
            }
            else if (str == "x²") 
            {
                double number;
                if (double.TryParse(txtBlock.Text, out number))
                {
                    double cubeResult = Math.Pow(number, 3);
                    txtBlock.Text = cubeResult.ToString();
                }
                else
                {
                    txtBlock.Text = "Error";
                }
            }
            else
                txtBlock.Text += str;
        }

    }
}
