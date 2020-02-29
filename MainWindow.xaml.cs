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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button.Click += Button_Click;
        }

        public int offSet = 100;
        public int result = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox box = new TextBox();
            box.HorizontalAlignment = HorizontalAlignment.Left;
            box.VerticalAlignment = VerticalAlignment.Top;
            box.Margin = new Thickness(40, offSet, 0, 0);
            gMain.Children.Add(box);
            offSet += 20;
            result += 10;
            ChangeLabel();
        }

        private void ChangeLabel()
        {
            Label.Content = "Result " + result;
        }
    }
}
