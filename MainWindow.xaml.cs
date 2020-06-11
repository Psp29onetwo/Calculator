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
        double lastnumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalToButton.Click += EqualToButton_Click;


        }

        private void EqualToButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastnumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastnumber, newNumber);

                        break;
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastnumber, newNumber);

                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastnumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();

            }

            

        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                
                tempNumber = tempNumber / 100;
                if (lastnumber != 0)
                    tempNumber *= lastnumber;
                resultLabel.Content = tempNumber.ToString();

            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastnumber))
            {
                lastnumber = lastnumber * -1;
                resultLabel.Content = lastnumber.ToString();

            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastnumber = 0;
        }


        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastnumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == additionButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == subtractButton)
                selectedOperator = SelectedOperator.Subtraction;

        }

        private void decimalPointButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                //Do nothing
            }
            else
            {
                resultLabel.Content = $"{ resultLabel.Content }.";
            }

        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {

            int selectedValue = 0;

            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;
            if (sender == zeroButton)
                selectedValue = 0;


            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{ resultLabel.Content }{ selectedValue }";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Division,
        Multiplication
    }

    public class SimpleMath
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }
        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }
        public static double Divide(double number1, double number2)
        {
            if(number2 == 0)
            {
                MessageBox.Show("Division by zero (0) is not supported.", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return number1 / number2;
        }
    }
}
