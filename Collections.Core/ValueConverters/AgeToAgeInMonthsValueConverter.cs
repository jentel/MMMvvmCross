using System;
using MvvmCross.Platform.Converters;

namespace Collections.Core.ValueConverters
{
    public class AgeToAgeInMonthsValueConverter : MvxValueConverter<int, string>
    {
        protected override string Convert(int value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Format("Months: {0}", value);
        }

        protected override int ConvertBack(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("Age should not convert back");
        }
    }
}
