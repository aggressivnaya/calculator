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
    public partial class MainWindow : Window
    {
        RadioButton radio;
        Random rnd = new Random();
        int n1;
        int n2;
        int ok = 0;
        int fail = 0;
        bool buttonWasClicked1 = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private bool GetNum(int i)
        {
            bool flag = true;
            n1 = rnd.Next(0, 100);
            n2 = rnd.Next(0, 100);
            this.textbox1.Text = n1.ToString();
            this.textbox2.Text = n2.ToString();
             if (i == 1) 
            { 
                this.textbox1.Text = n1.ToString();
                this.textbox2.Text = "None";
            }
             else 
            {
                this.textbox1.Text = n1.ToString();
                this.textbox2.Text = n2.ToString();
            }

            return flag;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            int option = int.Parse(radio.Tag.ToString());
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#ff0000");

            switch (option)
            {
                case 1:
                    this.result.Text = GetNum(2) ? ((double)n1 + n2).ToString() : " ";
                    break;
                case 2:
                    this.result.Text = GetNum(2) ? ((double)n1 * n2).ToString() : " ";
                    break;
                case 3:
                    this.result.Text = GetNum(2) ? ((double)n1 - n2).ToString() : " ";
                    break;
                case 4:
                    GetNum(2);
                    if (n2 != 0)
                        this.result.Text = ((double)n1 / n2).ToString();
                    else
                    {
                        _ = MessageBox.Show("You can't divide by zero...", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        this.textbox2.BorderBrush = brush;
                        this.textbox2.BorderThickness = new Thickness(5);
                    }
                    break;
                case 5:
                    GetNum(2);
                    if (n2 != 0)
                        this.result.Text = (n1 / n2).ToString();
                    else
                    {
                        _ = MessageBox.Show("You can't divide by zero...", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        this.textbox2.BorderBrush = brush;
                        this.textbox2.BorderThickness = new Thickness(5);
                    }
                    break;
                case 6:
                    this.result.Text = GetNum(2) ? ((double)n1 % n2).ToString() : " ";
                    break;
                case 7:
                    this.result.Text = GetNum(2) ? (((double)n1 + n2) / 2).ToString() : " ";
                    break;
                case 8:
                    this.result.Text = GetNum(2) ? (Math.Max(n1,n2)).ToString() : " ";
                    break;
                case 9:
                    this.result.Text = GetNum(2) ? (Math.Min(n1, n2)).ToString() : " ";
                    break;
                case 10:
                    this.result.Text = GetNum(1) ? Math.Abs(n1).ToString() : " ";
                    break;
                case 11:
                    this.result.Text = GetNum(2) ? (Math.Pow(n1, n2)).ToString() : " ";
                    break;
                case 12:
                    this.result.Text = GetNum(1) ? Math.Sqrt(n1).ToString() : " ";
                    break;
                case 13:
                    this.result.Text = GetNum(1) ? Math.Sin(n1).ToString() : " ";
                    break;
                case 14:
                    this.result.Text = GetNum(1) ? Math.Cos(n1).ToString() : " ";
                    break;
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            if(radio != null)
                radio.IsChecked = false;
        }

        private void ButtonWasClicked(object sender, RoutedEventArgs e)
        {
            buttonWasClicked1 = true;
            AnswerClick(sender, e);
        }

        private void AnswerClick(object sender, RoutedEventArgs e)
        {
            double result = double.Parse(this.result.Text);
            double answer = double.Parse(this.answer.Text);

            if (result == answer) { ok++; }
            else { fail++; }

            if (buttonWasClicked1 && ok + fail == 14)
            {
                double grade = ok / (double)(ok + fail);
                int gradePer = (int)Math.Round(grade * 100);
                _ = MessageBox.Show($"The precentage of the write answers: {gradePer}", "Finished Precentage", MessageBoxButton.OKCancel , MessageBoxImage.Exclamation);
            }
        }
    }
}
