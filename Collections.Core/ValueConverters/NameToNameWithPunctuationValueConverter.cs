using System;
using MvvmCross.Platform.Converters;

namespace Collections.Core
{
    public class NameToNameWithPunctuationValueConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "This kitten does not have a name yet.";
            }

            return string.Format("{0}{1}", value, "!");
        }

        protected override string ConvertBack(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("Name should not convert back");
        }
    }
}
