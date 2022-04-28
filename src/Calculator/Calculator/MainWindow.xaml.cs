using Calculator.Models;
using MathFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <summary>
        /// Mathematical functions
        /// </summary>
        private MathFunction MathFunction { get; set; }
        /// <summary>
        /// Operators
        /// </summary>
        private OperationEnum CalcAction { get; set; }
        /// <summary>
        /// Last operation
        /// </summary>
        private OperationEnum LastOperation { get; set; }
        /// <summary>
        /// Stack for previous numbers
        /// </summary>
        private double? valueStack;
        /// <summary>
        /// Variable to check if next number is decimal
        /// </summary>
        private bool NextDecimal = false;
        /// <summary>
        /// Variable to check if next number is negative
        /// </summary>
        private bool NextNegative = false;
        /// <summary>
        /// Variable with last result
        /// </summary>
        private string LastResult { get; set; } = "0";
        /// <summary>
        /// Constructor
        /// </summary>
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
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Event handler for mantisa
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_Mantisa_Click(object sender, RoutedEventArgs e)
        {
            NextDecimal = true;
            Button_Click(sender, e);
        }

        /// <summary>
        /// Event handler for factorial
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Event handler for addition
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Sum;
        }

        /// <summary>
        /// Event handler for substraction
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
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
        /// Event hadler for result
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
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
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "0";
            valueStack = null;
            CalcAction = OperationEnum.NoOperation;
            LastOperation = OperationEnum.NoOperation;
            NextDecimal = false;
            NextNegative = false;
        }

        /// <summary>
        /// Event hadler for resultTextBox. Its called when value in resultTextBox is changed
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
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

            if (result > 100000000000000000 || result < -100000000000000000)
            {
                resultTextBox.Text = LastResult;
                return;
            }

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

        /// <summary>
        /// Function for processing math operations.
        /// </summary>
        /// <returns>True if calculated/False if not calculated</returns>
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

        /// <summary>
        /// Event handler for multiplication
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_Multiply_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Multiply;
        }

        /// <summary>
        /// Event handler for division
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_Divide_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Divide;
        }

        /// <summary>
        /// Event handler for pi
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_Pi_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }

            resultTextBox.Text = Math.PI.ToString();
        }

        /// <summary>
        /// Event handler for E
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_E_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }

            resultTextBox.Text = Math.E.ToString();
        }

        /// <summary>
        /// Event handler for power^2
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Event handler for power^x
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_nx_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Power;
        }

        /// <summary>
        /// Event handler for root
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_Root_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Root;
        }

        /// <summary>
        /// Event handler for fibbonacci
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Event handler for keyboard operations
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Event handler for help MessageBox 
        /// </summary>
        /// <param name="sender">Source element</param>
        /// <param name="e">Event arguments</param>
        private void Button_Help_Click(object sender, RoutedEventArgs e)
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
