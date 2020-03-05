﻿using System;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox box = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 30,
                Margin = new Thickness(40, offSet, 0, 0)
            };
            gMain.Children.Add(box);
            offSet += 20;
            box.TextChanged += ChangeLabel;
        }

        private void ChangeLabel(object sender, object args)
        {
            int result = 0;
            foreach (object obj in gMain.Children)
            {
                if (obj is TextBox)
                {
                    TextBox tb = (TextBox)obj;
                    int a = Convert.ToInt32(tb.Text);
                    result += a;
                }
            }
            Label.Content = "Result " + result;
        }
    }
}
