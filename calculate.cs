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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RadioButton radio;
        int n1;
        int n2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool GetNum()
        {
            bool flag = true;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#ff0000");
            var brush1 = (Brush)converter.ConvertFromString("#C5C6D0");
            try
            {
                this.n1 = int.Parse(textbox1.Text);
                this.textbox1.BorderThickness = new Thickness(1);
                this.textbox1.ToolTip = null;
                this.textbox1.BorderBrush = brush1;
            }
            catch(Exception)
            {
                _ = MessageBox.Show("Sorry one of the inputs isn't number...", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                this.textbox1.BorderThickness = new Thickness(5);
                this.textbox1.BorderBrush = brush;
                this.textbox1.ToolTip = "You need to enter numbers!!!";
                return !flag;
            }

            try
            {
                this.n2 = int.Parse(textbox2.Text);
                this.textbox2.BorderThickness = new Thickness(1);
                this.textbox2.ToolTip = null;
                this.textbox2.BorderBrush = brush1;
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Sorry one of the inputs isn't number...", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                this.textbox2.BorderThickness = new Thickness(5);
                this.textbox2.BorderBrush = brush;
                this.textbox2.ToolTip = "You need to enter numbers!!!";
                return !flag;
            }
            return flag;
        }
        private void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Border border = textBox.Parent as Border;
            var converter = new System.Windows.Media.BrushConverter();
            var brush1 = (Brush)converter.ConvertFromString("#C5C6D0");

            try
            {
                if (textBox.Name == "textbox1")
                    n1 = int.Parse(textBox.Text);
                else
                    n2 = int.Parse(textBox.Text);

                this.textbox1.BorderThickness = new Thickness(1);
                this.textbox2.BorderThickness = new Thickness(1);
                this.textbox1.BorderBrush = brush1;
                this.textbox2.BorderBrush = brush1;
            }
            catch (Exception)
            {
                border.BorderThickness = new Thickness(2);
                border.ToolTip = "Enter numbers";
            }
        }

        /*private void B1(object sender, RoutedEventArgs e)
        {
            this.output.Text = GetNum() ? ((double)n1 + n2).ToString() : " ";
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            this.output.Text = GetNum() ? ((double)n1 - n2).ToString() : " ";
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            this.output.Text = GetNum() ? ((double)n1 * n2).ToString() : " ";
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#ff0000");
            GetNum();
            if (n2 != 0)
                this.output.Text = ((double)n1 / n2).ToString();
            else
            {
                _ = MessageBox.Show("You can't divide by zero...", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                this.textbox2.BorderBrush = brush;
                this.textbox2.BorderThickness = new Thickness(5);
            }

        }*/
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            int option = int.Parse(radio.Tag.ToString());
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#ff0000");

            switch (option)
            {
                case 1:
                    this.output.Text = GetNum() ? ((double)n1 + n2).ToString() : " ";
                    break;
                case 2:
                    this.output.Text = GetNum() ? ((double)n1 * n2).ToString() : " ";
                    break;
                case 3:
                    this.output.Text = GetNum() ? ((double)n1 - n2).ToString() : " ";
                    break;
                case 4:
                    GetNum();
                    if (n2 != 0)
                        this.output.Text = ((double)n1 / n2).ToString();
                    else
                    {
                        _ = MessageBox.Show("You can't divide by zero...", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        this.textbox2.BorderBrush = brush;
                        this.textbox2.BorderThickness = new Thickness(5);
                    }
                    break;
                case 5:
                    GetNum();
                    if (n2 != 0)
                        this.output.Text = (n1 / n2).ToString();
                    else
                    {
                        _ = MessageBox.Show("You can't divide by zero...", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        this.textbox2.BorderBrush = brush;
                        this.textbox2.BorderThickness = new Thickness(5);
                    }
                    break;
                case 6:
                    this.output.Text = GetNum() ? ((double)n1 % n2).ToString() : " ";
                    break;
                case 7:
                    this.output.Text = GetNum() ? (((double)n1 + n2) / 2).ToString() : " ";
                    break;
                case 8:
                    this.output.Text = GetNum() ? (Math.Max(n1,n2)).ToString() : " ";
                    break;
                case 9:
                    this.output.Text = GetNum() ? (Math.Min(n1, n2)).ToString() : " ";
                    break;
                case 10:
                    this.output.Text = GetNum() ? "Num1: " + Math.Abs(n1).ToString() + ", Num2: " + (Math.Abs(n2)).ToString() : " ";
                    break;
                case 11:
                    this.output.Text = GetNum() ? (Math.Pow(n1, n2)).ToString() : " ";
                    break;
                case 12:
                    this.output.Text = GetNum() ? "Num1: " + (Math.Sqrt(n1)).ToString() + ", Num2: " + (Math.Sqrt(n2)).ToString() : " ";
                    break;
                case 13:
                    this.output.Text = GetNum() ? "Num1: " + (Math.Sin(n1)).ToString() + ", Num2: " + (Math.Sin(n2)).ToString() : " ";
                    break;
                case 14:
                    this.output.Text = GetNum() ? "Num1: " + (Math.Cos(n1)).ToString() + ", Num2: " + (Math.Cos(n2)).ToString() : " ";
                    break;
            }
        }
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            if(radio != null)
                radio.IsChecked = false;
        }
    }
}
