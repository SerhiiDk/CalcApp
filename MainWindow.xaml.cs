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

namespace CalcApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double value_one = 0;
        public string? opt_value;
        public bool second_click = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {


            Button button = (Button)sender;
            if (txtResult.Text == "0" && txtResult.Text.Length == 1)
            {
                txtResult.Text = "";
                txtResult.Text += button.Content.ToString();
                value_one = Convert.ToDouble(txtResult.Text);
            }

            else if (second_click) {
                txtResult.Text = txtResult.Text + button.Content.ToString();
            }
            else
            {

                txtResult.Text += button.Content.ToString();
                value_one = Convert.ToDouble(txtResult.Text);

            }


        }

        private void Button_clean(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "0";
            fistValueLabel.Content = "";
            opt_value = "";
            value_one = 0;
            second_click = false;
        }

        private void Button_Slet(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text.Length <= 1)
            {
                txtResult.Text = "0";
            }
            else
            {
                txtResult.Text = txtResult.Text.ToString().Substring(0,txtResult.Text.Length-1);
            }
        }

        private void Operator_Value(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            opt_value = button.Content.ToString();
            fistValueLabel.Content = value_one.ToString() + " " + opt_value;
            txtResult.Text = "";
            second_click = true;

        }

        private void Button_Result(object sender, RoutedEventArgs e)
        {
            Calculator calculator = new Calculator(Convert.ToDouble(value_one), Convert.ToDouble(txtResult.Text));

            fistValueLabel.Content += txtResult.Text + " = ";
            switch (opt_value)
            {
                case "+":
                    txtResult.Text = Convert.ToString(calculator.Sum());
                    value_one = Convert.ToDouble(txtResult.Text);
                    break;
                case "-":
                    txtResult.Text = Convert.ToString(calculator.Sub());
                    value_one = Convert.ToDouble(txtResult.Text);
                    break;
                case "x":
                    txtResult.Text = Convert.ToString(calculator.Multi());
                    value_one = Convert.ToDouble(txtResult.Text);
                    break;
                case "/":
                    if(Convert.ToDouble(txtResult.Text) == 0)
                    {
                        txtResult.Text = "Der kan ikke divideres med 0";
                    }
                    else
                    {
                        txtResult.Text = Convert.ToString(calculator.Divide());
                        value_one = Convert.ToDouble(txtResult.Text);
                    }
                    break;
                default:
                    break;
            }
        }

        private void Button_double(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            txtResult.Text += button.Content;
        }

        private void Button_Click_Pow(object sender, RoutedEventArgs e)
        {
            fistValueLabel.Content = "sqr(" + txtResult.Text + ")";
            txtResult.Text = Math.Pow(value_one, 2).ToString();
        }
    }
}
