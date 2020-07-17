using System;
using System.Collections.Generic;
using System.Text;

namespace MathGraph.Data
{
    public class SettingsController
    {
        public string[] SettingsFileArray = {
            System.IO.Path.Combine(Environment.CurrentDirectory, "CanDrawPoints.txt"),
            System.IO.Path.Combine(Environment.CurrentDirectory, "CanChangeStep.txt")
        };
    }
}
