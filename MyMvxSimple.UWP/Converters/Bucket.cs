using MvvmCross.Platform.WindowsCommon.Converters;
using MyMvxSimple.Core.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MyMvxSimple.UWP.Converters
{
    public class ManageBoolVisibilityConverter : MvxNativeValueConverter<BoolVisibilityConverter>
    {
    }

    public class ManageReverseBoolConverter : MvxNativeValueConverter<ReverseBoolValueConverter>
    {
    }

    public class WhenValueConverter : IValueConverter
    {
        public object When { get; set; }

        public object Value { get; set; }

        public object Others { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value.GetType() == When.GetType() && value.Equals(When))
            {
                return Value;
            }
            else
            {
                return Others;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
