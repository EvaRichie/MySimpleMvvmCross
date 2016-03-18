using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MyMvxSimple.Core.Converters
{
    public class StringListToStringValueConverter : MvxValueConverter<List<string>, string>
    {
        protected override string Convert(List<string> value, Type targetType, object parameter, CultureInfo culture)
        {
            var strResult = string.Empty;
            if (value != null && value.Count > 0)
            {
                foreach (var s in value)
                    strResult += string.Format($" {s} ");
            }
            return strResult;
        }
    }
}
