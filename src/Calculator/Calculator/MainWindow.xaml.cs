using Calculator.Models;
using MathFunctions;
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
            if (!Process())
            {
                return;
            }
            
            CalcAction = OperationEnum.Sum;
            LastOperation = OperationEnum.Sum;
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (!Process())
            {
                return;
            }

            CalcAction = OperationEnum.Substract;
            LastOperation = OperationEnum.Substract;
        }

        private void Button_Result_Click(object sender, RoutedEventArgs e)
        {
            if (valueStack != null)
            {
                resultTextBox.Text = OperationHelper.GetResult(CalcAction, (float)valueStack, float.Parse(resultTextBox.Text));
                valueStack = float.Parse(resultTextBox.Text);
            }
            CalcAction = OperationEnum.Result;
            LastOperation = OperationEnum.Result;
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
            if (LastOperation != OperationEnum.Number && LastOperation != OperationEnum.NoOperation)
            {
                return false ;
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

            return true;
        }
    }
}
