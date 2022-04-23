using Calculator.Models;
using MathFunctions;
using System;
using System.Windows;
using System.Windows.Controls;

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

        private float? valueStack;

        private bool NextDecimal = false;

        private string LastResult { get; set; } = "0";

        public MainWindow()
        {
            MathFunction = MathFunction.GetInstance();
            CalcAction = OperationEnum.NoOperation;
            LastOperation = OperationEnum.NoOperation;
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
                result = float.Parse(resultTextBox.Text).ToString() + ",";
            }
            else
            {
                result = float.Parse(resultTextBox.Text + button.Content).ToString();
            }
            resultTextBox.Text = result;
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
            int a;
            int.TryParse(resultTextBox.Text, out a);

            int result = MathFunction.Factorial(a);

            resultTextBox.Text = $"{result}";
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Sum;
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            Process();
            CalcAction = OperationEnum.Substract;
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
                resultTextBox.Text = OperationHelper.GetResult(CalcAction, (float)valueStack, float.Parse(resultTextBox.Text));
                valueStack = float.Parse(resultTextBox.Text);
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
        }

        private void resultTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string resultText = resultTextBox.Text;

            if (resultText == "")
            {
                resultTextBox.Text = "0";
                return;
            }

            float result;
            bool valid = float.TryParse(resultText, out result);


            // If string is not valid, replace it with last one
            if (valid)
            {
                LastResult = resultText;
                resultTextBox.Text = resultText;
            }
            else
            {
                resultTextBox.Text = LastResult;
            }
        }

        private bool Process()
        {
            //if (LastOperation == OperationEnum.Sum ||
            //    LastOperation == OperationEnum.Substract ||
            //    LastOperation == OperationEnum.Multiply ||
            //    LastOperation == OperationEnum.Divide ||
            //    LastOperation == OperationEnum.Factorial ||
            //    LastOperation == OperationEnum.Power ||
            //    LastOperation == OperationEnum.Root ||
            //    LastOperation == OperationEnum.Fibonnacci)
            //{
            //    CalcAction = LastOperation;
            //}
            if (LastOperation != OperationEnum.Number && LastOperation != OperationEnum.NoOperation)
            {
                return false;
            }

            if (valueStack == null)
            {
                valueStack = float.Parse(resultTextBox.Text);
            }
            else
            {
                resultTextBox.Text = OperationHelper.GetResult(CalcAction, (float)valueStack, float.Parse(resultTextBox.Text));
                valueStack = float.Parse(resultTextBox.Text);
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

            Button button = (Button)sender;
            resultTextBox.Text = double.Parse(resultTextBox.Text + Math.PI).ToString();
        }

        private void Button_E_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }

            Button button = (Button)sender;
            resultTextBox.Text = double.Parse(resultTextBox.Text + Math.E).ToString();

        }

        private void Button_n2_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }
            Button button = (Button)sender;
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
            int a;
            int.TryParse(resultTextBox.Text, out a);

            int result = (int)MathFunction.Fibbonacci(a);

            resultTextBox.Text = $"{result}";
        }
    }
}
