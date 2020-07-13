using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MathGraph
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public bool CanDrawPoints = false;
        public bool CanResizeMode = false;
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(CanDrawPointsCheckBox.IsChecked == true)
            {
                CanDrawPoints = true;
            } else
            {
                CanDrawPoints = false;
            }
            if(CanResizeModeCheckBox.IsChecked == true)
            {
                CanResizeMode = true;
            } else
            {
                CanResizeMode = false;
            }
        }
    }
}
