using Calculator.Models;
using MathFunctions;
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

        private string LastResult { get; set; } = "0";

        public MainWindow()
        {
            MathFunction = MathFunction.GetInstance();
            CalcAction = OperationEnum.NoOperation;
            LastOperation = OperationEnum.NoOperation;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LastOperation != OperationEnum.Number)
            {
                resultTextBox.Text = "0";
                LastOperation = OperationEnum.Number;
            }

            Button button = (Button)sender;
            resultTextBox.Text = float.Parse(resultTextBox.Text + button.Content).ToString();
        }

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

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "0";
            valueStack = null;
            CalcAction = OperationEnum.NoOperation;
        }

        private void resultTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            float result;
            bool valid = float.TryParse(resultTextBox.Text, out result);

            if (valid)
            {
                LastResult = result.ToString();
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
    }
}
