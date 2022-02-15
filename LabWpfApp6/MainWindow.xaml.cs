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

namespace LabWpfApp6
{
    enum Precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }
    class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;
        private string wind_direction;
        private int wind_speed;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public WeatherControl(string winddir, int windsp, Precipitation precipitation)
        {
            this.WindDirection = winddir;
            this.WindSpeed = windsp;
            this.precipitation = precipitation;
        }
        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.AffectsMeasure |
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceTemp)),
            new ValidateValueCallback(ValidateTemp));
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            throw new NotImplementedException();
        }

        private static bool ValidateTemp (object value)
        {
            int v = (int)value; 
            if (v>= -50 && v<= 50)
            {
                return true;    
            }
            else
            {
                return false;   
            }
        }
    }
}
