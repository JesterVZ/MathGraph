using LiveCharts;
using LiveCharts.Wpf;
using MathGraph.Data;
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
    /// Логика взаимодействия для GraphView.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        EquationSolver equationSolver;
        public GraphView()
        {
            equationSolver = new EquationSolver();
            InitializeComponent();
            CheckSettintsState();
        }

        private void GraphTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GraphTypeCombobox.SelectedIndex == 1)
            {
                PowerTextBox.IsEnabled = true;
            }
            else
            {
                PowerTextBox.IsEnabled = false;
            }
        }

        private void StepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(StepSliderListItem.Visibility == Visibility.Visible)
            {
                StepLabelValue.Text = (Math.Round(StepSlider.Value) / 10).ToString();
            } else
            {
                StepLabelValue.Text = "";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChartValues<double> chartV = new ChartValues<double>();
            if (StepSliderListItem.Visibility == Visibility.Visible)
            {
                if (StepSlider.Value != 0)
                {
                    equationSolver.SetStep(Math.Round(StepSlider.Value) / 10);
                }
                else
                {
                    MessageBox.Show("Укажите шаг");
                    return;
                }

            } else
            {
                equationSolver.SetStep(0.1);
            }


            switch (GraphTypeCombobox.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Выберите уравнение");
                    return;
                case 0:
                    equationSolver.Power(2);
                    break;
                case 1:
                    try
                    {
                        equationSolver.Power(Convert.ToInt32(PowerTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Укажите степень");
                    }
                    break;
                case 2:
                    equationSolver.Power(3);
                    break;
                case 3:
                    equationSolver.Sinus();
                    break;
                case 4:
                    equationSolver.Cosinus();
                    break;
                case 5:
                    equationSolver.SquareRoot();
                    break;
            }
            SeriesChart.Series.Clear();
            foreach (double i in equationSolver.Values)
            {
                chartV.Add(i);
            }
            if (DrawPointsCheckBox.IsChecked == true)
            {
                SeriesChart.Series.Add(new LineSeries
                {
                    Values = chartV,
                }); ;
            }
            else
            {
                SeriesChart.Series.Add(new LineSeries
                {
                    Values = chartV,
                    PointGeometry = null
                });
            }

            DataContext = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SeriesChart.Series.Clear();
        }
        private void CheckSettintsState()
        {
            SettingsController settingsController = new SettingsController();
            try
            {
                for (int i = 0; i < settingsController.SettingsFileArray.Length; i++)
                {
                    string path = settingsController.SettingsFileArray[i];
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string outputValue = sr.ReadToEnd();
                        if (i == 0)
                        {
                            if (outputValue == "true")
                            {
                                DrawPointsListViewItem.Visibility = Visibility.Visible;
                            }
                            if (outputValue == "false")
                            {
                                DrawPointsListViewItem.Visibility = Visibility.Hidden;
                            }
                        }
                        if (i == 1)
                        {
                            if (outputValue == "true")
                            {
                                StepSliderListItem.Visibility = Visibility.Visible;
                            }
                            if (outputValue == "false")
                            {
                                StepSliderListItem.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
