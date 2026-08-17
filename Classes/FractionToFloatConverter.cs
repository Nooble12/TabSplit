using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace TabSplit.Classes
{
    public class FractionToFloatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float f)
            {
                return f.ToString(culture);
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                string processedString = text.Trim();

                if (float.TryParse(processedString, out float resultValue)) // tries to parse inputs such as 1.2
                {
                    return resultValue;
                }

                try
                {
                    string[] stringArr = processedString.Split("/"); // splits inputs such as 1/2 to [1,2]

                    if (float.TryParse(stringArr[0], out float numerator) && float.TryParse(stringArr[1], out float denominator))
                    {
                        if (denominator != 0)
                        {
                            return numerator / denominator;
                        }
                    }

                }
                catch(Exception e)
                {
                    Debug.WriteLine("Error:" + e);
                }
            }

            return Binding.DoNothing;
        }
    }
}
