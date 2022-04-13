﻿using Calculator.Models;
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

        private float? valueStack;

        public MainWindow()
        {
            MathFunction = new MathFunction();
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CalcAction != OperationEnum.Number)
            {
                resultTextBox.Clear();
            }

            CalcAction = OperationEnum.Number;

            Button button = (Button)sender;
            resultTextBox.Text = resultTextBox.Text + button.Content;
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
            CalcAction = OperationEnum.Plus;
            if (valueStack == null)
            {
                valueStack = float.Parse(resultTextBox.Text);
            }
            else
            {
                valueStack = float.Parse(resultTextBox.Text) + (float)valueStack;
            }
            resultTextBox.Text = valueStack.ToString();
        }
    }
}
