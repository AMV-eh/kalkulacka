using Calculator.Models;
using MathFunctions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MathFunction MathFunction { get; set; }
        private OperationEnum CalcAction { get; set; }

        private OperationEnum LastOperation { get; set; }

        private double? valueStack;

        private bool NextDecimal = false;
        private bool NextNegative = false;

        private string LastResult { get; set; } = "0";

        public MainWindow()
        {
            MathFunction = MathFunction.GetInstance();
            CalcAction = OperationEnum.NoOperation;
            LastOperation = OperationEnum.NoOperation;
            this.ResizeMode = ResizeMode.NoResize;
            this.KeyDown += HandleKeyPress;

            InitializeComponent();

        }

        /// <summary>
        /// Event handler for numbers
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }

            Button button = (Button)sender;
            string result;

            if (NextDecimal)
            {
                NextDecimal = false;
                result = double.Parse(resultTextBox.Text).ToString() + ",";
            }
            else
            {
                result = double.Parse(resultTextBox.Text + button.Content).ToString();
            }
            resultTextBox.Text = (NextNegative ? "-" : "") + result;
            NextNegative = false;
        }

        private void Button_Mantisa_Click(object sender, RoutedEventArgs e)
        {
            NextDecimal = true;
            Button_Click(sender, e);
        }

        /// <summary>
        /// Event handler for Factorial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Factorial_Click(object sender, RoutedEventArgs e)
        {
            double a;
            double.TryParse(resultTextBox.Text, out a);
            if ((a < 0) || (a % 1 != 0))
            {
                MessageBox.Show("Faktorial musí být kladné celé číslo");
                resultTextBox.Text = "0";
            }
            else
            {
                int result = MathFunction.Factorial((int)a);
                resultTextBox.Text = $"{result}";
            }
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Sum;
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            // Udelat z cisla zaporne cislo
            if (LastOperation != OperationEnum.Number && LastOperation != OperationEnum.Result)
            {
                NextNegative = true;
            }
            else
            {
                Process();
                CalcAction = OperationEnum.Subtract;
            }
        }

        /// <summary>
        /// Event hadler for Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Result_Click(object sender, RoutedEventArgs e)
        {
            if (valueStack != null)
            {
                resultTextBox.Text = OperationHelper.GetResult(CalcAction, (double)valueStack, double.Parse(resultTextBox.Text));
                valueStack = double.Parse(resultTextBox.Text);
            }
            LastOperation = OperationEnum.Result;
            CalcAction = OperationEnum.Result;
        }

        /// <summary>
        /// Clear values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "0";
            valueStack = null;
            CalcAction = OperationEnum.NoOperation;
            LastOperation = OperationEnum.NoOperation;
            NextDecimal = false;
            NextNegative = false;
        }

        private void resultTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string resultText = resultTextBox.Text;

            if (resultText == "")
            {
                resultTextBox.Text = "0";
                return;
            }

            double result;
            bool valid = double.TryParse(resultText, out result);
            bool select_end = false;

            // If string is not valid, replace it with last one
            if (valid)
            {
                select_end = LastResult == "0" && result % 10 != 0;
                LastResult = resultText;

                if (!string.IsNullOrEmpty(resultText))
                {
                    if (resultText[^1] == ',')
                    {
                        resultTextBox.Text = result.ToString() + ',';
                    }
                    else
                    {
                        resultTextBox.Text = result.ToString();
                    }
                }
                else
                {
                    resultTextBox.Text = result.ToString();
                }
            }
            else
            {
                resultTextBox.Text = LastResult;
            }

            if (select_end)
            {
                resultTextBox.Select(resultTextBox.Text.Length, 0);
            }
        }

        private bool Process()
        {
            if (CalcAction == OperationEnum.Sum ||
                CalcAction == OperationEnum.Subtract ||
                CalcAction == OperationEnum.Multiply ||
                CalcAction == OperationEnum.Divide ||
                CalcAction == OperationEnum.Factorial ||
                CalcAction == OperationEnum.Power ||
                CalcAction == OperationEnum.Root ||
                CalcAction == OperationEnum.Fibonnacci)
            {
                LastOperation = CalcAction;
                return false;
            }
            if (LastOperation != OperationEnum.Number && LastOperation != OperationEnum.NoOperation)
            {
                return false;
            }

            if (valueStack == null || CalcAction == OperationEnum.Result)
            {
                valueStack = double.Parse(resultTextBox.Text);
            }
            else
            {
                resultTextBox.Text = OperationHelper.GetResult(CalcAction, (double)valueStack, double.Parse(resultTextBox.Text));
                valueStack = double.Parse(resultTextBox.Text);
            }

            LastOperation = CalcAction;

            return true;
        }

        private void Button_Multiply_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Multiply;
        }

        private void Button_Divide_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Divide;
        }

        private void Button_Pi_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }

            resultTextBox.Text = Math.PI.ToString();
        }

        private void Button_E_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }

            resultTextBox.Text = Math.E.ToString();
        }

        private void Button_n2_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }
            double cont = double.Parse(resultTextBox.Text);
            resultTextBox.Text = Math.Pow(cont, 2).ToString();
        }

        private void Button_nx_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Power;
        }

        private void Button_Root_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Root;
        }

        private void Button_fib_Click(object sender, RoutedEventArgs e)
        {
            double a;
            double.TryParse(resultTextBox.Text, out a);
            if ((a < 0) || (a % 1 != 0))
            {
                MessageBox.Show("Fib musí být kladné celé číslo");
                resultTextBox.Text = "0";
            }
            else
            {
                int result = (int)MathFunction.Fibbonacci((int)a);
                resultTextBox.Text = $"{result}";
            }
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Q:
                    Button_Plus_Click(new Button(), new RoutedEventArgs());
                    resultTextBox.Text = "0";
                    break;
                case Key.W:
                    Button_Minus_Click(new Button(), new RoutedEventArgs());
                    NextNegative = false;
                    resultTextBox.Text = "0";
                    break;
                case Key.E:
                    Button_Multiply_Click(new Button(), new RoutedEventArgs());
                    resultTextBox.Text = "0";
                    break;
                case Key.R:
                    Button_Divide_Click(new Button(), new RoutedEventArgs());
                    resultTextBox.Text = "0";
                    break;
                case Key.C:
                    Button_Clear_Click(new Button(), new RoutedEventArgs());
                    break;
                case Key.V:
                    Button_Result_Click(new Button(), new RoutedEventArgs());
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"
? - pro zobrazení této nápovědy

n! - pro faktoriál n čísla
n^2 - pro 2 mocninou n čísla
n^x - pro x-tou mocninu n čísla
x√(n) - pro x-tou odmocninu n čísla
π - pro zapsání Ludolfova čísla (3.1415)
e - pro zapsání Eulerova čísla (2.7182)
fib - pro n-tý člen fibonacciho posloupnosti


+ - pro sčítání (na klávesnici Q)
- - pro odečítání (na klávesnici W)
x - pro násobení (na klávesnici E)
÷ - pro dělení (na klávesnici R)
C - pro smazání obsahu textové pole (na klávesnici C) 
, - pro zapsání desetinného čísla (na klávesnici ,)
= - pro vypsání výsledku (na klávesnici V)
");
        }
    }
}
