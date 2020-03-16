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
    public partial class MainWindow : Window
    {
        
        public int namer = 0;
        public Dictionary<TextBox, ComboBox> Pair = new Dictionary<TextBox, ComboBox>();

        public MainWindow()
        {
            InitializeComponent();
            Button.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox box = new TextBox()
            {
                Width = 30,
                Margin = new Thickness(5, 0, 5, 0),
            };
            ComboBox operations = MakeComboBox(new string[] { "+", "-", "*", "/" });
            Pair.Add(box, operations);
            StackPanel sPanel = new StackPanel()
            {
                Name = "sPanel" + namer,
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Button button = new Button()
            {
                Name = "button" + namer,
                Content = "удалить",
            };
            namer++;
            sPanel.Children.Add(operations);
            sPanel.Children.Add(box);
            sPanel.Children.Add(button);
            sMain.Children.Add(sPanel);
            box.Focus();
            operations.SelectionChanged += ChangeLabel;
            box.TextChanged += ChangeLabel;
            button.Click += DeleteButton_Click;
        }

        private void ChangeLabel(object sender, object args)
        {
            double result = 0;
            foreach (object obj in sMain.Children)
            {
                if (obj is StackPanel sp)
                    foreach (object obj2 in sp.Children)
                    {
                        if (obj2 is TextBox tb)
                        {
                            bool isInt = double.TryParse(tb.Text, out double a);
                            if (isInt)
                            {
                                ComboBox cBox = Pair[tb];
                                a = Convert.ToDouble(tb.Text);
                                result = Count(result, a, cBox.Text);
                                errorLabel.Content = "";
                            }
                            else errorLabel.Content = "Введите число";
                        }
                    }
            }
            Label.Content = "Result " + result;
        }

        private double Count (double result, double a, string op)
        {
            switch (op)
            {
                case "+":
                    result += a;
                    break;
                case "-":
                    result -= a;
                    break;
                case "*":
                    result *= a;
                    break;
                case "/":
                    result /= a;
                    break;
            }
            return result;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button dButton = (Button)sender;
            string buttonName = dButton.Name.Substring(6);
            foreach (object obj in sMain.Children)
            {
                if (obj is StackPanel sp)
                {
                    if (sp.Name.Substring(6).Equals(buttonName))
                    {
                        sMain.Children.Remove(sp);
                        break;
                    }
                }
            }
            ChangeLabel(sender, e);
        }

        private ComboBox MakeComboBox(string[] arr)
        {
            ComboBox box = new ComboBox();
            foreach (string item in arr)
            {
                ComboBoxItem cbItem = new ComboBoxItem
                {
                    Content = item
                };
                box.Items.Add(cbItem);
            }
            return box;
        }

        
    }
}
