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
        private CalcAction CalcAction { get; set; }
        float resultValue = 0;
        String performedOperation = "";
        float valueStack = 0;
        bool isPerformed = false;
        public MainWindow()
        {
            MathFunction = new MathFunction();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((resultTextBox.Text == "0") || isPerformed)
                resultTextBox.Clear();
            isPerformed = false;
            Button button = (Button)sender;
            resultTextBox.Text += button.Content;
        }

        private void Button_Click_Factorial(object sender, RoutedEventArgs e)
        {
            int a;
            int.TryParse(resultTextBox.Text, out a);

            int result = MathFunction.Factorial(a);

            resultTextBox.Text = $"{result}";
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            CalcAction = CalcAction.Plus;
            Button button = (Button)sender;
            //float r = float.Parse(resultTextBox.Text);
            performedOperation = button.Content.ToString();
            resultValue = float.Parse(resultTextBox.Text);
            valueStack = MathFunction.Sum(resultValue, valueStack);
            isPerformed = true;
        }

        private void Button_EQ_Click(object sender, RoutedEventArgs e)
        {
            switch(performedOperation)
            {
                case "+":
                    float sum = MathFunction.Sum(valueStack,float.Parse(resultTextBox.Text));
                    resultTextBox.Text = $"{sum}";
                    valueStack = sum;
                    break;
            }
        }
    }
}
