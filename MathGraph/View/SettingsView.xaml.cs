using MathGraph.Data;
using MathGraph.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathGraph.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        string [] SettingsFileArray = {
            System.IO.Path.Combine(Environment.CurrentDirectory, "CanDrawPoints.txt"),
            System.IO.Path.Combine(Environment.CurrentDirectory, "CanResizeMode.txt")
        };
        public SettingsView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CanDrawPointsCheckBox.IsChecked == true)
            {
                string path = SettingsFileArray[0];
                WriteFile(path, true);
            } else
            {
                string path = SettingsFileArray[0];
                WriteFile(path, false);
            }
            if(CanResizeMode.IsChecked == true)
            {
                string path = SettingsFileArray[1];
                WriteFile(path, true);
            } else
            {
                string path = SettingsFileArray[1];
                WriteFile(path, false);
            }
        }
        private void WriteFile(string value, bool enabled)
        {
            using (FileStream fs = File.Create(value))
            {
                if (enabled)
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("true");
                    fs.Write(info, 0, info.Length);
                } else
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("false");
                    fs.Write(info, 0, info.Length);
                }
            }
        }
    }
}
