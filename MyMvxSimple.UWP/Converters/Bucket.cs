using MvvmCross.Platform.WindowsCommon.Converters;
using MvvmCross.Plugins.PictureChooser.WindowsStore;
using MyMvxSimple.Core.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MyMvxSimple.UWP.Converters
{
    public class ManageBoolVisibilityConverter : MvxNativeValueConverter<BoolVisibilityValueConverter>
    {
    }

    public class ManageReverseBoolConverter : MvxNativeValueConverter<ReverseBoolValueConverter>
    {
    }

    public class ManageByteArrayImageConverter : MvxNativeValueConverter<MvxInMemoryImageValueConverter>
    {
    }

    public class ManageStringListToStringConverter : MvxNativeValueConverter<StringListToStringValueConverter>
    {
    }

    public class StringToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string && value?.ToString() != string.Empty)
            {
                return new Uri(value.ToString());
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class C_StringToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string && value?.ToString() != string.Empty)
            {
                var imgSrc = new BitmapImage();
                imgSrc.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                imgSrc.UriSource = new Uri(value.ToString());
                return imgSrc;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
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
