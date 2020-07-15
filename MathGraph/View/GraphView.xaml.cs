using LiveCharts;
using LiveCharts.Wpf;
using MathGraph.Data;
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
            StepLabelValue.Text = (Math.Round(StepSlider.Value) / 10).ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChartValues<double> chartV = new ChartValues<double>();
            if (StepSlider.Value != 0)
            {
                equationSolver.SetStep(Math.Round(StepSlider.Value) / 10);
            }
            else
            {
                MessageBox.Show("Укажите шаг");
                return;
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
    }
}
